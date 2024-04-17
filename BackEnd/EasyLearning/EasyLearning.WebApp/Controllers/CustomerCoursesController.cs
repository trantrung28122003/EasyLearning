﻿using AutoMapper;
using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Application.Services;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using EasyLearning.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

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
        private readonly IShoppingCartItemService _shoppingCartItemService;
        private readonly IShoppingCartService _shoppingCartService;
        public CustomerCoursesController(ICourseService courseService, ICategoryService categoryService,
        ICourseDetailService courseDetailService, IOrderService orderService, IOrderDetailService orderDetailService,
        ICourseEventService courseEventService, ITranningPartService tranningPartService,
        IMapper mapper, IFileService fileService, UserRepository userRepository, IFeedbackService feedbackService,
        IShoppingCartItemService shoppingCartItemService, IShoppingCartService shoppingCartService)
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
        }

        public async Task<IActionResult> ListCourse()
        {

           var course = await _courseService.GetAllCourses();
           var categories = await _categoryService.GetAllCategories();
           var coursedetail = await _courseDetailService.GetAllCourseDetail();
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
            List<OrderDetail> listOrderDetail = new List<OrderDetail>();
            var shoppingCart = await _shoppingCartService.GetShoppingCartByUserIdAsync();
            var shoppingCartItem = await _shoppingCartItemService.GetShoppingCartItemByShopingCart(shoppingCart.Id);
            var course = await _courseService.GetCourseById(courseId);
            var tranningParts = await _tranningPartService.GetTranningPartByCourse(courseId);
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
                TranningParts = tranningParts,
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
                courses.AddRange(await _courseService.GetCoursesByOrderDetail(itemOrderDetail.Id));
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
