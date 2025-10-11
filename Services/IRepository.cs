using System;
using System.Linq;
using System.Threading.Tasks;

namespace Social_Sport_Hub.Services
{
    // Generic repository abstraction for EF Core entities.
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity?> GetAsync(Guid id);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        IQueryable<TEntity> Query();
        Task<int> SaveChangesAsync();
    }
}
