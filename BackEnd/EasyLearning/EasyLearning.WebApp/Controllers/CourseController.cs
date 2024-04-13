using AutoMapper;
using EasyLearning.Application.Services;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using EasyLearning.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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
            ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");
  
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course, List<string> selectedCategories)
        {
            if (ModelState.IsValid)
            {
                course.DateCreate = DateTime.Now;
                //var course = _mapper.Map<Course>(courseViewModel);
                await _courseService.CreateCourse(course);
                foreach (var categoryId in selectedCategories)
                {
                    var courDetail =new CourseDetail()
                    { CategoryId = categoryId,
                        CourseId = course.Id,
                    };
                    await _courseDetailService.CreateCourseDetail(courDetail);

                }
                return RedirectToAction("Index");
            }
            var categories = await _categoryService.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");
            return View();
        }

        public async Task<IActionResult> Update(string id)
        {
            var course = await _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            var categories = await _categoryService.GetAllCategories();
            var courseDetail = await _courseDetailService.GetAllCourseDetail();
                ViewBag.Categories = categories.Select(s => new SelectListItem
                {
                    Value = s.Id,
                    Text = s.CategoryName,
                    Selected = courseDetail.Any(p => p.CategoryId == s.Id && p.CourseId == course.Id)
                }).ToList();
          
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string id, Course course, List<string> selectedCategories)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _courseService.UpdateCourse(course);
                    foreach(var courdetail in await _courseDetailService.GetAllCourseDetail())
                    {
                        if(courdetail.CourseId == course.Id)
                        {
                            await _courseDetailService.DeleteCourseDetail(courdetail);
                        }    
                    }
       
                    foreach (var categoryId in selectedCategories)
                    {
                        await _courseDetailService.CreateCourseDetail(new CourseDetail { CategoryId = categoryId, CourseId = course.Id });
                    }
                }
                catch (Exception)
                {
                    return RedirectToAction("Error", "Home");
                }
                return RedirectToAction(nameof(Index));
            }

            var categories = await _categoryService.GetAllCategories();
            var courseDetail = await _courseDetailService.GetAllCourseDetail();
            ViewBag.Categories = categories.Select(s => new SelectListItem
            {
                Value = s.Id,
                Text = s.CategoryName,
                Selected = courseDetail.Any(p => p.CategoryId == s.Id && p.CourseId == course.Id)
            }).ToList();

            return View(course);
        }


        public async Task<IActionResult> Details(string id)
        {
            var product = await _courseService.GetCourseById(id); 
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        
        public async Task<IActionResult> Delete(string id)
        {
            var course = await _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var course = await _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            var courdetails = await _courseDetailService.GetAllCourseDetail();
            foreach (var courDetail in courdetails)
            { 
                if(courDetail.CourseId == course.Id)
                {
                    await _courseDetailService.DeleteCourseDetail(courDetail);
                }
            }
            await _courseService.DeleteCourse(course);
            return RedirectToAction(nameof(Index)); // Chuyển hướng về trang danh sách khóa học sau khi xóa thành công
        }

      
        /*[HttpPost]
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
                await _courseService.CreateCourse(_mapper.Map<Course>(courseViewModel));
                return RedirectToAction("Index");
            }
            *//*var categories = await _categoryService.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");*//*
            return View();
        }*/
    }
}
