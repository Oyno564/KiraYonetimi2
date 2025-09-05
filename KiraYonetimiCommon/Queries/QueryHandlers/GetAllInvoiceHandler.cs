
using MediatR;

using KiraYonetimi.DataAcsses.Context;
using KiraYonetimi.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using KiraYonetimi.Common.Queries.QueryRequest;
using KiraYonetimi.DataAcsses.Repositories;
using System.Reflection.Metadata.Ecma335;
namespace KiraYonetimi.Common.Queries.QueryHandlers
{
    public class GetAllInvoiceHandler : IRequestHandler<GetAllInvoiceQuery, IList<GetAllInvoiceQueryResult>>
    {
        private readonly KiraContext _context;

        public GetAllInvoiceHandler(KiraContext context)
        {
            _context = context;
        }


        public async Task<IList<GetAllInvoiceQueryResult>> Handle(
              GetAllInvoiceQuery request,
              CancellationToken cancellationToken)
        {
            return await _context.Invoices
                .Select(i => new GetAllInvoiceQueryResult
                {
                        InvoiceId = i.InvoiceId,
                        ApartId = i.ApartId,
                        InvoiceMonth = i.InvoiceMonth,
                        InvoiceYear = i.InvoiceYear,
                        InvoiceAmount = i.InvoiceAmount,
                        InvoiceStatus = i.InvoiceStatus


                })
                .ToListAsync(cancellationToken);
        }
    }
}
