// Handler
using KiraYonetimi.Common.Queries.QueryRequest;
using KiraYonetimi.DataAcsses.UnitOfWorks;
using KiraYonetimi.Entities.Entities;
using MediatR;

public sealed class GetInvoiceByIdQueryHandler
    : IRequestHandler<GetInvoiceByIdQuery, GetInvoiceByIdResult?>
{
    private readonly IDatabaseUnitOfWork _uow;
    public GetInvoiceByIdQueryHandler(IDatabaseUnitOfWork uow) => _uow = uow;

    public async Task<GetInvoiceByIdResult?> Handle(GetInvoiceByIdQuery q, CancellationToken ct)
    {
        var repo = _uow.GetRepository<Invoice>();
        var invoice = await repo.ReadAsync(q.Id, ct);
        if (invoice is null) return null;

        return new GetInvoiceByIdResult
        {
          InvoiceAmount = invoice.InvoiceAmount,
            InvoiceId = invoice.InvoiceId,
            InvoiceMonth = invoice.InvoiceMonth,
            InvoiceYear = invoice.InvoiceYear,
            InvoiceStatus = invoice.InvoiceStatus,
            ApartId = invoice.ApartId


        };
    }
}
