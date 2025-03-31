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
    public class UserNoteRepository : GenericRepository<UserNote>
    {
        public UserNoteRepository(EasyLearningDbContext dbContext, UserRepository userRepository) : base(dbContext, userRepository)
        {
        }
        public async Task<List<UserNote?>> GetNotesByCourseIdAndUserId(string courseId, string userId)
        {
            return await _dbContext.UserNotes
                                    .Where(x => x.CourseId == courseId && x.UserId == userId).ToListAsync();

        }
    }
}
