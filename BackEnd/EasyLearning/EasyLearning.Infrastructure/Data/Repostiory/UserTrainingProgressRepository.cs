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
    public class UserTrainingProgressRepository : GenericRepository<UserTrainingProgress>
    {
        public UserTrainingProgressRepository(EasyLearningDbContext dbContext, UserRepository userRepository) : base(dbContext, userRepository)
        {
        }
        public async Task<UserTrainingProgress?> GetUserTrainingProgressByTrainingPartIdAndUserId(string trainingPartId, string userId)
        {
            return await _dbContext.UserTrainingProgresss
                                    .FirstOrDefaultAsync(x => x.TrainingPartId == trainingPartId && x.UserId == userId);
                                   
        }
       
    }
}
