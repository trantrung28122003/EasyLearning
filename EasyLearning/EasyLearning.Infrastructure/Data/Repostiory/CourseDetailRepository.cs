using EasyLearning.Infrastructure.Data.Abstraction;
using EasyLearning.Infrastructure.Data.Entities;

namespace EasyLearning.Infrastructure.Data.Repostiory
{
    public class CourseDetailRepository : GenericRepository<CourseDetail>
    {
        public CourseDetailRepository(EasyLearningDbContext dbContext, UserRepository userRepository) : base(dbContext, userRepository) 
        { }
    }
}
