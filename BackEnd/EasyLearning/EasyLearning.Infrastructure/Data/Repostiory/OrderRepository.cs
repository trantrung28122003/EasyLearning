using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Abstraction;

namespace EasyLearning.Infrastructure.Data.Repostiory
{
    public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository(EasyLearningDbContext dbContext, UserRepository userRepository) : base(dbContext, userRepository) 
        { }
    }
}
