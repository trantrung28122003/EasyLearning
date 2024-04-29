using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Application.Services;
using EasyLearning.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyLearning.WebAPI.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class EventController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ICourseEventService _courseEventService;
        private readonly ITrainingPartService _TrainingPartService;
        public EventController(ICourseService courseService, ICourseEventService courseEventService, ITrainingPartService TrainingPartService)
        {
            _courseService = courseService;
            _courseEventService = courseEventService;
            _TrainingPartService = TrainingPartService;
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
            var TrainingParts = await _TrainingPartService.GetTrainingPartWithoutEventIdAndCourse(courseId);
            ViewBag.CourseId = courseId;
            ViewBag.TrainingParts = new SelectList(TrainingParts, "Id", "TrainingPartName");
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
                await _TrainingPartService.UpdateTrainingPartWithEvent(eventViewModel.TrainingPartId, courseEvent.Id);
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
            var TrainingPartIds = await _TrainingPartService.GetTrainingPartByEvent(id);

            var TrainingParts = await _TrainingPartService.GetTrainingPartByCourse(courseId);

            ViewBag.CourseId = courseId;

            ViewBag.TrainingParts = new SelectList(TrainingParts, "Id", "TrainingPartName", TrainingPartIds);

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
            await _TrainingPartService.UpdateCourseEventIdToNull(id);
            await _courseEventService.DeleteEvent(courseEvent);
            return RedirectToAction("Index", "Course");

        }
    }
}
