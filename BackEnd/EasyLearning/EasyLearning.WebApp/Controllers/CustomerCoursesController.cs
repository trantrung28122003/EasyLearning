using AutoMapper;
using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Application.Services;
using EasyLearning.Infrastructure.Data;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repository;
using EasyLearning.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ITrainingPartService _TrainingPartService;
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
        ICourseEventService courseEventService, ITrainingPartService TrainingPartService,
        IMapper mapper, IFileService fileService, UserRepository userRepository, IFeedbackService feedbackService, EasyLearningDbContext easyLearningDbContext, IShoppingCartItemService shoppingCartItemService, IShoppingCartService shoppingCartService)
        {
            _courseService = courseService;
            _categoryService = categoryService;
            _courseDetailService = courseDetailService;
            _courseEventService = courseEventService;
            _TrainingPartService = TrainingPartService;
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

            var courses = await _courseService.GetAllCourses();
            var categories = await _categoryService.GetAllCategories();
            var coursedetail = await _courseDetailService.GetAllCourseDetail();

            // Tạo ViewModel chứa dữ liệu khóa học, danh mục và chi tiết khóa học
            var coursesByCategory = new CoursesByCategoryViewModel()
            {
                Courses = courses,
                Categories = categories,
                CourseDetails = coursedetail,
                IsSearchResult = !string.IsNullOrEmpty(searchString)
            };

            // Lọc danh sách khóa học theo từ khóa tìm kiếm nếu có
            if (!string.IsNullOrEmpty(searchString))
            {
                // Lấy danh sách các khóa học có tên chứa từ khóa tìm kiếm
                coursesByCategory.Courses = courses.Where(p => p.CoursesName.ToLower().Contains(searchString.ToLower())).ToList(); 
            }
            else
            {
                coursesByCategory.Courses = courses;
            }
            
            // Trả về View với danh sách khóa học đã lọc
            return View(coursesByCategory);
        }
        public async Task<IActionResult> DetailCourse(string courseId)
        {
            List<OrderDetail> listOrderDetail = new List<OrderDetail>();
            var shoppingCart = await _shoppingCartService.GetShoppingCartByUserIdAsync();
            var shoppingCartItem = await _shoppingCartItemService.GetShoppingCartItemByShoppingCart(shoppingCart.Id);
            var course = await _courseService.GetCourseById(courseId);
            var TrainingParts = await _TrainingPartService.GetTrainingPartByCourse(courseId);
            var getFeedbackbyCourse = await _feedbackService.GetFeedbacksByCourseId(courseId);
            var getUsers = await _userRepository.GetUsersAsync();
            var orders = await _orderService.GetOrdersByUser();
            foreach (var order in orders)
            {
                listOrderDetail = await _orderDetailService.GetOrderDetailByOrder(order.Id);
            }
            var customerCourseViewModel = new CustomerCourseViewModel()
            {
                Course = course,
                ShoppingCartItems = shoppingCartItem,
                TrainingParts = TrainingParts,
                Feedbacks = getFeedbackbyCourse,
                Users = getUsers,
                OrderDetails = listOrderDetail,
            };
            return View(customerCourseViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> AddToFeedback(string courseId,  int rating, string content)
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
  
            var orders = await _orderService.GetOrdersByUser();
            foreach(var order in orders) 
            {
                listOrderDetail.AddRange( await _orderDetailService.GetOrderDetailByOrder(order.Id));
            }
            foreach (var itemOrderDetail in listOrderDetail)
            {
                var TrainingParts = await _TrainingPartService.GetTrainingPartByCourse(itemOrderDetail.CoursesId);
                var courseEvents = await _courseEventService.GetEventByCourse(itemOrderDetail.CoursesId);
                listCourseEvent.AddRange(courseEvents.ToList());
                listTrainingPart.AddRange(TrainingParts.ToList());
                courses.AddRange(await _courseService.GetCourseByOrderDetail(itemOrderDetail.Id));
            }
            var customerCourseViewModel = new CustomerCourseViewModel
            {
                Courses = courses,
                CourseEvents = listCourseEvent,
                TrainingParts = listTrainingPart,
            };
            return View(customerCourseViewModel);
        }
    }
}
