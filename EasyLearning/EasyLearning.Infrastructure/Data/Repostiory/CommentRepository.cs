using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data;
using EasyLearning.Infrastructure.Data.Abstraction;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Infrastructure.Data.Repostiory
{
    public class CommentRepository : GenericRepository<Comment>
    {
        public CommentRepository(EasyLearningDbContext dbcontext, UserRepository userRepository) : base(dbcontext, userRepository)
        { }
        public async Task<List<Comment>> GetAllCommentsWithRepliesByTrainingPart(string trainingPartId)
        {
            return await _dbContext.Comments.Include(x => x.Replies)
                                    .Where(s => s.TrainingPartId == trainingPartId)
                                    .ToListAsync();
        }
    }

}
