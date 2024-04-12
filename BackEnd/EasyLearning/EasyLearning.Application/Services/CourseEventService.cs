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
    public class CourseEventService
    {
        private readonly CourseEventRepository _coursseEventRepository;
        public CourseEventService(CourseEventRepository eventRepository)
        {
            _coursseEventRepository = eventRepository;
        }

        public async Task<List<CourseEvent>> GetEvent()
        {
            return await _coursseEventRepository.GetAll();
        }

        public async Task<List<CourseEvent>> GetEventById(string id)
        {
            return await _coursseEventRepository.GetByCondition(s => s.Id == id);
        }

        public async Task CreateEvent(CourseEvent courseEvent)
        {
            await _coursseEventRepository.Create(courseEvent);
        }

        public async Task UpdateEvent(CourseEvent courseEvent)
        {
            await _coursseEventRepository.Update(courseEvent);
        }

        public async Task DeleteEvent(CourseEvent courseEvent)
        {
            await _coursseEventRepository.Delete(courseEvent);
        }

        public async Task SoftDeleteEvent(string id)
        {
            await _coursseEventRepository.SoftDelete(id);
        }
    }
}
