using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace EasyLearning.Infrastructure.Data.Repository
{
    public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository(EasyLearningDbContext dbContext, UserRepository userRepository) : base(dbContext, userRepository) 
        { }

        public async Task<List<Order>> GetOrdersByUser()
        {
            return await _dbContext.Orders.Where(s => s.UserId == _userRepository.getCurrrentUser()).ToListAsync();
        }
    }
}
