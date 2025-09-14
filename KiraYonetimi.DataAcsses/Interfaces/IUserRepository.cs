using KiraYonetimi.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KiraYonetimi.DataAcsses.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetByMail(string email, int userId);
        Task<List<User>> GetAllAsync();

        IEnumerable<User> GetByPassword( string password);
    }
}
