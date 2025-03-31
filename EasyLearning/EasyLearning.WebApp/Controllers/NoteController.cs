using EasyLearning.Application.Services;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace EasyLearning.WebApp.Controllers
{
    public class NoteController : Controller
    {
        private readonly IUserNoteService _userNoteService;
        private readonly ITrainingPartService _trainingPartService;
        private readonly ICourseEventService _courseEventService;
        private readonly UserRepository _userRepository;
        public NoteController(IUserNoteService userNoteService, UserRepository userRepository, ITrainingPartService trainingPartService, ICourseEventService courseEventService)
        {
            _userNoteService = userNoteService;
            _userRepository = userRepository;
            _trainingPartService = trainingPartService;
            _courseEventService = courseEventService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string noteContent, string currentTime, string trainingpartId, string courseId)
        {

            if (ModelState.IsValid)
            {
                var currentUser = _userRepository.getCurrrentUser();
                var userNote = new UserNote()
                {
                    NoteContent = noteContent,
                    Time = currentTime,
                    TrainingPartId = trainingpartId,
                    CourseId = courseId,
                    UserId = currentUser,
                    DateCreate = DateTime.Now,
                    DateChange = DateTime.Now,
                    ChangedBy = currentUser,
                };
                var trainingPart = await _trainingPartService.GetTrainingPartById(trainingpartId);
                var getTrainingPartName = trainingPart.TrainingPartName;
                var listTrainingPart = await _trainingPartService.GetAllTrainingParts();
                var getCourseEventId = listTrainingPart.FirstOrDefault(x => x.Id == trainingpartId).EventId;
                var courseEvent = await _courseEventService.GetCourseEventById(getCourseEventId);
                var getCourseEventName = courseEvent.EventName;
                await _userNoteService.CreateUserNote(userNote);
                return Json(new { success = true, noteId = userNote.Id, noteContent = userNote.NoteContent, currentTime = userNote.Time, trainingPartId = userNote.TrainingPartId, trainingPartName = getTrainingPartName, courseEventName = getCourseEventName ,course = userNote.Course });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public async Task<IActionResult> Update(string noteId, string noteContent)
        {

            if (ModelState.IsValid)
            {
                var currentUser = _userRepository.getCurrrentUser();
                var userNote = await _userNoteService.GetUserNoteById(noteId);
                userNote.NoteContent = noteContent;
                userNote.DateChange = DateTime.Now;
                userNote.ChangedBy = currentUser;
                await _userNoteService.UpdateUserNote(userNote);
                return Json(new { success = true, noteContent = userNote.NoteContent, currentTime = userNote.Time, trainingpartId = userNote.TrainingPartId, course = userNote.Course });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string noteId)
        {

            if (ModelState.IsValid)
            {
                var userNote = await _userNoteService.GetUserNoteById(noteId);
                await _userNoteService.DeleteUserNote(userNote);
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}
