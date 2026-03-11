using KiraYonetimi.Common.Queries.QueryRequest;
using KiraYonetimi.DataAcsses.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KiraYonetimi.Common.Queries.QueryHandlers
{
    public class GetAllPaymentHandler : IRequestHandler<GetAllPaymentQuery, IList<GetAllPaymentQueryResult>>
    {
        private readonly KiraContext _context;
        public GetAllPaymentHandler(KiraContext context) => _context = context;

        public async Task<IList<GetAllPaymentQueryResult>> Handle(
            GetAllPaymentQuery request, CancellationToken cancellationToken)
        {
            return await _context.Payments
                .Select(p => new GetAllPaymentQueryResult
                {
                    PaymentId     = p.PaymentId,
                    UserId        = p.UserId,
                    PaymentAmount = p.PaymentAmount,
                    PaymentDate   = p.PaymentDate,
                    PaymentMethod = p.PaymentMethod
                })
                .ToListAsync(cancellationToken);
        }
    }
}
