using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Social_Sport_Hub.Utilities
{
    public class GenericCache<TEntity> where TEntity : class
    {
        private readonly Dictionary<Guid, TEntity> _cache = new();
        private readonly Func<TEntity, Guid> _keySelector;

        public GenericCache(Func<TEntity, Guid> keySelector)
        {
            _keySelector = keySelector;
        }

        public void Add(TEntity entity)
        {
            var key = _keySelector(entity);
            _cache[key] = entity;
        }

        public TEntity? Get(Guid id)
        {
            return _cache.TryGetValue(id, out var entity) ? entity : null;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _cache.Values;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _cache.Values.AsQueryable().Where(predicate);
        }

        public void Remove(Guid id)
        {
            _cache.Remove(id);
        }

        public void Clear()
        {
            _cache.Clear();
        }

        public int Count => _cache.Count;
    }
}