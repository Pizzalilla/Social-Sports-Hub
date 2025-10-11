using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Social_Sport_Hub.Data;

namespace Social_Sport_Hub.Services
{
    // Generic EF Core implementation of IRepository.
    public sealed class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly SportsHubContext _context;
        private readonly DbSet<TEntity> _set;

        public EfRepository(SportsHubContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _set.AddAsync(entity);
            return entity;
        }

        public async Task<TEntity?> GetAsync(Guid id)
        {
            return await _set.FindAsync(id);
        }

        public Task UpdateAsync(TEntity entity)
        {
            _set.Update(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(TEntity entity)
        {
            _set.Remove(entity);
            return Task.CompletedTask;
        }

        public IQueryable<TEntity> Query() => _set.AsQueryable();

        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
