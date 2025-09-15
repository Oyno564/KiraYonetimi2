using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiraYonetimi.DataAcsses.Interfaces
{
    public  interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Queryable { get; }

        IQueryable<TEntity> AsQueryable { get; }
        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> Create(TEntity entity);

        Task<IEnumerable<TEntity>> ReadAllAsnyc ();

        Task<TEntity?> ReadAsync(int id);

        Task DeleteAsync (TEntity entity);

        Task DeleteAsync (int id);

        Task<IEnumerable<TEntity>> ReadAllAsync();

    }
}
