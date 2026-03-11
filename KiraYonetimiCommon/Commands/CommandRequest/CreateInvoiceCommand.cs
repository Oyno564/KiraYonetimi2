using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiraYonetimi.Common.Commands.CommandRequest
{
  public  class CreateInvoiceCommand : IRequest<Guid>
    {
        public Guid InvoicePkId { get; init; }

        public Guid ApartmentPkId { get; init; }

        public int InvoiceMonth { get; init; }

        public int InvoiceYear { get; init; }

        public bool InvoiceStatus { get; set; }  // true is ödenmemiş false ise ödenmiş

        public decimal InvoiceAmount { get; init; }
    }
}
