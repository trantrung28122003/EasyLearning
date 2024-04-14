using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Abstraction;
using EasyLearning.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyLearning.Infrastructure.Data.Repostiory
{
    public class CourseRepository : GenericRepository<Course>
    {
        public CourseRepository(EasyLearningDbContext dbContext, UserRepository userRepository) : base(dbContext, userRepository)
        {
        }
        public async Task<Course> GetCourseDetailsById(string id)
        {
            return await _dbContext.Courses.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Course>> GetcourseByUser()
        {
            return await _dbContext.TrannerDetails.AsNoTracking()
                                            .Include(s =>s.Courses)
                                            .Where(s => s.UserId == _userRepository.getCurrrentUser())
                                            .Select(s=>s.Courses)
                                            .ToListAsync();
        }
    }
}
