using KiraYonetimi.DataAcsses.Context;
using KiraYonetimi.DataAcsses.Interfaces;
using KiraYonetimi.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace KiraYonetimi.DataAcsses.Repositories
{
    public sealed class ApartUserRepository
      : EntityFrameworkRepository<ApartUser>, IApartUserRepository
    {
        public ApartUserRepository(KiraContext context) : base(context) { }

        public async Task<List<ApartUser>> GetByApartIdAsync(int apartuserId, int? userId = null, CancellationToken ct = default)
        {
            var q = Table.AsNoTracking().Where(x => x.ApartUserId == apartuserId);
            if (userId.HasValue) q = q.Where(x => x.UserId == userId.Value);
            return await q.ToListAsync(ct);
        }
    }
}
