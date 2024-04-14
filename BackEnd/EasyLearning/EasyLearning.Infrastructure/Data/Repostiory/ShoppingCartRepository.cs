using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Infrastructure.Data.Repostiory
{
    public class ShoppingCartRepository: GenericRepository<ShoppingCart>
    {
        public ShoppingCartRepository(EasyLearningDbContext dbContext, UserRepository userRepository) : base(dbContext, userRepository)
        { }
        public async Task<ShoppingCart> GetShoppingCartByUserIdAsync()
        {
           return await _dbContext.ShoppingCarts.FirstOrDefaultAsync(s => s.UserId == _userRepository.getCurrrentUser());
        }
    }
}
