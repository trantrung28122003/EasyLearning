using EasyLearning.Infrastructure.Data.Abstraction;
using EasyLearning.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Infrastructure.Data.Repostiory
{
    public class AddOnRepository : GenericRepository<AddOn>
    {
        public AddOnRepository(EasyLearningDbContext dbContext, UserRepository userRepository) : base (dbContext, userRepository) 
        {  }
    }
}
