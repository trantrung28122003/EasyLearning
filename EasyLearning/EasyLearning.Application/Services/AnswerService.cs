using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Application.Services
{
    public interface  IAnswerService
    {
        Task<List<Answer>> GetAllAnswer();
        Task<List<Answer>> GetAnswerByQuestion(string id);
        Task CreateAnswer(Answer answer);
        Task UpdateAnswer(Answer answer);
        Task DeleteAnswer(Answer answer);
        Task SoftDeleteAnswer(string id);
    }
    public class AnswerService : IAnswerService
    {
        private readonly AnswerRepository _answerRepository;
        public AnswerService(AnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }
        public async Task<List<Answer>> GetAllAnswer() => await _answerRepository.GetAll();
        public async Task<List<Answer>> GetAnswerByQuestion(string id) => await _answerRepository.GetByCondition(x => x.QuestionId == id);
        public async Task CreateAnswer(Answer Answer) => await _answerRepository.Create(Answer);
        public async Task UpdateAnswer(Answer Answer) => await _answerRepository.Update(Answer);
        public async Task DeleteAnswer(Answer Answer) => await _answerRepository.Delete(Answer);
        public async Task SoftDeleteAnswer(string id) => await _answerRepository.SoftDelete(id);
    }
}
