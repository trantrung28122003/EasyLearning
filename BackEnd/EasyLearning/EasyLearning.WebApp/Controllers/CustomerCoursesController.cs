using AutoMapper;
using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Application.Services;
using EasyLearning.Infrastructure.Data;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using EasyLearning.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EasyLearning.WebApp.Controllers
{
    public class CustomerCoursesController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ICategoryService _categoryService;
        private readonly ICourseDetailService _courseDetailService;
        private readonly ICourseEventService _courseEventService;
        private readonly ITrainingPartService _trainingPartService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IFileService _fileService;
        private readonly UserRepository _userRepository;
        private readonly IFeedbackService _feedbackService;
        private readonly EasyLearningDbContext _easyLearningDbContext;
        private readonly IShoppingCartItemService _shoppingCartItemService;
        private readonly IShoppingCartService _shoppingCartService;
        public CustomerCoursesController(ICourseService courseService, ICategoryService categoryService,
        ICourseDetailService courseDetailService, IOrderService orderService, IOrderDetailService orderDetailService,
        ICourseEventService courseEventService, ITrainingPartService trainingPartService,
        IMapper mapper, IFileService fileService, UserRepository userRepository, IFeedbackService feedbackService, EasyLearningDbContext easyLearningDbContext, IShoppingCartItemService shoppingCartItemService, IShoppingCartService shoppingCartService)
        {
            _courseService = courseService;
            _categoryService = categoryService;
            _courseDetailService = courseDetailService;
            _courseEventService = courseEventService;
            _trainingPartService = trainingPartService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _fileService = fileService;
            _userRepository = userRepository;
            _feedbackService = feedbackService;
            _easyLearningDbContext = easyLearningDbContext;
            _shoppingCartItemService = shoppingCartItemService;
            _shoppingCartService = shoppingCartService;
        }

        public async Task<IActionResult> ListCourse(string searchString)
        {
            List<OrderDetail> listOrderDetail = new List<OrderDetail>();
            List<ShoppingCartItem> listShoppingCartItem = new List<ShoppingCartItem>();

            var courses = await _courseService.GetAllCourses();
            var categories = await _categoryService.GetAllCategories();
            var coursedetails = await _courseDetailService.GetAllCourseDetail();

            if (!string.IsNullOrEmpty(_userRepository.getCurrrentUser()))
            {

                var shoppingCart = await _shoppingCartService.GetShoppingCartByUserIdAsync();
                listShoppingCartItem = await _shoppingCartItemService.GetShoppingCartItemByShopingCart(shoppingCart.Id);
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
                CourseDetails = coursedetails,
                ShoppingCartItems = listShoppingCartItem,
                OrderDetails = listOrderDetail,
                IsSearchResult = !string.IsNullOrEmpty(searchString)
            };
            if (!string.IsNullOrEmpty(searchString))
            {

                customerCourseViewModel.Courses = courses.Where(p => p.CoursesName.ToLower().Contains(searchString.ToLower())).ToList();
            }
            else
            {
                customerCourseViewModel.Courses = courses;

            }

            return View(customerCourseViewModel);
        }

        public async Task<IActionResult> ListCourseByCategory(string categoryId)
        {
            var courses = await _courseService.GetAllCourses();
            var coursedetail = await _courseDetailService.GetAllCourseDetail();
            var category = await _categoryService.GetCategoryById(categoryId);
            var coursesByCategory = new CustomerCourseViewModel()
            {
                Courses = courses,
                CourseDetails = coursedetail,
                Category = category
            };
            return View(coursesByCategory);
        }
        public async Task<IActionResult> DetailCourse(string courseId)
        {
            List<OrderDetail> listOrderDetail = new List<OrderDetail>();
            var shoppingCart = await _shoppingCartService.GetShoppingCartByUserIdAsync();
            var shoppingCartItem = await _shoppingCartItemService.GetShoppingCartItemByShopingCart(shoppingCart.Id);
            var course = await _courseService.GetCourseById(courseId);
            var trainingParts = await _trainingPartService.GetTrainingPartByCourse(courseId);
            var getFeedbackbyCourse = await _feedbackService.GetFeedbacksByCourseId(courseId);
            var getUsers = await _userRepository.GetUsersAsync();
            var orders = await _orderService.GetOrdersByUser();
            var currentUserId = _userRepository.getCurrrentUser();
            bool hasBoughtCourse = await _orderDetailService.CheckIfUserHasBoughtCourse(currentUserId, courseId);

            foreach (var itemFeedback in getFeedbackbyCourse)
            {
                if (currentUserId == itemFeedback.FeedbackUserId)
                {
                    hasBoughtCourse = false;
                    break;
                }
            }
            foreach (var order in orders)
            {
                listOrderDetail = await _orderDetailService.GetOrderDetailByOrder(order.Id);
            }


            var customerCourseViewModel = new CustomerCourseViewModel()
            {
                Course = course,
                ShoppingCartItems = shoppingCartItem,
                TrainingParts = trainingParts,
                Feedbacks = getFeedbackbyCourse,
                Users = getUsers,
                OrderDetails = listOrderDetail,
                HasBoughtCourse = hasBoughtCourse,
                currentUserId = currentUserId,
            };
            return View(customerCourseViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> AddToFeedback(string courseId, int rating, string content)
        {
            var userId = _userRepository.getCurrrentUser();
            var feeedBack = new Feedback()
            {
                FeedbackUserId = userId,
                CoursesId = courseId,
                FeedbackRating = rating,
                FeedbackContent = content,
                DateCreate = DateTime.Now,
                DateChange = DateTime.Now,
                ChangedBy = userId,
                IsDeleted = false,
            };
            await _feedbackService.CreateFeedback(feeedBack);
            return RedirectToAction("DetailCourse", "CustomerCourses", new { courseId = courseId });

        }

        public async Task<IActionResult> EventSchedule()
        {
            List<Course> courses = new List<Course>();
            List<CourseEvent> listCourseEvent = new List<CourseEvent>();
            List<TrainingPart> listTrainingPart = new List<TrainingPart>();
            List<OrderDetail> listOrderDetail = new List<OrderDetail>();
            var currentUserId = _userRepository.getCurrrentUser();
            var orders = await _orderService.GetAllOrders();
            var ordersByUser = await _orderService.GetOrdersByUser();
            foreach (var order in ordersByUser)
            {
                listOrderDetail.AddRange(await _orderDetailService.GetOrderDetailByOrder(order.Id));
            }
            foreach (var itemOrderDetail in listOrderDetail)
            {
                var trainingParts = await _trainingPartService.GetTrainingPartByCourse(itemOrderDetail.CoursesId);
                var courseEvents = await _courseEventService.GetEventByCourse(itemOrderDetail.CoursesId);
                listCourseEvent.AddRange(courseEvents.ToList());
                listTrainingPart.AddRange(trainingParts.ToList());
                courses.AddRange(await _courseService.GetCourseByOrderDetail(itemOrderDetail.Id));
            }
            var customerCourseViewModel = new CustomerCourseViewModel
            {
                currentUserId = currentUserId,
                Courses = courses,
                CourseEvents = listCourseEvent,
                TrainingParts = listTrainingPart,
                Orders = orders,
            };
            return View(customerCourseViewModel);
        }

        public async Task<IActionResult> OnlineEventSchedule()
        {
            List<Course> courses = new List<Course>();
            List<TrainingPart> listTrainingPart = new List<TrainingPart>();
            List<OrderDetail> listOrderDetail = new List<OrderDetail>();
            var currentUserId = _userRepository.getCurrrentUser();
            var orders = await _orderService.GetAllOrders();
            var ordersByUser = await _orderService.GetOrdersByUser();
            foreach (var order in ordersByUser)
            {
                listOrderDetail.AddRange(await _orderDetailService.GetOrderDetailByOrder(order.Id));
            }
            foreach (var itemOrderDetail in listOrderDetail)
            {
                var trainingParts = await _trainingPartService.GetTrainingPartByCourse(itemOrderDetail.CoursesId);
                var courseEvents = await _courseEventService.GetEventByCourse(itemOrderDetail.CoursesId);

                listTrainingPart.AddRange(trainingParts.ToList());
                courses.AddRange(await _courseService.GetCourseByOrderDetail(itemOrderDetail.Id));
            }
            var customerCourseViewModel = new CustomerCourseViewModel
            {
                currentUserId = currentUserId,
                Courses = courses,
                TrainingParts = listTrainingPart,
                Orders = orders,
            };
            return View(customerCourseViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> TrackVideoEvent(string videoName, string percentageWatched)
        {
            try
            {
                double percentage = double.Parse(percentageWatched);
                if (percentage >= 80)
                {
                    var videoname1 = videoName;

                    return RedirectToAction("Index", "Home");
                }
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Lỗi: {ex.Message}");
            }
        }
    }
}
