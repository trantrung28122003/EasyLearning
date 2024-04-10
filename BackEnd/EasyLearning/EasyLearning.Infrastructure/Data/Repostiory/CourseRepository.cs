using EasyLearing.Models;
using EasyLearning.Infrastructure.Data.Abstraction;

namespace EasyLearning.Infrastructure.Data.Repostiory
{
    public class CourseRepository : GenericRepository<Course>
    {
        public CourseRepository(EasyLearningDbContext dbContext) : base(dbContext)
        {
        }
    }
}
