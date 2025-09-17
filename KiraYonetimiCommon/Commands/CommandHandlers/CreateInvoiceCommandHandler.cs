using KiraYonetimi.Common.Commands.CommandRequest;
using KiraYonetimi.DataAcsses.UnitOfWorks;
using KiraYonetimi.Entities.Entities;
using MediatR;

public sealed class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, Guid>
{
    private readonly IDatabaseUnitOfWork _uow;
    public CreateInvoiceCommandHandler(IDatabaseUnitOfWork uow) => _uow = uow;

    public async Task<Guid> Handle(CreateInvoiceCommand r, CancellationToken ct)
    {
        // 1) Apartment'ı GUID (PkId) ile bul
        var aptRepo = _uow.GetRepository<Apartment>();
        var apartment = await aptRepo.ReadAsync(r.ApartmentPkId, ct);
        if (apartment is null)
            throw new ArgumentException("Apartment not found by PkId.");

        // 2) Fatura nesnesini oluştur ve ApartId (int) atamasını yap
        var invRepo = _uow.GetRepository<Invoice>();
        var invoice = new Invoice
        {
            IsActive      = true,
    
            InvoiceMonth  = r.InvoiceMonth,
            InvoiceYear   = r.InvoiceYear,
            InvoiceAmount = r.InvoiceAmount,
            InvoiceStatus = r.InvoiceStatus
        };

        await invRepo.CreateAsync(invoice, ct);
        await _uow.SaveChangesAsync(ct);

        return invoice.PkId; // Guid
    }
}
