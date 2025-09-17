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
        var repo = _uow.GetRepository<ApartType>();
        var aparttype = new ApartType
        {

          
        };

        await repo.CreateAsync(aparttype, ct);
        await _uow.SaveChangesAsync(ct);
        return aparttype.PkId; // return Guid
    }
}
