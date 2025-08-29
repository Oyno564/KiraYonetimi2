using KiraYonetimi.DataAcsses.Interfaces;
using KiraYonetimi.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiraYonetimi.DataAcsses.Interfaces;
using KiraYonetimi.DataAcsses.Context;

namespace KiraYonetimi.DataAcsses.Repositories
{
    public class InvoiceRepository : EntityFrameworkRepository<Invoice>, IInvoiceRepository
    {

        private readonly KiraContext _DbContext;
        public InvoiceRepository(KiraContext context) : base(context)
        {
            this._DbContext = context;
        }

        public IEnumerable<Invoice> GetByInvoice(int InvoiceId, int ApartId)
        {
           return (from Invoice in _DbContext.Invoices
                   where Invoice.InvoiceId == InvoiceId && Invoice.ApartId == ApartId
                   select Invoice).ToList(); 
        }
    }
} 
