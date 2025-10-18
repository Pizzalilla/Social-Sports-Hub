using System;
using System.Linq;
using System.Threading.Tasks;
using Social_Sport_Hub.Data.Models;


namespace Social_Sport_Hub.Services
{
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
