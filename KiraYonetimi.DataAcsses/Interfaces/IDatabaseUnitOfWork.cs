using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiraYonetimi.DataAcsses.Interfaces
{
    public interface IDatabaseUnitOfWork: IDisposable
    {
         object WriteRepository { get; }

        Task Commit();
        Task SaveAsync();
    }
}
