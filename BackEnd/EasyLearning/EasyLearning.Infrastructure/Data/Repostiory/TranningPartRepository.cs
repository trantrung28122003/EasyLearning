using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace EasyLearning.Infrastructure.Data.Repostiory
{
    public class TranningPartRepository : GenericRepository<TranningPart>
    {
        public TranningPartRepository(EasyLearningDbContext dbContext, UserRepository userRepository) : base(dbContext, userRepository)
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
