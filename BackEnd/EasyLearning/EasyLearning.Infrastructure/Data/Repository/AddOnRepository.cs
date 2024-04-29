using EasyLearning.Infrastructure.Data.Abstraction;
using EasyLearning.Infrastructure.Data.Entities;

namespace EasyLearning.Infrastructure.Data.Repository
{
    public class AddOnRepository : GenericRepository<AddOn>
    {
        public AddOnRepository(EasyLearningDbContext dbContext, UserRepository userRepository) : base (dbContext, userRepository) 
        {  }
    }
}
