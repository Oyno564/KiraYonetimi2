using KiraYonetimi.DataAcsses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiraYonetimi.Entities.Entities;
using KiraYonetimi.DataAcsses.Context;


namespace KiraYonetimi.DataAcsses.Repositories
{
    public class DatabaseUnitOfWork : IDatabaseUnitOfWork
    {

        private readonly KiraContext _kiraContext;

        public DatabaseUnitOfWork( KiraContext context)
        {
            this._kiraContext = context;
            this.InvoiceRepository = new InvoiceRepository(this._kiraContext);
            this.UserRepository = new UserRepository(this._kiraContext);

        }

        public InvoiceRepository InvoiceRepository { get; private set; }
        public UserRepository UserRepository { get; private set; }

        public object WriteRepository => throw new NotImplementedException();

        public async Task Commit()
        {
            await this._kiraContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            this._kiraContext.Dispose();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
