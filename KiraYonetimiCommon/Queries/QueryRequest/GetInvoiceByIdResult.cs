using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiraYonetimi.Common.Queries.QueryRequest
{
    public class GetInvoiceByIdResult
    {
        [Key]
        public Guid InvoicePkId { get; init; }

        public int InvoiceId { get; set; }

        public Guid ApartPkId { get; set; }

        public int ApartId { get; set; }

        public int InvoiceMonth { get; set; }

        public int InvoiceYear { get; set; }

        public decimal InvoiceAmount { get; set; }

        public bool InvoiceStatus { get; set; }
    }
}
