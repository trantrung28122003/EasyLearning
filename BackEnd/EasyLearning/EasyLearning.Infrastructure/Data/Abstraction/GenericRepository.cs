using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EasyLearning.Infrastructure.Data.Abstraction
{
    public interface IGenericRepository<TEntity> where TEntity : GenericEntity
    {
        Task<List<TEntity>> GetAll();

        Task<List<TEntity>> GetByCondition<TResult>(Expression<Func<TEntity, bool>> selector);

        Task Create(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(TEntity entity);

        Task SoftDelete(string id);
    }
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : GenericEntity
    {

        private readonly EasyLearningDbContext _dbContext;

        public GenericRepository(EasyLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TEntity>> GetAll() => await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();

        public async Task<List<TEntity>> GetByCondition<TResult>(Expression<Func<TEntity, bool>> selector)
            => await _dbContext.Set<TEntity>().AsNoTracking().Where(selector).ToListAsync();

        public async Task Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task SoftDelete(string id)
        {
            GenericEntity? item = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
            if (item != null)
            {
                item.IsDeleted = true;
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
