// Handler
using KiraYonetimi.Common.Queries.QueryRequest;
using KiraYonetimi.DataAcsses.UnitOfWorks;
using KiraYonetimi.Entities.Entities;
using MediatR;

public sealed class GetApartTypeByIdQueryHandler
    : IRequestHandler<GetApartTypeByIdQuery, GetApartTypeByIdResult?>
{
    private readonly IDatabaseUnitOfWork _uow;
    public GetApartTypeByIdQueryHandler(IDatabaseUnitOfWork uow) => _uow = uow;

    public async Task<GetApartTypeByIdResult?> Handle(GetApartTypeByIdQuery q, CancellationToken ct)
    {
        var repo = _uow.GetRepository<User>();
        var user = await repo.ReadAsync(q.Id, ct);
        if (user is null) return null;

        return new GetApartTypeByIdResult
        {
           ApartTypePkId = user.ApartUser?.ApartTypeId,
      TypeName = user.ApartUser?.ApartType?.TypeName,   

        };
    }
}
