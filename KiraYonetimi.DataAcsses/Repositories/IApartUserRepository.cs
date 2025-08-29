using KiraYonetimi.Entities.Entities;

namespace KiraYonetimi.DataAcsses.Repositories
{
    internal interface IApartUserRepository
    {

        IEnumerable<ApartUser> GetByApartId(int ApartId, int UserId);
    }
}