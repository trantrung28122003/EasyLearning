using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Abstraction;

namespace EasyLearning.Infrastructure.Data.Repostiory
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(EasyLearningDbContext dbcontext, UserRepository userRepository) : base(dbcontext, userRepository) 
        { }
    }
}
