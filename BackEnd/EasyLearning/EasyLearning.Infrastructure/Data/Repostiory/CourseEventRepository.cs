using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace EasyLearning.Infrastructure.Data.Repostiory
{
    public class CourseEventRepository : GenericRepository<CourseEvent>
    {   
        public CourseEventRepository(EasyLearningDbContext dbContext, UserRepository userRepository) : base(dbContext, userRepository)   
        {
        }
        public async Task<List<CourseEvent>> GetEventByCourse(string courseId)
        {
            return await _dbContext.TranningParts.AsNoTracking()
                                            .Include(tp => tp.CourseEvent)
                                            .Where(tp => tp.CoursesId == courseId && tp.CourseEvent != null)
                                            .Select(tp => tp.CourseEvent)
                                            .ToListAsync();
        }
        
    }
}
