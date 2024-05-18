using AutoMapper;
using Azure.Storage.Blobs.Models;
using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Application.Services;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using EasyLearning.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EasyLearning.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICourseService _courseService;
        private readonly ICategoryService _categoryService;
        private readonly ICourseDetailService _courseDetailService;
        private readonly ICourseEventService _courseEventService;
        private readonly ITrainingPartService _tranningPartService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IFileService _fileService;
        private readonly UserRepository _userRepository;
        private readonly IFeedbackService _feedbackService;
        private readonly IShoppingCartItemService _shoppingCartItemService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ICourseService courseService, ICategoryService categoryService,
        ICourseDetailService courseDetailService, IOrderService orderService, IOrderDetailService orderDetailService,
        ICourseEventService courseEventService, ITrainingPartService tranningPartService,
        IMapper mapper, IFileService fileService, UserRepository userRepository, IFeedbackService feedbackService,
        IShoppingCartItemService shoppingCartItemService, IShoppingCartService shoppingCartService,
         RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _courseService = courseService;
            _categoryService = categoryService;
            _courseDetailService = courseDetailService;
            _courseEventService = courseEventService;
            _tranningPartService = tranningPartService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _fileService = fileService;
            _userRepository = userRepository;
            _feedbackService = feedbackService;
            _shoppingCartItemService = shoppingCartItemService;
            _shoppingCartService = shoppingCartService;
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            List<OrderDetail> listOrderDetail = new List<OrderDetail>();
            List<ShoppingCartItem> listShoppingCartItem = new List<ShoppingCartItem>();
           
            var courses = await _courseService.GetAllCourses();
            var categories = await _categoryService.GetAllCategories();
            var courDetails = await _courseDetailService.GetAllCourseDetail();
            var feedbacks = await _feedbackService.GetAllFeedbacks();
            var users = await _userRepository.GetUsersAsync();

            List<ApplicationUser> usersAdmin = (List<ApplicationUser>)await _userManager.GetUsersInRoleAsync("Admin");
            if (!string.IsNullOrEmpty(_userRepository.getCurrrentUser()))
            {
               
                var shoppingCart = await _shoppingCartService.GetShoppingCartByUserIdAsync();
                listShoppingCartItem = await _shoppingCartItemService.GetShoppingCartItemByShopingCart(shoppingCart.Id);
                var orders = await _orderService.GetOrdersByUser();
                
                foreach (var order in orders)
                {
           
                    listOrderDetail.AddRange(await _orderDetailService.GetOrderDetailByOrder(order.Id));
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
                ShoppingCartItems = listShoppingCartItem,
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