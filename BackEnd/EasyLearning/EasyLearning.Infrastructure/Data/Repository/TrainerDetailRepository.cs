using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Abstraction;

namespace EasyLearning.Infrastructure.Data.Repository
{
    public class TrainerDetailRepository : GenericRepository<TrainerDetail>
    {
        public TrainerDetailRepository(EasyLearningDbContext dbContext, UserRepository userRepository) : base(dbContext, userRepository)
        { }

    }
}
