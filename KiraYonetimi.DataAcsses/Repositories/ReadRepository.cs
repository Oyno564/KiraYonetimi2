using KiraYonetimi.DataAcsses.Context;
using KiraYonetimi.DataAcsses.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
/*
namespace KiraYonetimi.DataAcsses.Repositories
{


    public class ReadRepository<T> : IReadRepository<T> where T : class
    {

        private readonly KiraContext _context;

        public ReadRepository(KiraContext context)
        {
            _context = context;
        }



        public DbSet<T> Table => _context.Set<T>();

        public void Add(T entity)  //silinecek
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity) ///silinecek
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
            => Table;

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByPkIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
       => Table.Where(method);

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
*/