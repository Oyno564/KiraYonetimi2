using KiraYonetimi.Entities.Entities;
using KiraYonetimi.DataAcsses.Interfaces;

namespace KiraYonetimi.DataAcsses.Interfaces
{
    public interface IApartUserRepository : IRepository<ApartUser>
    {
        Task<List<ApartUser>> GetByApartIdAsync(int apartId, int? userId = null, CancellationToken ct = default);
    }

}
