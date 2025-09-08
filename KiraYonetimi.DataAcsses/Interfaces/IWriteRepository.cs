using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiraYonetimi.DataAcsses.Interfaces
{
    internal interface IWriteRepository<T> : IRepository<T> where T : class
    {

 Task<bool> AddAsync ( T model );

       Task<bool> AddAsync ( List<T> model );

        Task<bool> AddRangeAsync(List<T> model);

   
    bool Remove (T model);

    bool Update ( T model );

    Task<int> SaveAsync();

        bool RemoveRange (List<T> model);
      
    }
}
