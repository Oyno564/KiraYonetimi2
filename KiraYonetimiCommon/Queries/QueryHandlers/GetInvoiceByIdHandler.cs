using KiraYonetimi.Common.Queries.QueryRequest;
using KiraYonetimi.DataAcsses.UnitOfWorks;
using KiraYonetimi.Entities.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public sealed class GetInvoiceByIdQueryHandler
    : IRequestHandler<GetInvoiceByIdQuery, GetInvoiceByIdResult?>
{
    private readonly IDatabaseUnitOfWork _uow;
    public GetInvoiceByIdQueryHandler(IDatabaseUnitOfWork uow) => _uow = uow;

    public async Task<GetInvoiceByIdResult?> Handle(GetInvoiceByIdQuery q, CancellationToken ct)
    {
        var repo = _uow.GetRepository<Invoice>();
        var invoice = await repo.ReadAsync(q.PkId, ct);
        if (invoice is null) return null;

        return new GetInvoiceByIdResult
        {
            PkId          = invoice.PkId,
            InvoiceId     = invoice.InvoiceId,
            InvoiceMonth  = invoice.InvoiceMonth,
            InvoiceYear   = invoice.InvoiceYear,
            InvoiceAmount = invoice.InvoiceAmount,
            InvoiceStatus = invoice.InvoiceStatus,
            ApartmentPkId = invoice.ApartmentPkId,  // << renamed
            ApartUserPkId = invoice.ApartUserPkId   // << optional but useful
        };
    }
}
