using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Application.Services;
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

        public async Task<IActionResult> Index()
        {
            var events = await _courseEventService.GetAllCourseEvents();
            return View(events);
        }

        public IActionResult Create(string courseId)
        {
            ViewBag.CourseId = courseId;    
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventViewModel model)
        {
                var newEvent = new CourseEvent
                {
                    EventName = model.EventName,
                    EventType = (EnventType)model.EventType,
                    Location = model.Location,
                    DateStart = model.DateStart,
                    DateEnd = model.DateEnd,
                    DateCreate = DateTime.Now,
                    DateChange = DateTime.Now,
                    ChangedBy = "User1"
                };
                await _courseEventService.CreateEvent(newEvent);

                if (model.TranningParts != null && model.TranningParts.Any())
                {
                    foreach (var tranningPartModel in model.TranningParts)
                    {
                        var tranningPart = new TranningPart
                        {
                            TranningPartName = tranningPartModel.TranningPartName,
                            StartTime = tranningPartModel.StartTime,
                            EndTime = tranningPartModel.EndTime,
                            Description = tranningPartModel.Description,
                            DateCreate = DateTime.Now,
                            DateChange = DateTime.Now,
                            ChangedBy ="User",
                            EventId = newEvent.Id, 
                            CoursesId = model.CourseId 
                        };
                        await _tranningPartService.CreateTranningPart(tranningPart);
                    }
                }
                return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditTranningPart(string eventId)
        {
            var tranningParts = await _tranningPartService.GetTranningPartById(eventId);
            return View(tranningParts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTranningPart(string eventId, List<TranningPart> tranningParts)
        {
            if (ModelState.IsValid)
            {
                foreach (var tranningPart in tranningParts)
                {
                    await _tranningPartService.UpdateTranningPart(tranningPart);
                }
                return RedirectToAction("Details", new { id = eventId });
            }
            return View(tranningParts);
        }
    }
}
