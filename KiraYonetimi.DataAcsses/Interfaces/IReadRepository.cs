using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KiraYonetimi.DataAcsses.Interfaces
{
    public  interface IReadRepository<T>
    {
        IQueryable<T> GetAll();
        
        IQueryable<T> GetWhere (Expression<Func<T, bool>> method);

        Task<T> GetByPkIdAsync (int id);
    }
}
