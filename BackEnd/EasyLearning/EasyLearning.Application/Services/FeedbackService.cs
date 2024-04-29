using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repository;

namespace EasyLearning.Application.Services
{
    public interface IFeedbackService
    {
        Task<List<Feedback>> GetAllFeedbacks();
        Task<Feedback> GetFeedbackById(string id);
        Task<List<Feedback>> GetFeedbacksByCourseId(string courseId);
        Task CreateFeedback(Feedback feedback);
        Task UpdateFeedback(Feedback feedback);
        Task DeleteFeedback(Feedback feedback);
        Task SoftDeleteFeedback(string id);
    }
    public class FeedbackService : IFeedbackService
    {
        private readonly FeedbackRepository _feedbackRepository;
        public FeedbackService(FeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }
        public async Task<List<Feedback>> GetAllFeedbacks() => await _feedbackRepository.GetAll();
        public async Task<Feedback> GetFeedbackById(string id) => await _feedbackRepository.GetById(id);
        public async Task<List<Feedback>> GetFeedbacksByCourseId(string courseId) => await _feedbackRepository.GetByCondition(s => s.CoursesId == courseId);
        public async Task CreateFeedback(Feedback feedback) => await _feedbackRepository.Create(feedback);
        public async Task UpdateFeedback(Feedback feedback) => await _feedbackRepository.Update(feedback);
        public async Task DeleteFeedback(Feedback feedback) => await _feedbackRepository.Delete(feedback);
        public async Task SoftDeleteFeedback(string id) => await _feedbackRepository.SoftDelete(id);
    }
}
