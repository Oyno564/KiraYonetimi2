using KiraYonetimi.DataAcsses.Interfaces;
using KiraYonetimi.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiraYonetimi.DataAcsses.Interfaces;
using KiraYonetimi.DataAcsses.Interfaces;
using KiraYonetimi.DataAcsses.Context;


namespace KiraYonetimi.DataAcsses.Repositories
{
    public class ApartUserRepository : ReadRepository<ApartUser>, IApartUserRepository
    {
        public ApartUserRepository(KiraContext context) : base(context)
        {
        }


      

        IEnumerable<ApartUser> IApartUserRepository.GetByApartId(int ApartId, int UserId)
        {
            throw new NotImplementedException();
        }
    }
}