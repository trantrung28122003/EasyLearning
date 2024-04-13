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
        public async Task<List<TranningPart>> GetTranningPartWithoutEventId()
        {
            return await _dbContext.TranningParts
                                    .Where(tp => tp.EventId == null)
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



    }
}
