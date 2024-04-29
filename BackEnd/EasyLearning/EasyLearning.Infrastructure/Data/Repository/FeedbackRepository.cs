using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Abstraction;

namespace EasyLearning.Infrastructure.Data.Repository
{
    public class FeedbackRepository: GenericRepository<Feedback>
    {
        public FeedbackRepository(EasyLearningDbContext dbContext, UserRepository userRepository) : base(dbContext, userRepository)
        { }
    }
}
