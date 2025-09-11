
using MediatR;
/*
using KiraYonetimi.DataAcsses.Context;
using KiraYonetimi.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using KiraYonetimi.Common.Queries.QueryRequest;
using KiraYonetimi.DataAcsses.Repositories;
using System.Reflection.Metadata.Ecma335;
namespace KiraYonetimi.Common.Queries.QueryHandlers
{
    public class GetAllPaymentHandler : IRequestHandler<GetAllPaymentQuery, IList<GetAllPaymentQueryResult>>
    {
        private readonly KiraContext _context;

        public GetAllPaymentHandler(KiraContext context)
        {
            _context = context;
        }


        public async Task<IList<GetAllPaymentQueryResult>> Handle(
              GetAllPaymentQuery request,
              CancellationToken cancellationToken)
        {
            return await _context.Payments.Select(m => new GetAllPaymentQueryResult
                {
                   PaymentId = m.PaymentId,
                   InvoiceId = m.InvoiceId,
                   UserId = m.UserId,
                     PaymentAmount = m.PaymentAmount,
                        PaymentDate = m.PaymentDate,
                        PaymentMethod = m.PaymentMethod


                })
                .ToListAsync(cancellationToken);
        } 
    }
}
*/