using AutoMapper;
using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Application.Services;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using EasyLearning.WebApp.Areas.admin.Models;
using EasyLearning.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyLearning.WebApp.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ICategoryService _categoryService;
        private readonly ICourseDetailService _courseDetailService;
        private readonly ITrainerDetailService _trainerDetailService;
        private readonly ITrainingPartService _trainingPartService;
        private readonly ICourseEventService _courseEventService;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        private readonly UserRepository _userRepository;
     
        public CourseController(ICourseService courseService, ICategoryService categoryService,
        ICourseDetailService courseDetailService, IMapper mapper, IFileService fileService,
        UserRepository userRepository, ITrainerDetailService trannerDetailService,
        ITrainingPartService trainingPartService, ICourseEventService courseEventService)
        {
            _courseService = courseService;
            _categoryService = categoryService;
            _courseDetailService = courseDetailService;
            _trainerDetailService = trannerDetailService;
            _mapper = mapper;
            _fileService = fileService;
            _userRepository = userRepository;
            _trainingPartService = trainingPartService;
            _courseEventService = courseEventService;
        }
        public async Task<IActionResult> Index()
        {
            var coureseByNotIsDelete = new List<Course>();
            var courese = await _courseService.GetAllCourses();
            foreach(var course in courese)
            {
                if(course.IsDeleted == false)
                {
                    coureseByNotIsDelete.Add(course);
                }    
            } 
              
            return View(coureseByNotIsDelete);
        }
        public async Task<IActionResult> Recycle()
        {
            var coursesByNotDeleted = (await _courseService.GetAllCourses())
                .Where(course => course.IsDeleted)
                .Select(course => new RecycleDataViewModel
                {
                    Id = course.Id,
                    Name = course.CoursesName,
                    RemoveDate = course.DateChange,
                    ItemType = "Course"
                })
                .ToList();

            var trainingPartsByNotDeleted = (await _trainingPartService.GetAllTrainingParts())
                .Where(trainingPart => trainingPart.IsDeleted)
                .Select(trainingPart => new RecycleDataViewModel
                {
                    Id = trainingPart.Id,
                    Name = trainingPart.TrainingPartName,
                    RemoveDate = trainingPart.DateChange,
                    ItemType = "TrainingPart"
                })
                .ToList();
            var courseEventsByNotDeleted = (await _courseEventService.GetAllCourseEvents())
                .Where(courseEvent => courseEvent.IsDeleted)
                .Select(courseEvent => new RecycleDataViewModel
                {
                    Id = courseEvent.Id,
                    Name = courseEvent.EventName,
                    RemoveDate = courseEvent.DateChange,
                    ItemType = "CourseEvent"
                })
                .ToList();

            var allRecycleData = coursesByNotDeleted
                .Concat(trainingPartsByNotDeleted)
                .Concat(courseEventsByNotDeleted)
                .ToList();
            return View(allRecycleData);
        }
      
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseViewModel courseViewModel, List<string> selectedCategories)
        {
            if (ModelState.IsValid)
            {
                var imageLink = "https://easylearning.blob.core.windows.net/images-videos/courseDefault.jpg6d2d5281-995b-4b73-ac6a-6897350fae0b";
                if (courseViewModel.Image != null)
                {
                    imageLink = await _fileService.SaveFile(courseViewModel.Image);
                }    
                var getInstructor = courseViewModel.Instructor ?? await _userRepository.getCurrrentUserFullNameAsync();
                Course course = new Course()
                {
                    CoursesName = courseViewModel.CoursesName,
                    CourseType = (CourseType)courseViewModel.CourseType,
                    CoursesDescription = courseViewModel.CoursesDescription,
                    CoursesPrice = courseViewModel.CoursesPrice,
                    Requirements = courseViewModel.Requirements,
                    CoureseContent = courseViewModel.CoureseContent,
                    StartDate = courseViewModel.StartDate,
                    EndDate = courseViewModel.EndDate,
                    RegistrationDeadline = courseViewModel.RegistrationDeadline,
                    MaxAttdendees = courseViewModel.MaxAttdendees,
                    Instructor = getInstructor,
                    ImageUrl = imageLink,
                    DateCreate = DateTime.Now
                };
                await _courseService.CreateCourse(course);
                foreach (var categoryId in selectedCategories)
                {
                    var courDetail = new CourseDetail()
                    {
                        CategoryId = categoryId,
                        CourseId = course.Id,
                    };
                    await _courseDetailService.CreateCourseDetail(courDetail);
                }

                var trannerDetail = new TrainerDetail()
                {
                    CoursesId = course.Id,
                    UserId = _userRepository.getCurrrentUser(),
                };
                await _trainerDetailService.CreateTranerDetail(trannerDetail);
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

            CourseViewModel courseViewModel = new CourseViewModel()
            {
                CourseId = course.Id,
                CoursesName = course.CoursesName,
                CourseType = (CourseType)course.CourseType,
                CoursesDescription = course.CoursesDescription,
                CoursesPrice = course.CoursesPrice,
                Requirements = course.Requirements,
                CoureseContent = course.CoureseContent,
                CurrentImage = course.ImageUrl,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                DateChange = course.DateChange,
                RegistrationDeadline = course.RegistrationDeadline,
                Instructor = course.Instructor,
                MaxAttdendees = course.MaxAttdendees
            };
            var categories = await _categoryService.GetAllCategories();
            var courseDetail = await _courseDetailService.GetAllCourseDetail();
            ViewBag.Categories = categories.Select(s => new SelectListItem
            {
                Value = s.Id,
                Text = s.CategoryName,
                Selected = courseDetail.Any(p => p.CategoryId == s.Id && p.CourseId == course.Id)
            }).ToList();
        
            return View(courseViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string id, CourseViewModel courseViewModel, List<string> selectedCategories)
        {
           
            if (id != courseViewModel.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var ImageUrl = courseViewModel.CurrentImage;
                    if (ImageUrl == null)
                    {

                        ImageUrl = await _fileService.SaveFile(courseViewModel.Image);
                    }
                    var courseToUpdate = await _courseService.GetCourseById(courseViewModel.CourseId);
                    if (courseToUpdate != null) {
                        courseToUpdate.CoursesName = courseViewModel.CoursesName;
                        courseToUpdate.CourseType = (CourseType)courseViewModel.CourseType;
                        courseToUpdate.CoursesDescription = courseViewModel.CoursesDescription;
                        courseToUpdate.CoursesPrice = courseViewModel.CoursesPrice;
                        courseToUpdate.Requirements = courseViewModel.Requirements;
                        courseToUpdate.CoureseContent = courseViewModel.CoureseContent;
                        courseToUpdate.ImageUrl = courseViewModel.CurrentImage;
                        courseToUpdate.StartDate = courseViewModel.StartDate;
                        courseToUpdate.EndDate = courseViewModel.EndDate;
                        courseToUpdate.DateChange = courseViewModel.DateChange;
                        courseToUpdate.RegistrationDeadline = courseViewModel.RegistrationDeadline;
                        courseToUpdate.Instructor = courseViewModel.Instructor;
                        courseToUpdate.MaxAttdendees = courseViewModel.MaxAttdendees;
                    }
                    await _courseService.UpdateCourse(courseToUpdate);
                    foreach (var courdetail in await _courseDetailService.GetAllCourseDetail())
                    {
                        if (courdetail.CourseId == courseToUpdate.Id)
                        {
                            await _courseDetailService.DeleteCourseDetail(courdetail);
                        }
                    }

                    foreach (var categoryId in selectedCategories)
                    {
                        await _courseDetailService.CreateCourseDetail(new CourseDetail { CategoryId = categoryId, CourseId = courseToUpdate.Id });
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
                Selected = courseDetail.Any(p => p.CategoryId == s.Id && p.CourseId == courseViewModel.CourseId)
            }).ToList();

            return View(courseViewModel);
        }

        public async Task<IActionResult> Details(string id)
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
            var courseViewModel = new CourseViewModel()
            {
                CourseId = course.Id,
                CoursesName = course.CoursesName,
                CourseType = course.CourseType,
                CoursesDescription = course.CoursesDescription,
                CoursesPrice = course.CoursesPrice,
                Requirements = course.Requirements,
                CoureseContent = course.CoureseContent,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                RegistrationDeadline = course.RegistrationDeadline,
                Instructor = course.Instructor,
                MaxAttdendees = course.MaxAttdendees,
                CurrentImage = course.ImageUrl,
                DateChange = course.DateChange,
                ChangedBy = course.ChangedBy,
            };
            return View(courseViewModel);
        }


        public async Task<IActionResult> Remove(string id)
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
            var courseViewModel = new CourseViewModel()
            {
                CourseId = course.Id,
                CoursesName = course.CoursesName,
                CourseType = course.CourseType,
                CoursesDescription = course.CoursesDescription,
                CoursesPrice = course.CoursesPrice,
                Requirements = course.Requirements,
                CoureseContent = course.CoureseContent,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                RegistrationDeadline = course.RegistrationDeadline,
                Instructor = course.Instructor,
                MaxAttdendees = course.MaxAttdendees,
                CurrentImage = course.ImageUrl,
                DateChange = course.DateChange,
                ChangedBy = course.ChangedBy,
            };
            return View(courseViewModel);
        }

        [HttpPost, ActionName("remove")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var course = await _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            course.IsDeleted = true;
            course.DateChange = DateTime.Now;
            course.ChangedBy = _userRepository.getCurrrentUser();
            await _courseService.UpdateCourse(course);
            return RedirectToAction(nameof(Index)); 
        }

       
        public async Task<IActionResult> Restore(string id, string itemType)
        {
            if (itemType == "Course")
            {
                var course = await _courseService.GetCourseById(id);
                if (course == null)
                {
                    return NotFound();
                }

                course.IsDeleted = false;
                course.DateChange = DateTime.Now;
                course.ChangedBy = _userRepository.getCurrrentUser();
                await _courseService.UpdateCourse(course);
            }
            else if (itemType == "TrainingPart")
            {
                var trainingPart = await _trainingPartService.GetTrainingPartById(id);
                if (trainingPart == null)
                {
                    return NotFound();
                }

                trainingPart.IsDeleted = false;
                trainingPart.DateChange = DateTime.Now;
                trainingPart.ChangedBy = _userRepository.getCurrrentUser();
                await _trainingPartService.UpdateTrainingPart(trainingPart);
            }
            else if (itemType == "CourseEvent")
            {
                var courseEvent = await _courseEventService.GetCourseEventById(id);
                if (courseEvent == null)
                {
                    return NotFound();
                }

                courseEvent.IsDeleted = false;
                courseEvent.DateChange = DateTime.Now;
                courseEvent.ChangedBy = _userRepository.getCurrrentUser();
                await _courseEventService.UpdateEvent(courseEvent);
            }
            else
            {
                return BadRequest("Invalid item type.");
            }

            return RedirectToAction(nameof(Recycle));

        }
    }
}
