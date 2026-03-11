using KiraYonetimi.Common.Commands.CommandRequest;
using KiraYonetimi.DataAcsses.UnitOfWorks;
using KiraYonetimi.Entities.Entities;
using MediatR;

namespace KiraYonetimi.Common.Commands.CommandHandlers
{
    public sealed class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, Guid>
    {
        private readonly IDatabaseUnitOfWork _uow;
        public CreateInvoiceCommandHandler(IDatabaseUnitOfWork uow) => _uow = uow;

        public async Task<Guid> Handle(CreateInvoiceCommand r, CancellationToken ct)
        {
            var aptRepo = _uow.GetRepository<Apartment>();
            var apartment = await aptRepo.ReadAsync(r.ApartmentPkId, ct)
                ?? throw new ArgumentException($"Daire bulunamadı: {r.ApartmentPkId}");

            var invRepo = _uow.GetRepository<Invoice>();
            var invoice = new Invoice
            {
                ApartPkId     = apartment.PkId,
                InvoiceMonth  = r.InvoiceMonth,
                InvoiceYear   = r.InvoiceYear,
                InvoiceAmount = r.InvoiceAmount,
                InvoiceStatus = r.InvoiceStatus,
                IsActive      = true,
                CreatedDate   = DateTime.UtcNow,
                UpdatedDate   = DateTime.UtcNow
            };

            await invRepo.CreateAsync(invoice, ct);
            await _uow.SaveChangesAsync(ct);
            return invoice.PkId;
        }
    }
}
