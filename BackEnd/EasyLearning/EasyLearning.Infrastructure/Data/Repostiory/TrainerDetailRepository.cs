using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Abstraction;

namespace EasyLearning.Infrastructure.Data.Repostiory
{
    public class TrainerDetailRepository : GenericRepository<TrainnerDetail>
    {
        public TrainerDetailRepository(EasyLearningDbContext dbContext, UserRepository userRepository) : base(dbContext, userRepository)
        { }
    }
}
