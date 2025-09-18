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
        var repo = _uow.GetRepository<ApartType>();
        var aparttype = await repo.ReadAsync(q.PkId, ct);
        if (aparttype is null) return null;

        return new GetApartTypeByIdResult
        {
     PkId = aparttype.PkId,
        TypeName = aparttype.TypeName,


        };
    }
}
