using EasyLearning.Infrastructure.Data.Abstraction;
using EasyLearning.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyLearning.Infrastructure.Data.Repository
{
    public class CourseRepository : GenericRepository<Course>
    {
        public CourseRepository(EasyLearningDbContext dbContext, UserRepository userRepository) : base(dbContext, userRepository)
        {
        }
        /*public async Task<Course> GetCourseDetailsById(string id)
        {
            return await _dbContext.Courses.FirstOrDefaultAsync(x => x.Id == id);
        }*/

        public async Task<List<Course>> GetCourseByOrderDetail(string orderDetail)
        {
            return await _dbContext.OrderDetails.Include(s => s.Courses)
                                                .Where(s=>s.Id == orderDetail)
                                                .Select(s=>s.Courses).ToListAsync();
        }
  
    }
}
