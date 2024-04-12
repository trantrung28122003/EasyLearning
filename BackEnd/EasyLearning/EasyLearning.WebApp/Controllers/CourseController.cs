using EasyLearning.Application.Services;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using EasyLearning.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyLearning.WebApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ICategoryService _categoryService;
        private readonly ICourseDetailService _courseDetailService;
        public CourseController(ICourseService courseService, ICategoryService categoryService,
        ICourseDetailService courseDetailService)
        {
            _courseService = courseService;
            _categoryService = categoryService;
            _courseDetailService = courseDetailService;
        }
        public async Task<IActionResult> Index()
        {
            var courese = await _courseService.GetAllCourses();
            return View(courese);
        }

        public async Task<IActionResult> Create() 
        { 
            var categories = await _categoryService.GetAllCategories();
            var categoryViewModel = new CategoryViewModel()
            {
                Categories = categories.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.CategoryName
                }).ToList(),
            };
            return View(categoryViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Course courese , CategoryViewModel categoryViewModel)
        {
            if(!ModelState.IsValid)
            {
                await _courseService.CreateCourse(courese);
                foreach(var categoryId in categoryViewModel.SelectedCategories)
                {
                    var courseDetail = new CourseDetail
                    {
                        CourseId = courese.Id,
                        CategoryId = categoryId,

                    };
                    await _courseDetailService.CreateCourseDetail(courseDetail);
                }
                return RedirectToAction("Index");
            }
            var categories = await _categoryService.GetAllCategories();
            ViewBag.Categories = categories;
            return View(categoryViewModel);

        }
    }
}
