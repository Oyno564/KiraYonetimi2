using KiraYonetimi.Common.Commands.CommandRequest;
using KiraYonetimi.DataAcsses.UnitOfWorks;
using KiraYonetimi.Entities.Entities;
using MediatR;

public sealed class CreateApartTypeCommandHandler : IRequestHandler<CreateApartTypeCommand, Guid>
{
    private readonly IDatabaseUnitOfWork _uow;
    public CreateApartTypeCommandHandler(IDatabaseUnitOfWork uow) => _uow = uow;

    public async Task<Guid> Handle(CreateApartTypeCommand r, CancellationToken ct)
    {
        var name = (r.TypeName ?? "").Trim();
     

        var repo = _uow.GetRepository<ApartType>();
        var apartType = new ApartType
        {
            TypeName = name
        };

        await repo.CreateAsync(apartType, ct);
        await _uow.SaveChangesAsync(ct);
        return apartType.PkId; // Guid PK
    }
}
