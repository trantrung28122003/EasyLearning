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
        private readonly ITranningPartService _tranningPartService;
        private readonly ICourseEventService _courseEventService;
        private readonly IFileService _fileService;
        public CustomerCoursesController(ICourseService courseService, ICategoryService categoryService,
        ICourseDetailService courseDetailService, ITranningPartService tranningPartService,
        ICourseEventService courseEventService,
        IMapper mapper, IFileService fileService)
        {
            _courseService = courseService;
            _categoryService = categoryService;
            _courseDetailService = courseDetailService;
            _tranningPartService = tranningPartService;
            _courseEventService = courseEventService;
            _fileService = fileService;
        }
        public async Task<IActionResult> index()
        {
            /*var courses = await _courseService.GetcourseByUser();
            
            List<TranningPart> listTranningPart = new List<TranningPart>();
            List<CourseEvent> listCourseEvent = new List<CourseEvent>();
            foreach (var course in courses)
            {
                var tranningPart = await _tranningPartService.GetTranningPartByCourse(course.Id);
                var courseEvent = await _courseEventService.GetEventByCourse(course.Id);
                listCourseEvent = courseEvent.ToList();
                listTranningPart = tranningPart.ToList();
            }    
            var customerCourseViewModel = new CustomerCourseViewModel
            {
               Courses = courses,
                CourseEvents = listCourseEvent,
                TranningParts = listTranningPart,
            };
            return View(customerCourseViewModel);*/
            // e trung dang lam sai 
            return View();
        }
    }
}
