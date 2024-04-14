using AutoMapper;
using EasyLearning.Application.Services;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.WebApp.Areas.admin.Models;
using EasyLearning.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyLearning.WebApp.Controllers
{
    public class CustomerCoursesController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ICategoryService _categoryService;
        private readonly ICourseDetailService _courseDetailService;
        private readonly IFileService _fileService;
        public CustomerCoursesController(ICourseService courseService, ICategoryService categoryService,
        ICourseDetailService courseDetailService, IMapper mapper, IFileService fileService)
        {
            _courseService = courseService;
            _categoryService = categoryService;
            _courseDetailService = courseDetailService;
            _fileService = fileService;
        }
        public async Task<IActionResult> ListCoursesOfUser()
        {
            var courses = await _courseService.GetcourseByUser();
            var listCustomerCourseViewModel = new List<CustomerCourseViewModel>();
            foreach (var course in courses)
            {
                var customerCourseViewModel = new CustomerCourseViewModel
                {
                   Course = course,
                };
                listCustomerCourseViewModel.Add(customerCourseViewModel);
            }
            return View(courses);
        }
    }
}
