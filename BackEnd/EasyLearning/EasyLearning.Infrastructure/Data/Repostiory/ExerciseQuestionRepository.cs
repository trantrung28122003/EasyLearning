using EasyLearning.Infrastructure.Data.Abstraction;
using EasyLearning.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Infrastructure.Data.Repostiory
{
    public class ExerciseQuestionRepository : GenericRepository<ExerciseQuestion>
    {
        public ExerciseQuestionRepository(EasyLearningDbContext dbContext, UserRepository userRepository) : base(dbContext, userRepository)
        {
        }

        public async Task<List<ExerciseQuestion>> GetAllQuestionsAndAnswer(string trainingPartId)
        {
            return await _dbContext.ExerciseQuestions.Where(x => x.TrainingPartId == trainingPartId)
                                                    .Include(x => x.Answers).ToListAsync();
        }
    }
}
