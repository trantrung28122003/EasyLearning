using EasyLearning.Infrastructure.Data.Abstraction;
using EasyLearning.Infrastructure.Data.Entities;

namespace EasyLearning.Infrastructure.Data.Repository
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(EasyLearningDbContext dbcontext, UserRepository userRepository) : base(dbcontext, userRepository) 
        { }
    }
}
