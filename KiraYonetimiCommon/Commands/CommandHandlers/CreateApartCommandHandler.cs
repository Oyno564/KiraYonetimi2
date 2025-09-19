using KiraYonetimi.Common.Commands.CommandRequest;
using KiraYonetimi.DataAcsses.UnitOfWorks;
using KiraYonetimi.Entities.Entities;
using MediatR;

public sealed class CreateApartCommandHandler : IRequestHandler<CreateApartCommand, Guid>
{
    private readonly IDatabaseUnitOfWork _uow;
    public CreateApartCommandHandler(IDatabaseUnitOfWork uow) => _uow = uow;

    public async Task<Guid> Handle(CreateApartCommand r, CancellationToken ct)
    {
        var repo = _uow.GetRepository<Apartment>();
        var apartment = new Apartment
        {
        
              ApartBlock = r.ApartBlock,
                ApartStatus = r.ApartStatus,
                    ApartFloor = r.ApartFloor,
                        ApartNo = r.ApartNo,
                        ApartOwnerOrTenant = r.ApartOwnerOrTenant,
                         



        };

        await repo.CreateAsync(apartment, ct);
        await _uow.SaveChangesAsync(ct);
        return apartment.PkId; // return Guid



    }
}
