using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyLearning.WebApp.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class TrainingPartController : Controller
    {
        private readonly ITrainingPartService _TrainingPartService;
        private readonly ICourseEventService _courseEventService;

        public TrainingPartController(ITrainingPartService TrainingPartService, ICourseEventService courseEventService)
        {
            _TrainingPartService = TrainingPartService;
            _courseEventService = courseEventService;
        }

        public async Task<IActionResult> Index(string courseId)
        {
            if (courseId == null)
            {
                return NotFound();
            }
            var TrainingParts = await _TrainingPartService.GetTrainingPartByCourse(courseId);
            ViewBag.CourseId = courseId;
           
            return View(TrainingParts);
        }

        public async Task<IActionResult> Create(string courseId)
        {
           
            var courseEventbyCourse = await _courseEventService.GetEventByCourse(courseId);
            ViewBag.CourseId = courseId;
            ViewBag.CourseEvent = new SelectList(courseEventbyCourse, "Id", "EventName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrainingPart TrainingPart)
        {
            if (ModelState.IsValid)
            {
                TrainingPart.DateChange = DateTime.Now;
                TrainingPart.DateCreate = DateTime.Now;
                TrainingPart.ChangedBy = "User";
                
                await _TrainingPartService.CreateTrainingPart(TrainingPart);
                return RedirectToAction("Index", "TrainingPart", new { courseId = TrainingPart.CoursesId });
            }
            return View(TrainingPart);
        }

        public async Task<IActionResult> Update(string id)
        {
            var TrainingPart = await _TrainingPartService.GetTrainingPartById(id);
            if (TrainingPart == null)
            {
                return NotFound();
            }

            return View(TrainingPart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TrainingPart TrainingPart, string id)
        {
            if (id != TrainingPart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TrainingPart.DateChange = DateTime.Now;
                    TrainingPart.ChangedBy = "User";
                    await _TrainingPartService.UpdateTrainingPart(TrainingPart);
                }
                catch (Exception)
                {

                }
                return RedirectToAction("Index", "TrainingPart", new { courseId = TrainingPart.CoursesId });
            }
            return View(TrainingPart);
        }

        public async Task<IActionResult> Details(string id)
        {
            var TrainingPart = await _TrainingPartService.GetTrainingPartById(id);
            if (TrainingPart == null)
            {
                return NotFound();
            }
            return View(TrainingPart);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var TrainingParts = await _TrainingPartService.GetTrainingPartById(id);
            if (TrainingParts == null)
            {
                return NotFound();
            }
            return View(TrainingParts);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var TrainingPart = await _TrainingPartService.GetTrainingPartById(id);
            if (TrainingPart == null)
            {
                return NotFound();
            }
            try
            {
                await _TrainingPartService.DeleteTrainingPart(TrainingPart);
                return RedirectToAction("Index", "TrainingPart", new { courseId = TrainingPart.CoursesId });
            }
            catch (Exception)
            {
                // Handle exception
                return RedirectToAction("Index", "TrainingPart", new { courseId = TrainingPart.CoursesId });
            }
        }
    }
}
