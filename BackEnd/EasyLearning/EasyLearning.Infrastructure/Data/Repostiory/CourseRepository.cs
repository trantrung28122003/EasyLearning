using EasyLearning.Infrastructure.Data.Abstraction;
using EasyLearning.Infrastructure.Data.Entities;

namespace EasyLearning.Infrastructure.Data.Repostiory
{
    public class CourseRepository : GenericRepository<Course>
    {
        public CourseRepository(EasyLearningDbContext dbContext, UserRepository userRepository) : base(dbContext, userRepository)
        {
        }
    }
}
