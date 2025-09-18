using KiraYonetimi.Common.Commands.CommandRequest;
using KiraYonetimi.DataAcsses.UnitOfWorks;
using KiraYonetimi.Entities.Entities;
using MediatR;

public sealed class DeleteApartTypeCommandHandler
    : IRequestHandler<DeleteApartTypeCommand, bool>
{
    private readonly IDatabaseUnitOfWork _uow;
    public DeleteApartTypeCommandHandler(IDatabaseUnitOfWork uow) => _uow = uow;

    public async Task<bool> Handle(DeleteApartTypeCommand r, CancellationToken ct)
    {
        var repo = _uow.GetRepository<ApartType>();
        var entity = await repo.ReadAsync(r.PkId, ct);
        if (entity is null) return false;

     

        await repo.DeleteAsync(entity, ct);     // kendi repo metodun
        await _uow.SaveChangesAsync(ct);
        return true;
    }
}
