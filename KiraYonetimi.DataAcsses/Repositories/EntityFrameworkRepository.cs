using KiraYonetimi.DataAcsses.Context;
using KiraYonetimi.DataAcsses.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KiraYonetimi.DataAcsses.Repositories
{
    public class EntityFrameworkRepository<T> : IRepository<T> where T : class
    {
        private readonly KiraContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public EntityFrameworkRepository(KiraContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();
        }

        // READ OPERATIONS
      

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        // WRITE OPERATIONS
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        Task<IList<T>> GetAllAsync(
     Expression<Func<T, bool>>? predicate = null,
     Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
     Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null,
     bool enableTracking = false);


        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        // OPTIONAL: Save changes
        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

     

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllAsync()
        {
           return _dbSet .ToList();
        }
    }
}
