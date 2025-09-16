// DatabaseUnitOfWork.cs
using System;
using System.Threading;
using System.Threading.Tasks;
using KiraYonetimi.DataAcsses.Context;
using KiraYonetimi.DataAcsses.Interfaces;
using KiraYonetimi.Entities.Common;
using Microsoft.Extensions.DependencyInjection;

namespace KiraYonetimi.DataAcsses.UnitOfWorks
{
    public sealed class DatabaseUnitOfWork : IDatabaseUnitOfWork, IAsyncDisposable
    {
        private readonly KiraContext _context;
        private readonly IServiceProvider _sp;

        public DatabaseUnitOfWork(KiraContext context, IServiceProvider sp)
        {
            _context = context;
            _sp = sp;
        }

        public IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : BaseEntity, new()
            => _sp.GetRequiredService<IRepository<TEntity>>();

        public KiraContext GetDataContext() => _context;

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
            => _context.SaveChangesAsync(cancellationToken);

        public ValueTask DisposeAsync() => _context.DisposeAsync();
    }
}
