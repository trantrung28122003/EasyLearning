using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Abstraction;

namespace EasyLearning.Infrastructure.Data.Repostiory
{
    public class TrannerDetailRepository : GenericRepository<TrainnerDetail>
    {
        public TrannerDetailRepository(EasyLearningDbContext dbContext) : base(dbContext)
        { }
    }
}
