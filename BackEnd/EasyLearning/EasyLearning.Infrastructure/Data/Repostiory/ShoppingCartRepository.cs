using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace EasyLearning.Infrastructure.Data.Repostiory
{
    public class ShoppingCartRepository: GenericRepository<ShoppingCart>
    {
        public ShoppingCartRepository(EasyLearningDbContext dbContext, UserRepository userRepository) : base(dbContext, userRepository)
        { }
        public async Task<ShoppingCart> GetShoppingCartByUserIdAsync(string userId)
        {
           return await _dbContext.ShoppingCarts.FirstOrDefaultAsync(cart => cart.UserId == userId);
        }
    }
}
