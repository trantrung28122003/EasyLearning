using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Application.Services;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using EasyLearning.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EasyLearning.WebApp.Areas.admin.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly UserRepository _userRepository;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IShoppingCartItemService _shoppingCartItemService;
        private readonly ICourseService _courseService;
        private readonly IUserTrainingProgressService _userTrainingProgressService;
        private readonly ITrainingPartService _trainingPartService;
        public PaymentController(IPaymentService paymentService, UserRepository userRepository, 
            IOrderDetailService orderDetailService, IOrderService orderService, IShoppingCartService shoppingCartService,
            IShoppingCartItemService shoppingCartItemService, ICourseService courseService, IUserTrainingProgressService userTrainingProgressService,
            ITrainingPartService trainingPartService)
        {
            _paymentService = paymentService;
            _userRepository = userRepository;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _shoppingCartService = shoppingCartService;
            _shoppingCartItemService = shoppingCartItemService;
            _courseService = courseService;
            _userTrainingProgressService = userTrainingProgressService;
            _trainingPartService = trainingPartService;
        }
        public async Task<IActionResult> Index()
        {
            string orderJson = TempData["OrderViewModelJson"] as string;
            if (string.IsNullOrEmpty(orderJson))
            {
                // Xử lý trường hợp không có dữ liệu trong TempData
                return RedirectToAction("Error", "Order");
            }
            else
            {
                OrderViewModel orderViewModel = JsonConvert.DeserializeObject<OrderViewModel>(orderJson);
                decimal decimalAmount = orderViewModel.OrderTotalPrice; 
                string amountString = decimalAmount.ToString().Replace(".", "");
                string notes = orderViewModel.OrderNotes.ToString();
                var url = await _paymentService.doPayment(amountString, notes);
                return Redirect(url);
            }
        }

        public async Task<ActionResult> ConfirmPaymentClient(MomoResult result)
        {
            string orderJson = TempData["OrderViewModelJson"] as string;
            if (string.IsNullOrEmpty(orderJson))
            {
                // Xử lý trường hợp không có dữ liệu trong TempData
                return View("FailurePayment");
            }
            else
            {
                string rMessage = result.message;
                string rOrderId = result.orderId;
                string rErrorCode = result.errorCode;
                var shoppingCart = await _shoppingCartService.GetShoppingCartByUserIdAsync();
                var getShoppingCartItem = await _shoppingCartItemService.GetShoppingCartItemByShopingCart(shoppingCart.Id);
                List<Course> listCourse = new List<Course>();
                List<TrainingPart> listTrainingPart = new List<TrainingPart>();
                OrderViewModel orderViewModel = JsonConvert.DeserializeObject<OrderViewModel>(orderJson);
                if (rErrorCode == "0")
                {
                    var order = new Order
                    {
                        UserId = _userRepository.getCurrrentUser(),
                        OrderPaymentMethod = orderViewModel.OrderPaymentMethod,
                        OrderTotalPrice = orderViewModel.OrderTotalPrice,
                        OrderNotes = orderViewModel.OrderNotes,
                        DateCreate = DateTime.Now,
                        IsDeleted = false,
                    };
                    await _orderService.CreateOrder(order);

                    foreach (var itemShoppingCart in getShoppingCartItem)
                    {
                        var orderDetail = new OrderDetail
                        {
                            OrderId = order.Id,
                            CoursesId = itemShoppingCart.CoursesId,
                            DateCreate = DateTime.Now,
                            IsDeleted = false
                        };
                        await _orderDetailService.CreateOrderDetail(orderDetail);

                    }
                    foreach (var itemCart in getShoppingCartItem)
                    {
                        await _shoppingCartItemService.DeleteShoppingCartItem(itemCart);
                    }

                    foreach(var itemOrderDetail in await _orderDetailService.GetAllOrderDetails())
                    {
                        listCourse.AddRange(await _courseService.GetCourseByOrderDetail(itemOrderDetail.Id));
                    } 
                    
                    foreach( var itemCourse in listCourse)
                    {
                        listTrainingPart.AddRange(await _trainingPartService.GetTrainingPartByCourse(itemCourse.Id));
                    }

                    foreach (var itemTrainingPart in listTrainingPart)
                    {
                        var userTrainingProgress = new UserTrainingProgress
                        {
                            UserId = _userRepository.getCurrrentUser(),
                            TrainingPartId = itemTrainingPart.Id,
                            IsCompleted = false,
                            DateCreate = DateTime.Now,
                            DateChange = DateTime.Now,
                            ChangedBy = _userRepository.getCurrrentUser(),
                            IsDeleted = false,
                        };
                       await _userTrainingProgressService.CreateUserTrainingProgress(userTrainingProgress);
                    }

                    return View("SuccessPayment");
                }
                else
                {
                    return View("FailurePayment");
                }

            }   
        }
    }
}