using KiraYonetimi.Entities.Common;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    IQueryable<TEntity> Query{ get; }
    Task<TEntity> CreateAsync(TEntity entity, CancellationToken ct = default);
    Task<TEntity?> ReadAsync(Guid id, CancellationToken ct = default);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct = default);
    Task DeleteAsync(TEntity entity, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);
}
