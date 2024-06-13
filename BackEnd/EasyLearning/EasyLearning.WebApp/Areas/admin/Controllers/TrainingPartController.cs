using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Application.Services;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using EasyLearning.WebApp.Areas.admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyLearning.WebApp.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class TrainingPartController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ITrainingPartService _TrainingPartService;
        private readonly ICourseEventService _courseEventService;
        private readonly UserRepository _userRepository;
        private readonly IFileService _fileService;
        

        public TrainingPartController(ITrainingPartService TrainingPartService, ICourseEventService courseEventService, 
            ICourseService courseService, UserRepository userRepository, IFileService fileService)
        {
            _TrainingPartService = TrainingPartService;
            _courseEventService = courseEventService;
            _courseService = courseService;
            _userRepository = userRepository;
            _fileService = fileService;
        }

        public async Task<IActionResult> Index(string courseId)
        {
            if (courseId == null)
            {
                return NotFound();
            }
            var trainingPartsByNotIsDelete = new List<TrainingPart>();
            var TrainingParts = await _TrainingPartService.GetTrainingPartByCourse(courseId);
            foreach (var itemTrainingPart in TrainingParts)
            {
                if (itemTrainingPart.IsDeleted == false)
                {
                    trainingPartsByNotIsDelete.Add(itemTrainingPart);
                }
            }
            var course = await _courseService.GetCourseById(courseId);
            ViewBag.CourseId = courseId;
            ViewBag.CourseName = course.CoursesName;
            return View(trainingPartsByNotIsDelete);
        }

        public async Task<IActionResult> Create(string courseId)
        {
           
            var courseEventbyCourse = await _courseEventService.GetEventByCourse(courseId);
            var course = await _courseService.GetCourseById(courseId);
            ViewBag.CourseId = courseId;
            ViewBag.CourseName = course.CoursesName;
            ViewBag.IsOnlineCourse = course.CourseType == CourseType.Online;
            ViewBag.CourseEvent = new SelectList(courseEventbyCourse, "Id", "EventName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrainingPartViewModel trainingPartViewModel)
        {
            if (ModelState.IsValid)
            {
                var videoUrlTrainingPart = trainingPartViewModel.VideoUrl;
                if (trainingPartViewModel.Video != null)
                {
                    videoUrlTrainingPart = await _fileService.SaveFile(trainingPartViewModel.Video);
                }
                TrainingPart trainingPart = new TrainingPart()
                {
                    TrainingPartName = trainingPartViewModel.TrainingPartName,
                    StartTime = trainingPartViewModel.StartTime,
                    EndTime = trainingPartViewModel.EndTime,
                    Description = trainingPartViewModel.Description,
                    EventId = trainingPartViewModel.EventId,
                    CoursesId = trainingPartViewModel.CoursesId,
                    DateChange = DateTime.Now,
                    DateCreate = DateTime.Now,
                    ChangedBy = _userRepository.getCurrrentUser(),
                    VideoUrl = videoUrlTrainingPart,
                    TrainingPartType = (TrainingPartType)trainingPartViewModel.TrainingPartType,
                    IsFree = trainingPartViewModel.IsFree,
                };
                await _TrainingPartService.CreateTrainingPart(trainingPart);
                return RedirectToAction("Index", "TrainingPart", new { courseId = trainingPart.CoursesId });
            }
            var courseEventbyCourse = await _courseEventService.GetEventByCourse(trainingPartViewModel.CoursesId);
            var course = await _courseService.GetCourseById(trainingPartViewModel.CoursesId);
            ViewBag.CourseId = trainingPartViewModel.CoursesId;
            ViewBag.CourseName = course.CoursesName;
            ViewBag.IsOnlineCourse = course.CourseType == CourseType.Online;
            ViewBag.CourseEvent = new SelectList(courseEventbyCourse, "Id", "EventName");
            return View(trainingPartViewModel);
        }

        public async Task<IActionResult> Update(string id)
        {
            var trainingPart = await _TrainingPartService.GetTrainingPartById(id);
            if (trainingPart == null)
            {
                return NotFound();
            }
            TrainingPartViewModel trainingPartViewModel = new TrainingPartViewModel()
            {
                TrainingPartId = trainingPart.Id,
                CoursesId = trainingPart.CoursesId,
                EventId = trainingPart.EventId,
                TrainingPartName = trainingPart.TrainingPartName,
                StartTime = trainingPart.StartTime,
                EndTime = trainingPart.EndTime,
                Description = trainingPart.Description,
                TrainingPartType = trainingPart.TrainingPartType,
                VideoUrl = trainingPart.VideoUrl,
                IsFree = trainingPart.IsFree
            };
            var courseEventbyCourse = await _courseEventService.GetEventByCourse(trainingPart.CoursesId);
            var course = await _courseService.GetCourseById(trainingPart.CoursesId);
            ViewBag.CourseId = trainingPart.CoursesId;
            ViewBag.CourseName = course.CoursesName;
            ViewBag.IsOnlineCourse = course.CourseType == CourseType.Online;
            ViewBag.CourseEvent = new SelectList(courseEventbyCourse, "Id", "EventName");
            return View(trainingPartViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TrainingPartViewModel trainingPartViewModel, string id)
        {
            if (id != trainingPartViewModel.TrainingPartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    var videoUrlTrainingPart = trainingPartViewModel.VideoUrl;
                    if (trainingPartViewModel.Video != null)
                    {
                        videoUrlTrainingPart = await _fileService.SaveFile(trainingPartViewModel.Video);
                    }
                    var trainingPartToUpdate = await _TrainingPartService.GetTrainingPartById(trainingPartViewModel.TrainingPartId);  
                    if(trainingPartToUpdate != null)
                    {
                        trainingPartToUpdate.TrainingPartName = trainingPartViewModel.TrainingPartName;
                        trainingPartToUpdate.StartTime = trainingPartViewModel.StartTime;
                        trainingPartToUpdate.EndTime = trainingPartViewModel.EndTime;
                        trainingPartToUpdate.Description = trainingPartViewModel.Description;
                        trainingPartToUpdate.TrainingPartType = trainingPartViewModel.TrainingPartType;
                        trainingPartToUpdate.VideoUrl = videoUrlTrainingPart;
                        trainingPartToUpdate.IsFree = trainingPartViewModel.IsFree;
                        trainingPartToUpdate.DateChange = DateTime.Now;
                        trainingPartToUpdate.ChangedBy = _userRepository.getCurrrentUser();
                    }
                    await _TrainingPartService.UpdateTrainingPart(trainingPartToUpdate);
                }
                catch (Exception)
                {
                    return RedirectToAction("Error", "Home");
                }
                return RedirectToAction("Index", "TrainingPart", new { courseId = trainingPartViewModel.CoursesId });
            }
            return View(trainingPartViewModel);
        }

        public async Task<IActionResult> Details(string id)
        {
            var trainingPart = await _TrainingPartService.GetTrainingPartById(id);
            if (trainingPart == null)
            {
                return NotFound();
            }
            var trainingPartViewModel = new TrainingPartViewModel()
            {
                TrainingPartId = trainingPart.Id,
                CoursesId = trainingPart.CoursesId,
                EventId = trainingPart.EventId,
                TrainingPartName = trainingPart.TrainingPartName,
                StartTime = trainingPart.StartTime,
                EndTime = trainingPart.EndTime,
                Description = trainingPart.Description,
                TrainingPartType = trainingPart.TrainingPartType,
                VideoUrl = trainingPart.VideoUrl,
                IsFree = trainingPart.IsFree,

            };
            return View(trainingPartViewModel);
        }

        public async Task<IActionResult> Remove(string id)
        {
            var trainingPart = await _TrainingPartService.GetTrainingPartById(id);
            if (trainingPart == null)
            {
                return NotFound();
            }
            var trainingPartViewModel = new TrainingPartViewModel()
            {
                TrainingPartId = trainingPart.Id,
                CoursesId = trainingPart.CoursesId,
                EventId = trainingPart.EventId,
                TrainingPartName = trainingPart.TrainingPartName,
                StartTime = trainingPart.StartTime,
                EndTime = trainingPart.EndTime,
                Description = trainingPart.Description,
                TrainingPartType = trainingPart.TrainingPartType,
                VideoUrl = trainingPart.VideoUrl,
                IsFree = trainingPart.IsFree,

            };
            var courseEvent = await _courseEventService.GetCourseEventById(trainingPart.EventId);
            var course = await _courseService.GetCourseById(trainingPart.CoursesId);
            ViewBag.CourseEventName = courseEvent.EventName;
            @ViewBag.CourseName = course.CoursesName;
            return View(trainingPartViewModel);
        }


        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var trainingPart = await _TrainingPartService.GetTrainingPartById(id);
            if (trainingPart == null)
            {
                return NotFound();
            }
            try
            {
                trainingPart.IsDeleted = true;
                trainingPart.DateCreate = DateTime.Now;
                trainingPart.ChangedBy = _userRepository.getCurrrentUser();
                await _TrainingPartService.UpdateTrainingPart(trainingPart);
                return RedirectToAction("Index", "TrainingPart", new { courseId = trainingPart.CoursesId });
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "TrainingPart", new { courseId = trainingPart.CoursesId });
            }
        }

        /*[HttpPost, ActionName("Delete")]
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
        }*/
    }
}
