using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Application.Services
{
    public interface ICourseEventService
    {
        Task<List<CourseEvent>> GetAllCourseEvents();
        Task<CourseEvent> GetCourseEventById(string id);
        Task CreateEvent(CourseEvent courseEvent);
        Task UpdateEvent(CourseEvent courseEvent);
        Task DeleteEvent(CourseEvent courseEvent);
        Task SoftDeleteEvent(string id);

    }
    public class CourseEventService : ICourseEventService
    {
        private readonly CourseEventRepository _coursseEventRepository;
        public CourseEventService(CourseEventRepository eventRepository)
        {
            _coursseEventRepository = eventRepository;
        }
        public async Task<List<CourseEvent>> GetAllCourseEvents() =>  await _coursseEventRepository.GetAll();
        public async Task<CourseEvent> GetCourseEventById(string id) => await _coursseEventRepository.GetById(id);
        public async Task CreateEvent(CourseEvent courseEvent) => await _coursseEventRepository.Create(courseEvent);
        public async Task UpdateEvent(CourseEvent courseEvent) => await _coursseEventRepository.Update(courseEvent);
        public async Task DeleteEvent(CourseEvent courseEvent) => await _coursseEventRepository.Delete(courseEvent);
        public async Task SoftDeleteEvent(string id) => await _coursseEventRepository.SoftDelete(id);
    }
}
