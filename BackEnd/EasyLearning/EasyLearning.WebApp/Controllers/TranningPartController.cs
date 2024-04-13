using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EasyLearning.WebApp.Controllers
{
    public class TranningPartController : Controller
    {
        private readonly ITranningPartService _tranningPartService;

        public TranningPartController(ITranningPartService tranningPartService)
        {
            _tranningPartService = tranningPartService;
        }

        public async Task<IActionResult> Index(string courseId)
        {
            var tranningParts = await _tranningPartService.GetTranningPartById(courseId);
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
                await _tranningPartService.CreateTranningPart(tranningPart);
                return RedirectToAction(nameof(Index));
            }
            return View(tranningPart);
        }
       

    }
}
