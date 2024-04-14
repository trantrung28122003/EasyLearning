using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Application.Services
{
    public interface ITranningPartService
    {
        Task<List<TranningPart>> GetAllTranningParts();
        Task<TranningPart> GetTranningPartById(string id);
        Task<List<TranningPart>> GetTranningPartByCourse(string id);
        Task<List<TranningPart>> GetTranningPartByEvent(string id);
        Task<List<TranningPart>> GetTranningPartWithoutEventIdAndCourse(string id);
         Task CreateTranningPart(TranningPart tranningPart);
        Task UpdateTranningPart(TranningPart tranningPart);
        Task UpdateTranningPartWithEvent(string TranningPartId, string courseEventId);
        Task UpdateCourseEventIdToNull(string eventID);
        Task DeleteTranningPart(TranningPart tranningPart);
        Task SoftDeleteTranningPart(string id);
    }
    public class TranningPartService: ITranningPartService
    {
        private readonly TranningPartRepository _tranningPartRepository;
        public TranningPartService(TranningPartRepository tranningPartRepository)
        {
            _tranningPartRepository = tranningPartRepository;
        }
        
        public async Task<List<TranningPart>> GetAllTranningParts() => await _tranningPartRepository.GetAll();
        public async Task<List<TranningPart>> GetTranningPartByCourse(string id) => await _tranningPartRepository.GetByCondition(s => s.CoursesId == id);
        public async Task<List<TranningPart>> GetTranningPartByEvent(string id) => await _tranningPartRepository.GetByCondition(s => s.EventId == id);
        public async Task<List<TranningPart>> GetTranningPartWithoutEventIdAndCourse(string id) => await _tranningPartRepository.GetTranningPartWithoutEventId(id);
        public async Task<TranningPart> GetTranningPartById(string id) => await _tranningPartRepository.GetById(id);
        public async Task CreateTranningPart(TranningPart tranningPart) => await _tranningPartRepository.Create(tranningPart);
        public async Task UpdateTranningPart(TranningPart tranningPart) => await _tranningPartRepository.Update(tranningPart);
        public async Task UpdateTranningPartWithEvent(string TranningPartId, string courseEventId) => await _tranningPartRepository.UpdateTranningPartWithEvent(TranningPartId, courseEventId);
        public async Task UpdateCourseEventIdToNull(string eventId) => await _tranningPartRepository.UpdateCourseEventIdToNull(eventId);
        public async Task DeleteTranningPart(TranningPart tranningPart) => await _tranningPartRepository.Delete(tranningPart);
        public async Task SoftDeleteTranningPart(string id) => await _tranningPartRepository.SoftDelete(id);

        
    }
}
