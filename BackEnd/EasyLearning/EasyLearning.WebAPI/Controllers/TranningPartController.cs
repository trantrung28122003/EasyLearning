using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyLearning.WebAPI.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class TranningPartController : Controller
    {
        private readonly ITranningPartService _tranningPartService;

        public TranningPartController(ITranningPartService tranningPartService)
        {
            _tranningPartService = tranningPartService;
        }

        public async Task<IActionResult> Index(string courseId)
        {
            if (courseId == null)
            {
                return NotFound();
            }
            var tranningParts = await _tranningPartService.GetTranningPartByCourse(courseId);
            ViewBag.CourseId = courseId;
            return View(tranningParts);
        }

        public async Task<IActionResult> Create(string courseId)
        {
            ViewBag.CourseId = courseId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TranningPart tranningPart)
        {
            if (ModelState.IsValid)
            {
                tranningPart.DateCreate = DateTime.Now;
                tranningPart.ChangedBy = "User";

                await _tranningPartService.CreateTranningPart(tranningPart);
                return RedirectToAction("Index", "TranningPart", new { courseId = tranningPart.CoursesId });
            }
            return View(tranningPart);
        }

        public async Task<IActionResult> Update(string id)
        {
            var tranningPart = await _tranningPartService.GetTranningPartById(id);
            if (tranningPart == null)
            {
                return NotFound();
            }

            return View(tranningPart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TranningPart tranningPart, string id)
        {
            if (id != tranningPart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    tranningPart.DateChange = DateTime.Now;
                    tranningPart.ChangedBy = "User";
                    await _tranningPartService.UpdateTranningPart(tranningPart);
                }
                catch (Exception)
                {

                }
                return RedirectToAction("Index", "TranningPart", new { courseId = tranningPart.CoursesId });
            }
            return View(tranningPart);
        }

        public async Task<IActionResult> Details(string id)
        {
            var tranningPart = await _tranningPartService.GetTranningPartById(id);
            if (tranningPart == null)
            {
                return NotFound();
            }
            return View(tranningPart);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var tranningParts = await _tranningPartService.GetTranningPartById(id);
            if (tranningParts == null)
            {
                return NotFound();
            }
            return View(tranningParts);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tranningPart = await _tranningPartService.GetTranningPartById(id);
            if (tranningPart == null)
            {
                return NotFound();
            }
            try
            {
                await _tranningPartService.DeleteTranningPart(tranningPart);
                return RedirectToAction("Index", "TranningPart", new { courseId = tranningPart.CoursesId });
            }
            catch (Exception)
            {
                // Handle exception
                return RedirectToAction("Index", "TranningPart", new { courseId = tranningPart.CoursesId });
            }
        }
    }
}
