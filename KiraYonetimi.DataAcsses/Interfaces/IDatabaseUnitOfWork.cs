using KiraYonetimi.DataAcsses.Context;
using KiraYonetimi.DataAcsses.Interfaces;


namespace KiraYonetimi.DataAcsses.UnitOfWorks;
public interface IDatabaseUnitOfWork
{
    IRepository<TEntity> GetRepository<TEntity>()
        where TEntity : class;

    KiraContext GetDataContext();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}