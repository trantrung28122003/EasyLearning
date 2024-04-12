using AutoMapper;
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
        private readonly IMapper _mapper;
        public CourseController(ICourseService courseService, ICategoryService categoryService,
        ICourseDetailService courseDetailService, IMapper mapper)
        {
            _courseService = courseService;
            _categoryService = categoryService;
            _courseDetailService = courseDetailService;
            _mapper = mapper;
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
        public async Task<IActionResult> Create(CourseCreateViewModel courseViewModel , CategoryViewModel categoryViewModel)
        {
            if(!ModelState.IsValid)
            {
                await _courseService.CreateCourse(_mapper.Map<Course>(courseViewModel));
                foreach(var categoryId in categoryViewModel.SelectedCategories)
                {
                    var courseDetail = new CourseDetail
                    {
                        CourseId = course.Id,
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

        public async Task<IActionResult> Create(CourseCreateViewModel courseViewModel, string[] selectedCategories)
        {
            if (!ModelState.IsValid)
            {

                var course = _mapper.Map<Course>(courseViewModel);
                if(course is not null)
                {
                    course?.CoursesDetails?.Add(new CourseDetail
                    {
                        course = course,
                        Category = courseViewModel.Category
                    });
                }


                //if (selectedCategories != null)
                //{
                //    foreach (var categoryId in selectedCategories)
                //    {
                //        var courdetail = new CourseDetail()
                //        {
                //            CourseId = course.Id,
                //            CategoryId = categoryId,
                //        };
                //        _courseDetailService.CreateCourseDetail(courdetail);
                //    }
                //}

                await _courseService.CreateCourse(_mapper.Map<Course>(courseViewModel));
                return RedirectToAction("Index");
            }
            /*var categories = await _categoryService.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");*/
            return View();

        }
    }
}
