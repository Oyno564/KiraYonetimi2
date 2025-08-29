using KiraYonetimi.DataAcsses.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiraYonetimi.DataAcsses.Context;


namespace KiraYonetimi.DataAcsses.Repositories
{
    public class EntityFrameworkRepository<T> : IRepository<T> where T : class
    {

        private readonly KiraContext _DbContext;
        private readonly DbSet<T> _DbSet;


        public EntityFrameworkRepository(KiraContext context)
        {
            this. _DbContext = context;
            this._DbSet = this._DbContext.Set<T>();
        }
        public void Add(T entity)
        {
           this._DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
           this._DbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
           return this._DbSet.ToList();
        }

        public T GetById(int id)
        {
               return this._DbSet.Find(id);
        }  

      
        public void Update(T entity)
        {
            this._DbSet.Attach(entity);
                this._DbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
