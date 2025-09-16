using KiraYonetimi.DataAcsses.Context;
using KiraYonetimi.DataAcsses.Interfaces;
using KiraYonetimi.Entities.Common;


namespace KiraYonetimi.DataAcsses.UnitOfWorks;
public interface IDatabaseUnitOfWork
{


    IRepository<TEntity> GetRepository<TEntity>()
        where TEntity : BaseEntity, new();

    KiraContext GetDataContext();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}