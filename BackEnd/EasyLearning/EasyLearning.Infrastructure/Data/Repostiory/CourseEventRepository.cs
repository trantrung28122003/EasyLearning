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
    public class CourseEventRepository : GenericRepository<CourseEvent>
    {
        public CourseEventRepository(EasyLearningDbContext dbContext) : base(dbContext)   
        {
        }
        public async Task<List<CourseEvent>> GetEventByCourse(string courseId)
        {
            return await _dbContext.TranningParts.AsNoTracking()
                                            .Include(tp => tp.CourseEvent)
                                            .Where(tp => tp.CoursesId == courseId)
                                            .Select(tp => tp.CourseEvent)
                                            .ToListAsync();
        }
    }
}
