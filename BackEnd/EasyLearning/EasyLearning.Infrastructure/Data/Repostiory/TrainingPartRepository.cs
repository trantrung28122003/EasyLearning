using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace EasyLearning.Infrastructure.Data.Repostiory
{
    public class TrainingPartRepository : GenericRepository<TrainingPart>
    {
        public TrainingPartRepository(EasyLearningDbContext dbContext, UserRepository userRepository) : base(dbContext, userRepository)
        {
        }
        public async Task<List<TrainingPart>> GetTrainingPartWithoutEventId(string id)
        {
            return await _dbContext.TrainingParts
                                    .Where(s => s.EventId == null && s.CoursesId == id)
                                    .ToListAsync();
        }

        public async Task UpdateTrainingPartWithEvent(string TrainingPartId, string eventId)
        {
            var TrainingPart = await _dbContext.TrainingParts.FirstOrDefaultAsync(tp => tp.Id == TrainingPartId);
            if (TrainingPart != null)
            {
                TrainingPart.EventId = eventId;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateCourseEventIdToNull(string eventId)
        {
            var TrainingDetails = await _dbContext.TrainingParts
                .Where(s => s.EventId == eventId)
                .ToListAsync();

            foreach (var TrainingDetail in TrainingDetails)
            {
                TrainingDetail.EventId = null;
            }
            await _dbContext.SaveChangesAsync();
        }



    }
}
