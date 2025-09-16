// CreateUserCommandHandler.cs
using KiraYonetimi.Common.Commands.CommandRequest;
using KiraYonetimi.DataAcsses.Interfaces;
using KiraYonetimi.DataAcsses.UnitOfWorks;
using KiraYonetimi.Entities.Entities;
using MediatR;

namespace KiraYonetimi.Common.Commands.CommandHandlers
{
    public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IDatabaseUnitOfWork _uow;
        public CreateUserCommandHandler(IDatabaseUnitOfWork uow) => _uow = uow;

        public async Task<int> Handle(CreateUserCommand request, CancellationToken ct)
        {
            var repo = _uow.GetRepository<User>(); // generic repo

            var user = new User
            {
                IsActive = true,
                FullName = request.FullName,
                TcNo = request.TcNo,
                Email = request.Email,
                Password = request.Password, // hash before saving in real code
                Phone = request.Phone,
                PlakaNo = request.PlakaNo,
                Role = request.Role
            };

            await repo.CreateAsync(user, ct);
            return await _uow.SaveChangesAsync(ct);
        }
    }
}
