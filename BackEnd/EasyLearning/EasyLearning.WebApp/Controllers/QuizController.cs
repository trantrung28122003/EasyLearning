using EasyLearning.Application.Services;
using EasyLearning.Infrastructure.Data.Repostiory;
using Microsoft.AspNetCore.Mvc;

namespace EasyLearning.WebApp.Controllers
{
    [ApiController]
    [Route("api/Quiz")]
    public class QuizController : ControllerBase
    {
        private readonly IExerciseQuestionService _exerciseQuestionService;

        public QuizController(IExerciseQuestionService exerciseQuestionService)
        {
            _exerciseQuestionService = exerciseQuestionService;
        }

        [HttpGet]
        [Route("GetQuizData")]
        public async Task<IActionResult> GetQuizData(string trainingPartId)
        {
            var listQuestion = await _exerciseQuestionService.GetAllQuestionsAndAnswer(trainingPartId);

            var quizData = listQuestion.Select(x => new
            {
                quetionId = x.Id,
                question = x.Question,
                options = x.Answers.Select(p => p.Text).ToList(),
                correct = x.Answers.FirstOrDefault(a => a.IsCorrect == true)?.Text
            });
            return Ok(quizData);
        }

        [HttpPost]
    
        public async Task<IActionResult> SubmitQuizResults(string trainingPartId, string correctQuestionIds)
        {
            try
            {

                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Lỗi: {ex.Message}");
            }
        }
    }
}
