// Handler
using KiraYonetimi.Common.Queries.QueryRequest;
using KiraYonetimi.DataAcsses.UnitOfWorks;
using KiraYonetimi.Entities.Entities;
using MediatR;

public sealed class GetUserByIdQueryHandler
    : IRequestHandler<GetUserByIdQuery, GetUserByIdResult?>
{
    private readonly IDatabaseUnitOfWork _uow;
    public GetUserByIdQueryHandler(IDatabaseUnitOfWork uow) => _uow = uow;

    public async Task<GetUserByIdResult?> Handle(GetUserByIdQuery q, CancellationToken ct)
    {
        var repo = _uow.GetRepository<User>();
        var user = await repo.ReadAsync(q.Id, ct);
        if (user is null) return null;

        return new GetUserByIdResult
        {
            PkId = user.PkId,
            FullName = user.FullName,
            Email = user.Email,
            Phone = user.Phone,
            Role = user.Role,
            CreatedDate = user.CreatedDate
        };
    }
}
