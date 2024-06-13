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
    public class EventController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ICourseEventService _courseEventService;
        private readonly ITrainingPartService _TrainingPartService;
        private readonly UserRepository _userRepository;
        private readonly IFileService _fileService;
        public EventController(ICourseService courseService, ICourseEventService courseEventService, 
            ITrainingPartService TrainingPartService, UserRepository userRepository, IFileService fileService)
        {
            _courseService = courseService;
            _courseEventService = courseEventService;
            _TrainingPartService = TrainingPartService;
            _userRepository = userRepository;
            _fileService = fileService;
        }

        public async Task<IActionResult> Index(string courseId)
        {
            if (courseId == null)
            {
                return NotFound();
            }
            var eventByCourse = await _courseEventService.GetEventByCourse(courseId);
            var course = await _courseService.GetCourseById(courseId);

            var couresEventsByNotIsDelete = new List<CourseEvent>();
            var courseEvents = await _courseEventService.GetAllCourseEvents();
            foreach (var itemCourseEvent in courseEvents)
            {
                if (itemCourseEvent.IsDeleted == false)
                {
                    couresEventsByNotIsDelete.Add(itemCourseEvent);
                }
            }
   
            ViewBag.CourseId = course.Id;
            ViewBag.CourseName = course.CoursesName;
            return View(couresEventsByNotIsDelete);
        }

        public async Task<IActionResult> Create(string courseId)
        {
            if (courseId == null)
            {
                return NotFound();
            }
            var eventViewModel = new EventViewModel
            {
            };
            var course = await _courseService.GetCourseById(courseId);
            ViewBag.CourseId = course.Id;
            ViewBag.CourseName = course.CoursesName;
            ViewBag.IsOnlineCourse = course.CourseType == CourseType.Online;
            return View(eventViewModel);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventViewModel eventViewModel)
        {
            if (ModelState.IsValid)
            {
                var location = eventViewModel.EventType == CourseEventType.Offline ? eventViewModel.Location: eventViewModel.OnlineRoomUrl;


                var courseEvent = new CourseEvent()
                {
                    EventName = eventViewModel.EventName,
                    EventType = (CourseEventType)eventViewModel.EventType,
                    Location = location,
                    DateStart = eventViewModel.DateStart,
                    DateEnd = eventViewModel.DateEnd,
                    DateCreate = DateTime.Now,
                    DateChange = DateTime.Now,
                    ChangedBy = _userRepository.getCurrrentUser(),
                };
                await _courseEventService.CreateEvent(courseEvent);
                var videoUrlTrainingPart = eventViewModel.TrainingPartViewModel.VideoUrl;
                if (eventViewModel.TrainingPartViewModel.Video != null)
                {
                    videoUrlTrainingPart = await _fileService.SaveFile(eventViewModel.TrainingPartViewModel.Video);
                }
                TrainingPart trainingPart = new TrainingPart()
                {
                    TrainingPartName = eventViewModel.TrainingPartViewModel.TrainingPartName,
                    StartTime = eventViewModel.TrainingPartViewModel.StartTime,
                    EndTime = eventViewModel.TrainingPartViewModel.EndTime,
                    Description = eventViewModel.TrainingPartViewModel.Description,
                    EventId = courseEvent.Id,
                    CoursesId = eventViewModel.CourseId,
                    DateChange = DateTime.Now,
                    DateCreate = DateTime.Now,
                    ChangedBy = _userRepository.getCurrrentUser(),
                    VideoUrl = videoUrlTrainingPart,
                    TrainingPartType = (TrainingPartType)eventViewModel.TrainingPartViewModel.TrainingPartType,
                    IsFree = eventViewModel.TrainingPartViewModel.IsFree,
                };
                await _TrainingPartService.CreateTrainingPart(trainingPart);
                return RedirectToAction("Index", "Event", new { courseId = eventViewModel.CourseId});
            }
            return View(eventViewModel);
        }

        public async Task<IActionResult> Update(string id, string courseId)
        {
            var courseEvent = await _courseEventService.GetCourseEventById(id);
            if (courseEvent == null)
            {
                return NotFound();
            }
            var listCourses = await _courseService.GetAllCourses();
            var trainingParts = await _TrainingPartService.GetTrainingPartWithEventIdAndCourseId(id, courseId);
            var eventViewModel = new EventViewModel
            {
                EventName = courseEvent.EventName,
                EventType = courseEvent.EventType,
                Location = courseEvent.Location,
                DateStart = courseEvent.DateStart,
                DateEnd = courseEvent.DateEnd,
                CourseId = courseId,
                TrainingParts = trainingParts,
            };
            ViewBag.CourseId = courseId;
            ViewBag.OriginalCourseId = courseId;
            ViewBag.ListCourses = new SelectList(listCourses, "Id", "CoursesName", eventViewModel.CourseId);
            return View(eventViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string id, EventViewModel eventViewModel, string originalCourseId)
        {
            if (ModelState.IsValid)
            {
                var courseEvent = await _courseEventService.GetCourseEventById(id);
                if (courseEvent == null)
                {
                    return NotFound();
                }
                var trainingParts = await _TrainingPartService.GetTrainingPartWithEventIdAndCourseId(id, originalCourseId);
                foreach (var itemTrainingPart in trainingParts)
                {
                    if (itemTrainingPart.CoursesId != eventViewModel.CourseId)
                    {
                        itemTrainingPart.CoursesId = eventViewModel.CourseId;
                        await _TrainingPartService.UpdateTrainingPart(itemTrainingPart);
                    }
                }
                var location = eventViewModel.EventType == CourseEventType.Offline ? eventViewModel.Location : eventViewModel.OnlineRoomUrl;

                courseEvent.EventName = eventViewModel.EventName;
                courseEvent.EventType = (CourseEventType)eventViewModel.EventType;
                courseEvent.Location = location;
                courseEvent.DateStart = eventViewModel.DateStart;
                courseEvent.DateEnd = eventViewModel.DateEnd;
                courseEvent.DateChange = DateTime.Now;
                courseEvent.ChangedBy = _userRepository.getCurrrentUser();
                await _courseEventService.UpdateEvent(courseEvent);
                return RedirectToAction("Index", "Event", new { courseId = eventViewModel.CourseId });
            }
            return View(eventViewModel);
        }

        public async Task<IActionResult> Details(string id, string courseId)
        {
            var courseEvent = await _courseEventService.GetCourseEventById(id);
            if (courseEvent == null)
            {
                return NotFound();
            }
            var listCourses = await _courseService.GetAllCourses();
            var trainingParts = await _TrainingPartService.GetTrainingPartWithEventIdAndCourseId(id, courseId);
            var eventViewModel = new EventViewModel
            {
                EventName = courseEvent.EventName,
                EventType = courseEvent.EventType,
                Location = courseEvent.Location,
                DateStart = courseEvent.DateStart,
                DateEnd = courseEvent.DateEnd,
                CourseId = courseId,
                TrainingParts = trainingParts,
            };
            var course = await _courseService.GetCourseById(courseId);
            ViewBag.CourseName = course.CoursesName;
   
            return View(eventViewModel);
           
           
        }
       
   
        public async Task<IActionResult> Remove(string id, string courseId)
        {
            var courseEvent = await _courseEventService.GetCourseEventById(id);
            if (courseEvent == null)
            {
                return NotFound();
            }
            var listCourses = await _courseService.GetAllCourses();
            var trainingParts = await _TrainingPartService.GetTrainingPartWithEventIdAndCourseId(id, courseId);
            var eventViewModel = new EventViewModel
            {
                EventId = courseEvent.Id,
                EventName = courseEvent.EventName,
                EventType = courseEvent.EventType,
                Location = courseEvent.Location,
                DateStart = courseEvent.DateStart,
                DateEnd = courseEvent.DateEnd,
                CourseId = courseId,
                TrainingParts = trainingParts,
                DateCreate = courseEvent.DateCreate,
                DateChange = courseEvent.DateChange,
            };
            var course = await _courseService.GetCourseById(courseId);
            ViewBag.CourseName = course.CoursesName;

            return View(eventViewModel);
        }

        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var courseEvent = await _courseEventService.GetCourseEventById(id);
            if (courseEvent == null)
            {
                return NotFound();
            }
            courseEvent.IsDeleted = true;
            courseEvent.DateChange = DateTime.Now;
            courseEvent.ChangedBy = _userRepository.getCurrrentUser();
            await _courseEventService.UpdateEvent(courseEvent);
           
            return RedirectToAction("Index", "Course");
        }
    }
}
