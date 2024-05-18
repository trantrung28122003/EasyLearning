using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Application.Services
{
    public interface IExerciseQuestionService
    {
        Task<List<ExerciseQuestion>> GetAllExerciseQuestion();
        Task<List<ExerciseQuestion>> GetExerciseQuestionByTraningPartId(string id);
        Task<List<ExerciseQuestion>> GetAllQuestionsAndAnswer(string traininngPartId);
        Task CreateExerciseQuestion(ExerciseQuestion ExerciseQuestion);
        Task UpdateExerciseQuestion(ExerciseQuestion ExerciseQuestion);
        Task DeleteExerciseQuestion(ExerciseQuestion ExerciseQuestion);
        Task SoftDeleteExerciseQuestion(string id);
    }
    public class ExerciseQuestionService : IExerciseQuestionService
    {
        private readonly ExerciseQuestionRepository _ExerciseQuestionRepository;
        public ExerciseQuestionService(ExerciseQuestionRepository ExerciseQuestionRepository)
        {
            _ExerciseQuestionRepository = ExerciseQuestionRepository;
        }
        public async Task<List<ExerciseQuestion>> GetAllExerciseQuestion() => await _ExerciseQuestionRepository.GetAll();
        public async Task<List<ExerciseQuestion>> GetExerciseQuestionByTraningPartId(string id) => await _ExerciseQuestionRepository.GetByCondition(x => x.TrainingPartId == id);
        public async Task<List<ExerciseQuestion>> GetAllQuestionsAndAnswer(string trainingPartId) => await _ExerciseQuestionRepository.GetAllQuestionsAndAnswer(trainingPartId);
        public async Task CreateExerciseQuestion(ExerciseQuestion ExerciseQuestion) => await _ExerciseQuestionRepository.Create(ExerciseQuestion);
        public async Task UpdateExerciseQuestion(ExerciseQuestion ExerciseQuestion) => await _ExerciseQuestionRepository.Update(ExerciseQuestion);
        public async Task DeleteExerciseQuestion(ExerciseQuestion ExerciseQuestion) => await _ExerciseQuestionRepository.Delete(ExerciseQuestion);
        public async Task SoftDeleteExerciseQuestion(string id) => await _ExerciseQuestionRepository.SoftDelete(id);
    }
}
