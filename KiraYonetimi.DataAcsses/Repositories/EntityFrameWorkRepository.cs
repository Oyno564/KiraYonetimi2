using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KiraYonetimi.DataAcsses.Context;
using KiraYonetimi.DataAcsses.Interfaces;
using KiraYonetimi.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace KiraYonetimi.DataAcsses.Repositories
{
    public class EntityFrameworkRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity, new()
    {
        protected readonly KiraContext _context;
        protected DbSet<TEntity> Table => _context.Set<TEntity>();   // ← SADECE BİR KEZ!

        public EntityFrameworkRepository(KiraContext context)
        {
            _context = context;
        }

        // IRepository ile aynı isim: Query
        public IQueryable<TEntity> Query => Table.AsNoTracking();

        public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken ct = default)
        {
            if (entity.PkId == Guid.Empty)
                entity.PkId = Guid.NewGuid();

            entity.CreatedDate = DateTime.UtcNow;

            await Table.AddAsync(entity, ct);
            await _context.SaveChangesAsync(ct);
            return entity;
        }

        public Task<TEntity?> ReadAsync(Guid id, CancellationToken ct = default)
            => Table.AsNoTracking().FirstOrDefaultAsync(e => e.PkId == id, ct);

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct = default)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            Table.Update(entity);
            await _context.SaveChangesAsync(ct);
            return entity;
        }

        public async Task DeleteAsync(TEntity entity, CancellationToken ct = default)
        {
            Table.Remove(entity);
            await _context.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct = default)
        {
            var entity = await ReadAsync(id, ct);
            if (entity is null) return;
            Table.Remove(entity);
            await _context.SaveChangesAsync(ct);
        }
    }
}
