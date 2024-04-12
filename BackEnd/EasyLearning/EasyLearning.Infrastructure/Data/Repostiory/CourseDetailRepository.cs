using EasyLearning.Infrastructure.Data.Abstraction;
using EasyLearning.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Infrastructure.Data.Repostiory
{
    public class CourseDetailRepository : GenericRepository<CourseDetail>
    {
        public CourseDetailRepository(EasyLearningDbContext dbContext) : base(dbContext) 
        { }
    }
}
