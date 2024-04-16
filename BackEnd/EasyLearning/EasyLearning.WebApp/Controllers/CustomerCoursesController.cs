using AutoMapper;
using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Application.Services;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.WebApp.Areas.admin.Models;
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
        public CustomerCoursesController(ICourseService courseService, ICategoryService categoryService,
        ICourseDetailService courseDetailService, IOrderService orderService, IOrderDetailService orderDetailService,
        ICourseEventService courseEventService, ITranningPartService tranningPartService,
        IMapper mapper, IFileService fileService)
        {
            _courseService = courseService;
            _categoryService = categoryService;
            _courseDetailService = courseDetailService;
            _courseEventService = courseEventService;
            _tranningPartService = tranningPartService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _fileService = fileService;
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
                var tranningPart = await _tranningPartService.GetTranningPartByCourse(itemOrderDetail.CoursesId);
                var courseEvent = await _courseEventService.GetEventByCourse(itemOrderDetail.CoursesId);
                listCourseEvent.AddRange(courseEvent.ToList());
                listTranningPart.AddRange(tranningPart.ToList());
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
