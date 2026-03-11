using KiraYonetimi.Common.Commands.CommandRequest;
using KiraYonetimi.DataAcsses.UnitOfWorks;
using KiraYonetimi.Entities.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KiraYonetimi.Common.Commands.CommandHandlers
{
    public sealed class CreateApartUserCommandHandler : IRequestHandler<CreateApartUserCommand, Guid>
    {
        private readonly IDatabaseUnitOfWork _uow;
        public CreateApartUserCommandHandler(IDatabaseUnitOfWork uow) => _uow = uow;

        public async Task<Guid> Handle(CreateApartUserCommand r, CancellationToken ct)
        {
            var userRepo = _uow.GetRepository<User>();
            var user = await userRepo.ReadAsync(r.UserPkId, ct)
                ?? throw new ArgumentException("Kullanıcı bulunamadı.");

            var auRepo = _uow.GetRepository<ApartUser>();
            var exists = await auRepo.Query.AnyAsync(x => x.UserPkId == r.UserPkId, ct);
            if (exists)
                throw new InvalidOperationException("Bu kullanıcı için zaten ApartUser mevcut.");

            var au = new ApartUser
            {
                UserPkId    = r.UserPkId,
                UserId      = user.UserId,
                IsActive    = true,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            await auRepo.CreateAsync(au, ct);

            if (r.ApartmentPkId.HasValue)
            {
                var aptRepo = _uow.GetRepository<Apartment>();
                var apt = await aptRepo.ReadAsync(r.ApartmentPkId.Value, ct)
                    ?? throw new ArgumentException("Daire bulunamadı.");
                apt.ApartUserId = au.ApartUserId;
                await aptRepo.UpdateAsync(apt, ct);
            }

            await _uow.SaveChangesAsync(ct);
            return au.PkId;
        }
    }
}
