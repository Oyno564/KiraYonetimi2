using KiraYonetimi.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiraYonetimi.DataAcsses.Interfaces
{
    public interface IApartUserRepository
    {

        IEnumerable<ApartUser> GetByApartId(int ApartId, int UserId);
    }
}