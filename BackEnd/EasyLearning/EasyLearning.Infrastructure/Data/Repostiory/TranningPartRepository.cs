using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Infrastructure.Data.Repostiory
{
    public class TranningPartRepository : GenericRepository<TranningPart>
    {
        public TranningPartRepository(EasyLearningDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<TranningPart>> GetTranningPartWithoutEventId(string id)
        {
            return await _dbContext.TranningParts
                                    .Where(s => s.EventId == null && s.CoursesId == id)
                                    .ToListAsync();
        }

        public async Task UpdateTranningPartWithEvent(string tranningPartId, string eventId)
        {
            var tranningPart = await _dbContext.TranningParts.FirstOrDefaultAsync(tp => tp.Id == tranningPartId);
            if (tranningPart != null)
            {
                tranningPart.EventId = eventId;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateCourseEventIdToNull(string eventId)
        {
            var tranningDetails = await _dbContext.TranningParts
                .Where(s => s.EventId == eventId)
                .ToListAsync();

            foreach (var tranningDetail in tranningDetails)
            {
                tranningDetail.EventId = null;
            }
            await _dbContext.SaveChangesAsync();
        }



    }
}
