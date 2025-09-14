using KiraYonetimi.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KiraYonetimi.DataAcsses.Interfaces
{
    public interface IUserRepository
    {
        // Mail unique ise tek User döndürsün
        Task<User?> GetByMailAsync(string email);

        // Tüm kullanıcıları döndür
        Task<List<User>> GetAllAsync();

        // Password’den UserId döndür (birden fazla olabilir)
        Task<List<int>> GetUserIdsByPasswordAsync(string password);
    }
}
