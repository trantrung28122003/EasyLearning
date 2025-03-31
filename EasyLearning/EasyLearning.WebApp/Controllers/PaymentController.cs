using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Application.Services;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using EasyLearning.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.WebSockets;

namespace EasyLearning.WebApp.Areas.admin.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly UserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IShoppingCartItemService _shoppingCartItemService;
        private readonly ICourseService _courseService;
        private readonly IUserTrainingProgressService _userTrainingProgressService;
        private readonly ITrainingPartService _trainingPartService;
        private readonly IEmailService _emailService;

        public PaymentController(IPaymentService paymentService, UserRepository userRepository, 
            IOrderDetailService orderDetailService, IOrderService orderService, IShoppingCartService shoppingCartService,
            IShoppingCartItemService shoppingCartItemService, ICourseService courseService, IUserTrainingProgressService userTrainingProgressService,
            ITrainingPartService trainingPartService, IEmailService emailService)
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
            _emailService = emailService;
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
                string notes = "";
                OrderViewModel orderViewModel = JsonConvert.DeserializeObject<OrderViewModel>(orderJson);
                decimal decimalAmount = orderViewModel.OrderTotalPrice;
                string amountString = decimalAmount.ToString().Replace(".", "");
               
                if (orderViewModel.OrderNotes != null)
                {
                    notes = orderViewModel.OrderNotes.ToString();
                }
                var url = await _paymentService.doPayment(amountString, notes);
                return Redirect(url);
            }
        }

        public async Task<ActionResult> ConfirmPaymentClient(MomoResult result)
        {
            string orderJson = TempData["OrderViewModelJson"] as string;
            if (string.IsNullOrEmpty(orderJson))
            {
                
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

                    
                    
                    foreach( var itemCourse in orderViewModel.listCourse)
                    {
                        listTrainingPart.AddRange(await _trainingPartService.GetTrainingPartByCourse(itemCourse.Id));
                        var course = await _courseService.GetCourseById(itemCourse.Id);
                        if (course != null)
                        {
                            course.RegisteredUsers++;
                            await _courseService.UpdateCourse(course);
                        }
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
                    var currentUserId = _userRepository.getCurrrentUser();
                    ApplicationUser currentUser = null;
                    foreach (var user in await _userRepository.GetUsersAsync())
                    {
                        if(user.Id == currentUserId)
                        {
                            currentUser = user; 
                            break;
                        }
                    }
                    var toEmail = currentUser.Email;
                    string subject = "Thanh toán thành công trên trang eLearning";
                    string customerName = currentUser.FullName.ToString();
                    var totalAmount = orderViewModel.OrderTotalPrice.ToString();
                    var totalCourses = orderViewModel.OrderTotalPrice.ToString();
                    var authorizationCode = result.orderId;
                    var orderDate = DateTime.Now;
                    string orderDateString = orderDate.ToString("yyyy-MM-dd HH:mm:ss");
                    List<string> courseNameList = new List<string>();
                    foreach(var itemCourse in orderViewModel.listCourse)
                    {
                        courseNameList.Add(itemCourse.CoursesName);
                    }    
                    await _emailService.SendEmailPayMentAsync(toEmail, subject, customerName, totalAmount, totalCourses, authorizationCode, orderDateString, courseNameList);
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