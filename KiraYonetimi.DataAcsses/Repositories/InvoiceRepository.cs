using KiraYonetimi.DataAcsses.Interfaces;
using KiraYonetimi.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiraYonetimi.DataAcsses.Interfaces;
using KiraYonetimi.DataAcsses.Context;
using Microsoft.EntityFrameworkCore;

namespace KiraYonetimi.DataAcsses.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly KiraContext _context;

        public InvoiceRepository(KiraContext context)
        {
            _context = context;
        }

        public IEnumerable<Invoice> GetInvoiceByApartId(int InvoiceId, int ApartId)
        {
            return _context.Invoices
                           .Where(u => u.InvoiceId == InvoiceId && u.ApartId == ApartId)
                           .ToList();
        }

   
    






    }
}
