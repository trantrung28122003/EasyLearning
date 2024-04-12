using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Application.Services
{
    public class FeedbackService
    {
        private readonly FeedbackRepository _feedbackRepository;
        public FeedbackService(FeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<List<Feedback>> GetFeedback()
        {
            return await _feedbackRepository.GetAll();
        }

        public async Task<List<Feedback>> GetFeedbackById(string id)
        {
            return await _feedbackRepository.GetByCondition(s => s.Id == id);
        }

        public async Task CreateFeedback(Feedback feedback)
        {
            await _feedbackRepository.Create(feedback);
        }

        public async Task UpdateFeedback(Feedback feedback)
        {
            await _feedbackRepository.Update(feedback);
        }

        public async Task DeleteFeedback(Feedback feedback)
        {
            await _feedbackRepository.Delete(feedback);
        }

        public async Task SoftDeleteFeedback(string id)
        {
            await _feedbackRepository.SoftDelete(id);
        }
    }
}
