using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Application.Services;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.AccessControl;

namespace EasyLearning.WebApp.Controllers
{
    public class EventController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ICourseEventService _courseEventService;
        private readonly ITranningPartService _tranningPartService;
        public EventController (ICourseService courseService, ICourseEventService courseEventService, ITranningPartService tranningPartService)
        {
            _courseService = courseService;
            _courseEventService = courseEventService;
            _tranningPartService = tranningPartService;
        }

        public async Task<IActionResult> Index(string courseId)
        {
            if (courseId == null)
            {
                return NotFound();
            }
            List<CourseEvent> listEvent = new List<CourseEvent>();
            var tranningPartByCoure = await _tranningPartService.GetTranningPartByCourse(courseId);
            tranningPartByCoure.Select(s => s.CourseEvent);
            ViewBag.CourseId = courseId;
            return View(tranningPartByCoure);
        }


    }
}
