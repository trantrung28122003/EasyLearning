using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repository;

namespace EasyLearning.Application.Services
{
    public interface ICourseEventService
    {
        Task<List<CourseEvent>> GetAllCourseEvents();
        Task<CourseEvent> GetCourseEventById(string id);
        Task<List<CourseEvent>> GetEventByCourse(string id);
        Task CreateEvent(CourseEvent courseEvent);
        Task UpdateEvent(CourseEvent courseEvent);
        Task DeleteEvent(CourseEvent courseEvent);
        Task SoftDeleteEvent(string id);

    }
    public class CourseEventService : ICourseEventService
    {
        private readonly CourseEventRepository _courseEventRepository;
        public CourseEventService(CourseEventRepository eventRepository)
        {
            _courseEventRepository = eventRepository;
        }
        public async Task<List<CourseEvent>> GetEventByCourse(string id) => await _courseEventRepository.GetEventByCourse(id);
        public async Task<CourseEvent> GetCourseEventById(string id) => await _courseEventRepository.GetById(id);
        public async Task<List<CourseEvent>> GetAllCourseEvents() =>  await _courseEventRepository.GetAll();

        public async Task CreateEvent(CourseEvent courseEvent) => await _courseEventRepository.Create(courseEvent);
        public async Task UpdateEvent(CourseEvent courseEvent) => await _courseEventRepository.Update(courseEvent);
        public async Task DeleteEvent(CourseEvent courseEvent) => await _courseEventRepository.Delete(courseEvent);
        public async Task SoftDeleteEvent(string id) => await _courseEventRepository.SoftDelete(id);
    }
}
