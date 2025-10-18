using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Social_Sport_Hub.Data;


namespace Social_Sport_Hub.Services
{
    public sealed class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly SportsHubContext _db;
        private readonly DbSet<TEntity> _set;

        public EfRepository(SportsHubContext db)
        {
            _db = db;
            _set = _db.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity) { await _set.AddAsync(entity); return entity; }
        public Task<TEntity?> GetAsync(Guid id) => _set.FindAsync(id).AsTask();
        public Task UpdateAsync(TEntity entity) { _set.Update(entity); return Task.CompletedTask; }
        public Task DeleteAsync(TEntity entity) { _set.Remove(entity); return Task.CompletedTask; }
        public IQueryable<TEntity> Query() => _set.AsQueryable();
        public Task<int> SaveChangesAsync() => _db.SaveChangesAsync();
    }
}
