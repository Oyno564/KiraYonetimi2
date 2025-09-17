using KiraYonetimi.Common.Commands.CommandRequest;
using KiraYonetimi.DataAcsses.UnitOfWorks;
using KiraYonetimi.Entities.Entities;
using MediatR;

public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IDatabaseUnitOfWork _uow;
    public CreateUserCommandHandler(IDatabaseUnitOfWork uow) => _uow = uow;

    public async Task<Guid> Handle(CreateUserCommand r, CancellationToken ct)
    {
        var repo = _uow.GetRepository<User>();
        var user = new User
        {
            IsActive = true,
            FullName = r.FullName,
            TcNo = r.TcNo,
            Email = r.Email,
            Password = r.Password,   // hash in real code
            Phone = r.Phone,
            PlakaNo = r.PlakaNo,
            Role = r.Role
        };

        await repo.CreateAsync(user, ct);
        await _uow.SaveChangesAsync(ct);
        return user.PkId; // return Guid
    }
}
