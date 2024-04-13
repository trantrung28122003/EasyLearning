using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Application.Services;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.AccessControl;

namespace EasyLearning.WebApp.Areas.admin.Controllers
{
    [Area("admin")]
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
            var tranningParts = await _tranningPartService.GetTranningPartWithoutEventId();
            ViewBag.CourseId = courseId;
            ViewBag.TranningParts = new SelectList(tranningParts, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventViewModel eventViewModel)
        {
            if (ModelState.IsValid)
            {
                var newEventViewModel = new EventViewModel
                {
                    EventName = eventViewModel.EventName,
                    EventType = eventViewModel.EventType,
                    Location = eventViewModel.Location,
                    DateStart = eventViewModel.DateStart,
                    DateEnd = eventViewModel.DateEnd,
                    DateChange = DateTime.Now,
                    ChangedBy = "user",
                    TranningPartId = eventViewModel.TranningPartId,
                };
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

                // Cập nhật TranningPartId trong bảng Tranning với sự kiện mới được tạo
                await _tranningPartService.UpdateTranningPartWithEvent(newEventViewModel.TranningPartId, courseEvent.Id);

                // Chuyển hướng đến trang chính sau khi tạo thành công
                return RedirectToAction("Index", "Home");
            }

            // Nếu dữ liệu không hợp lệ, hiển thị lại form với thông báo lỗi
            return View(eventViewModel);
        }

    }
}
