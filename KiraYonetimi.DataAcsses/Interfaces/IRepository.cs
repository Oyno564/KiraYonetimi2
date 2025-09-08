using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiraYonetimi.DataAcsses.Interfaces
{
    public interface IRepository <T> where T : class
    {

        DbSet<T> Table { get; }
        T GetById (int id);

        void Add( T entity);
        void Update ( T entity );

        void Delete (T entity );
    }
}
