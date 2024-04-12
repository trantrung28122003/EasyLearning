using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Infrastructure.Data.Repostiory
{
    public class FeedbackRepository: GenericRepository<Feedback>
    {
        public FeedbackRepository(EasyLearningDbContext dbContext) : base(dbContext)
        { }
    }
}
