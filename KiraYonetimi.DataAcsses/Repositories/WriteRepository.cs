using KiraYonetimi.DataAcsses.Context;
using KiraYonetimi.DataAcsses.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace KiraYonetimi.DataAcsses.Repositories
{
    public  class WriteRepository<T> : IWriteRepository<T> where T : class
    {


        readonly private KiraContext _context;

        public WriteRepository(KiraContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => throw new NotImplementedException();

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddAsync(T model)
        {
           
        }

        public Task<bool> AddAsync(List<T> model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddRangeAsync(List<T> model)
        {
            await Table.AddRangeAsync(model);
            return true;
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T model)
        {
           
        }



        public bool RemoveRange(List<T> model)
        {
           
        }

        public async Task<int> SaveAsync()

        { return await _context.SaveChangesAsync(); }

        private int Ok() //burda bişi deniyom
        {
            throw new NotImplementedException();
        }

        public bool Update(T model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }

        void IRepository<T>.Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
*/