using EasyLearning.Infrastructure.Data.Repostiory;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EasyLearning.Infrastructure.Data.Abstraction
{
    public interface IGenericRepository<TEntity> where TEntity : GenericEntity
    {
        Task<List<TEntity>> GetAll();

        Task<List<TEntity>> GetAllActive();  

        Task<List<TEntity>> GetByCondition(Expression<Func<TEntity, bool>> selector);
        Task<TEntity?> GetById(string id);

        Task Create(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(TEntity entity);

        Task SoftDelete(string id);
    }
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : GenericEntity
    {

        public readonly EasyLearningDbContext _dbContext;
        private readonly UserRepository _userRepository;

        public GenericRepository(EasyLearningDbContext dbContext, UserRepository userRepository)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;
        }

        public async Task<List<TEntity>> GetAll() => await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();

        public async Task<List<TEntity>> GetByCondition(Expression<Func<TEntity, bool>> selector)
            => await _dbContext.Set<TEntity>().AsNoTracking().Where(selector).ToListAsync();


        public async Task Create(TEntity entity)
        {
            entity.DateCreate = DateTime.Now;
            entity.ChangedBy = _userRepository.getCurrrentUser();
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    await _dbContext.Set<TEntity>().AddAsync(entity);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                    
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                }
            }
        }

        public async Task Update(TEntity entity)
        {
            entity.DateChange = DateTime.Now;
            entity.ChangedBy = _userRepository.getCurrrentUser();
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Set<TEntity>().Update(entity);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                }
            }
        }
        public async Task Delete(TEntity entity)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Set<TEntity>().Remove(entity);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                }
            }
        }
        public async Task SoftDelete(string id)
        {
            TEntity? item = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
            
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (item != null)
                    {
                        item.IsDeleted = true;
                        item.DateChange = DateTime.Now;
                        item.ChangedBy = _userRepository.getCurrrentUser();
                        _dbContext.Set<TEntity>().Update(item);
                    }   
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                }
            }
        }

        public async Task<TEntity?> GetById(string id) => await _dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<TEntity>> GetAllActive() => await _dbContext.Set<TEntity>().Where(x=>x.IsDeleted).AsNoTracking().ToListAsync();
    }
}
