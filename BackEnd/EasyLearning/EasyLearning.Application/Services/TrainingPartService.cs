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
    public interface ITrainingPartService
    {
        Task<List<TrainingPart>> GetAllTrainingParts();
        Task<TrainingPart> GetTrainingPartById(string id);
        Task<List<TrainingPart>> GetTrainingPartByCourse(string id);
        Task<List<TrainingPart>> GetTrainingPartByEvent(string id);
        Task<List<TrainingPart>> GetTrainingPartWithoutEventIdAndCourse(string id);
         Task CreateTrainingPart(TrainingPart TrainingPart);
        Task UpdateTrainingPart(TrainingPart TrainingPart);
        Task UpdateTrainingPartWithEvent(string TrainingPartId, string courseEventId);
        Task UpdateCourseEventIdToNull(string eventID);
        Task DeleteTrainingPart(TrainingPart TrainingPart);
        Task SoftDeleteTrainingPart(string id);
    }
    public class TrainingPartService: ITrainingPartService
    {
        private readonly TrainingPartRepository _trainingPartRepository;
        public TrainingPartService(TrainingPartRepository trainingPartRepository)
        {
            _trainingPartRepository = trainingPartRepository;
        }
        
        public async Task<List<TrainingPart>> GetAllTrainingParts() => await _trainingPartRepository.GetAll();
        public async Task<List<TrainingPart>> GetTrainingPartByCourse(string id) => await _trainingPartRepository.GetByCondition(s => s.CoursesId == id);
        public async Task<List<TrainingPart>> GetTrainingPartByEvent(string id) => await _trainingPartRepository.GetByCondition(s => s.EventId == id);
        public async Task<List<TrainingPart>> GetTrainingPartWithoutEventIdAndCourse(string id) => await _trainingPartRepository.GetTrainingPartWithoutEventId(id);
        public async Task<TrainingPart> GetTrainingPartById(string id) => await _trainingPartRepository.GetById(id);
        public async Task CreateTrainingPart(TrainingPart TrainingPart) => await _trainingPartRepository.Create(TrainingPart);
        public async Task UpdateTrainingPart(TrainingPart TrainingPart) => await _trainingPartRepository.Update(TrainingPart);
        public async Task UpdateTrainingPartWithEvent(string TrainingPartId, string courseEventId) => await _trainingPartRepository.UpdateTrainingPartWithEvent(TrainingPartId, courseEventId);
        public async Task UpdateCourseEventIdToNull(string eventId) => await _trainingPartRepository.UpdateCourseEventIdToNull(eventId);
        public async Task DeleteTrainingPart(TrainingPart TrainingPart) => await _trainingPartRepository.Delete(TrainingPart);
        public async Task SoftDeleteTrainingPart(string id) => await _trainingPartRepository.SoftDelete(id);

        
    }
}
