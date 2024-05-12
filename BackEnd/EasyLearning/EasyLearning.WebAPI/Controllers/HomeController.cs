using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Application.Services;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repository;
using EasyLearning.WebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyLearning.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICourseService _courseService;
        private readonly ICategoryService _categoryService;
        private readonly ICourseDetailService _courseDetailService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly UserRepository _userRepository;
        private readonly IFeedbackService _feedbackService;
        private readonly IShoppingCartItemService _shoppingCartItemService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ICourseService courseService, ICategoryService categoryService,
        ICourseDetailService courseDetailService, IOrderService orderService, IOrderDetailService orderDetailService, UserRepository userRepository,
        IFeedbackService feedbackService, IShoppingCartItemService shoppingCartItemService, ILogger<HomeController> logger,
        IShoppingCartService shoppingCartService, UserManager<ApplicationUser> userManager)
        {
            _courseService = courseService;
            _categoryService = categoryService;
            _courseDetailService = courseDetailService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _userRepository = userRepository;
            _feedbackService = feedbackService;
            _shoppingCartItemService = shoppingCartItemService;
            _shoppingCartService = shoppingCartService;
            _userManager = userManager;
            _logger = logger;   
        }


        public async Task<IActionResult> Index()
        {
            List<OrderDetail> listOrderDetail = new List<OrderDetail>();
            List<ShoppingCartItem> shoppingCartItem = new List<ShoppingCartItem>();
           

            var courses = await _courseService.GetAllCourses();
            var categories = await _categoryService.GetAllCategories();
            var courDetails = await _courseDetailService.GetAllCourseDetail();
            var feedbacks = await _feedbackService.GetAllFeedbacks();


            var users = await _userRepository.GetUsersAsync();
            List<ApplicationUser> usersAdmin = (List<ApplicationUser>)await _userManager.GetUsersInRoleAsync("Admin");
            if (!string.IsNullOrEmpty(_userRepository.getCurrrentUser()))
            {
               
                var shoppingCart = await _shoppingCartService.GetShoppingCartByUserIdAsync();
                shoppingCartItem = await _shoppingCartItemService.GetShoppingCartItemByShoppingCart(shoppingCart.Id);
                var orders = await _orderService.GetOrdersByUser();
                
                foreach (var order in orders)
                {
                    listOrderDetail = await _orderDetailService.GetOrderDetailByOrder(order.Id);
                }
            }
            else
            {
                
            }
            var customerCourseViewModel = new CustomerCourseViewModel()
            {
                Courses = courses,
                Categories = categories,
                CourseDetails = courDetails,
                Feedbacks = feedbacks,
                ShoppingCartItems = shoppingCartItem,
                OrderDetails = listOrderDetail,
                Users = users,
                UsersAdmin = usersAdmin
            };
            return View(customerCourseViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        /*[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}