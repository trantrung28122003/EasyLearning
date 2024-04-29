using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Abstraction;

namespace EasyLearning.Infrastructure.Data.Repository
{
    public class ShoppingCartItemRepository : GenericRepository<ShoppingCartItem>
    {
        public ShoppingCartItemRepository(EasyLearningDbContext dbContext, UserRepository userRepository) : base(dbContext, userRepository)
        { }
    }
}
