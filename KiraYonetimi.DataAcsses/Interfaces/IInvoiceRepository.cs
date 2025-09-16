using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiraYonetimi.Entities.Entities;
namespace KiraYonetimi.DataAcsses.Interfaces
{
   public  interface IInvoiceRepository
    {
        IEnumerable<Invoice> GetInvoiceByApartId(int InvoiceId, int ApartId);

    
    }
}
