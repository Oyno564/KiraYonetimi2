using KiraYonetimi.Common.Commands.CommandRequest;
using KiraYonetimi.DataAcsses.UnitOfWorks;
using KiraYonetimi.Entities.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace KiraYonetimi.Common.Commands.CommandHandlers
{
    public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IDatabaseUnitOfWork _uow;
        public CreateUserCommandHandler(IDatabaseUnitOfWork uow) => _uow = uow;

        public async Task<Guid> Handle(CreateUserCommand r, CancellationToken ct)
        {
            var repo = _uow.GetRepository<User>();
            var user = new User
            {
                IsActive    = true,
                FullName    = r.FullName,
                TcNo        = r.TcNo,
                Email       = r.Email,
                Phone       = r.Phone,
                PlakaNo     = r.PlakaNo,
                Role        = r.Role,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            // Hash the password before storing
            var hasher = new PasswordHasher<User>();
            user.Password = hasher.HashPassword(user, r.Password);

            await repo.CreateAsync(user, ct);
            await _uow.SaveChangesAsync(ct);
            return user.PkId;
        }
    }
}
