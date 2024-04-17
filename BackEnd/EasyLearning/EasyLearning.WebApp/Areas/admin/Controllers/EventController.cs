using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Application.Services;
using EasyLearning.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyLearning.WebApp.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class EventController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ICourseEventService _courseEventService;
        private readonly ITranningPartService _tranningPartService;
        public EventController(ICourseService courseService, ICourseEventService courseEventService, ITranningPartService tranningPartService)
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
            var eventByCourse = await _courseEventService.GetEventByCourse(courseId);
            ViewBag.CourseId = courseId;
            return View(eventByCourse);
        }

        public async Task<IActionResult> Create(string courseId)
        {
            if (courseId == null)
            {
                return NotFound();
            }
            var tranningParts = await _tranningPartService.GetTranningPartWithoutEventIdAndCourse(courseId);
            ViewBag.CourseId = courseId;
            ViewBag.TranningParts = new SelectList(tranningParts, "Id", "TranningPartName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventViewModel eventViewModel)
        {
            if (ModelState.IsValid)
            {
                var courseEvent = new CourseEvent
                {
                    EventName = eventViewModel.EventName,
                    EventType = (EnventType)eventViewModel.EventType,
                    Location = eventViewModel.Location,
                    DateStart = eventViewModel.DateStart,
                    DateEnd = eventViewModel.DateEnd,
                    DateChange = DateTime.Now,
                    ChangedBy = "user",
                };
                await _courseEventService.CreateEvent(courseEvent);
                await _tranningPartService.UpdateTranningPartWithEvent(eventViewModel.TranningPartId, courseEvent.Id);
                return RedirectToAction("Index", "Event", new { courseId = eventViewModel.CourseId});
            }
            return View(eventViewModel);
        }

        public async Task<IActionResult> Update(string id, string courseId)
        {
            var courseEvent = await _courseEventService.GetCourseEventById(id);

            if (courseEvent == null)
            {
                return NotFound();
            }
            var tranningPartIds = await _tranningPartService.GetTranningPartByEvent(id);

            var tranningParts = await _tranningPartService.GetTranningPartByCourse(courseId);

            ViewBag.CourseId = courseId;

            ViewBag.TranningParts = new SelectList(tranningParts, "Id", "TranningPartName", tranningPartIds);

            var eventViewModel = new EventViewModel
            {
                EventName = courseEvent.EventName,
                EventType = (int)courseEvent.EventType,
                Location = courseEvent.Location,
                DateStart = courseEvent.DateStart,
                DateEnd = courseEvent.DateEnd,
                DateChange = DateTime.Now,
                ChangedBy = "user",
                CourseId = courseId,
            };

            return View(eventViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string id, EventViewModel eventViewModel)
        {
            if (ModelState.IsValid)
            {
                var courseEvent = await _courseEventService.GetCourseEventById(id);
                if (courseEvent == null)
                {
                    return NotFound();
                }
                courseEvent.EventName = eventViewModel.EventName;
                courseEvent.EventType = (EnventType)eventViewModel.EventType;
                courseEvent.Location = eventViewModel.Location;
                courseEvent.DateStart = eventViewModel.DateStart;
                courseEvent.DateEnd = eventViewModel.DateEnd;
                courseEvent.DateChange = DateTime.Now;
                courseEvent.ChangedBy = "user";

                await _courseEventService.UpdateEvent(courseEvent);
                return RedirectToAction("Index", "Event", new { courseId = eventViewModel.CourseId });
            }
            return View(eventViewModel);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseEvent = await _courseEventService.GetCourseEventById(id);

            if (courseEvent == null)
            {
                return NotFound();
            }
            return View(courseEvent);
        }
       
   
        public async Task<IActionResult> Delete(string id)
        {
            var courseEvent = await _courseEventService.GetCourseEventById(id);
            if (courseEvent == null)
            {
                return NotFound();
            }
            return View(courseEvent);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseEvent = await _courseEventService.GetCourseEventById(id);

            if (courseEvent == null)
            {
                return NotFound();
            }
            await _tranningPartService.UpdateCourseEventIdToNull(id);
            await _courseEventService.DeleteEvent(courseEvent);
            return RedirectToAction("Index", "Event");
         
        }
    }
}
