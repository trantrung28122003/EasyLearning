using AutoMapper;
using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Application.Services;
using EasyLearning.Infrastructure.Data;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
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
        private readonly ITranningPartService _tranningPartService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IFileService _fileService;
        private readonly UserRepository _userRepository;
        private readonly IFeedbackService _feedbackService;
        private readonly EasyLearningDbContext _easyLearningDbContext;
        public CustomerCoursesController(ICourseService courseService, ICategoryService categoryService,
        ICourseDetailService courseDetailService, IOrderService orderService, IOrderDetailService orderDetailService,
        ICourseEventService courseEventService, ITranningPartService tranningPartService,
        IMapper mapper, IFileService fileService, UserRepository userRepository, IFeedbackService feedbackService, EasyLearningDbContext easyLearningDbContext)
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
            _easyLearningDbContext = easyLearningDbContext;
        }

        public async Task<IActionResult> ListCourse(string searchString)
        {
            
           var course = await _courseService.GetAllCourses();
           var categories = await _categoryService.GetAllCategories();
           var coursedetail = await _courseDetailService.GetAllCourseDetail();
           
            /*var courses = from p in _easyLearningDbContext.Courses select p; */
            if(!string.IsNullOrEmpty(searchString) )
            {
                course = course.Where(p => p.CoursesName.Contains(searchString)).ToList();
            }
            /*var courses = _easyLearningDbContext.Courses.AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                courses = courses.Where(p => p.CoursesName.Contains(searchString));
            }*/
            var coursesByCategory = new CoursesByCategoryViewModel()
            {
                Courses = course,   
                Categories = categories,
                CourseDetails = coursedetail,
            };
            return View(coursesByCategory);
           
        }

        
        public async Task<IActionResult> DetailCourse(string courseId)
        {
            var course = await _courseService.GetCourseById(courseId);
            var tranningParts = await _tranningPartService.GetTranningPartByCourse(courseId);
            var getFeedbackbyCourse = await _feedbackService.GetFeedbacksByCourseId(courseId);
          
            var customerCourseViewModel = new CustomerCourseViewModel()
            {
                Course = course,
                TranningParts = tranningParts,
                Feedbacks = getFeedbackbyCourse,
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

        public async Task<IActionResult> index()
        {
            List<Course> courses = new List<Course>();
            List<CourseEvent> listCourseEvent = new List<CourseEvent>();
            List<TranningPart> listTranningPart = new List<TranningPart>();
            List<OrderDetail> listOrderDetail = new List<OrderDetail>();
  
            var orders = await _orderService.GetOrdersByUser();
            foreach(var order in orders) 
            {
                listOrderDetail = await _orderDetailService.GetOrderDetailByOrder(order.Id);
            }
            foreach (var itemOrderDetail in listOrderDetail)
            {
                var tranningParts = await _tranningPartService.GetTranningPartByCourse(itemOrderDetail.CoursesId);
                var courseEvents = await _courseEventService.GetEventByCourse(itemOrderDetail.CoursesId);
                listCourseEvent.AddRange(courseEvents.ToList());
                listTranningPart.AddRange(tranningParts.ToList());
                courses.AddRange(await _courseService.GetCourseByOrderDetail(itemOrderDetail.Id));
            }
            var customerCourseViewModel = new CustomerCourseViewModel
            {
                Courses = courses,
                CourseEvents = listCourseEvent,
                TranningParts = listTranningPart,
            };
            return View(customerCourseViewModel);
        }
    }
}
