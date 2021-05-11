using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CS321_W5D2_BlogAPI.Core.Models;
using CS321_W5D2_BlogAPI.Core.Services;

namespace CS321_W5D2_BlogAPI.Infrastructure.Data
{
    public class Repository<T, TKey> where T : class, IEntity<TKey>
    {
        protected readonly AppDbContext _dbContext;
        protected DbSet<T> _dbSet => _dbContext.Set<T>();

        public IQueryable<T> Entities => _dbSet;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T Add(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public virtual T Get(TKey id)
        {
            return _dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual T Update(T updatedItem)
        {
            var existingItem = _dbSet.Find(updatedItem.Id);
            if (existingItem == null) return null;
            _dbContext.Entry(existingItem)
               .CurrentValues
               .SetValues(updatedItem);
            _dbSet.Update(existingItem);
            _dbContext.SaveChanges();
            return existingItem;
        }

        public virtual void Remove(TKey id)
        {
            var item = _dbSet.Find(id);
            this.Remove(item);
        }

        public virtual void Remove(T entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
