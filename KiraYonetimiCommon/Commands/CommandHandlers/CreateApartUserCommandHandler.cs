/* using KiraYonetimi.Common.Commands.CommandRequest;
using KiraYonetimi.DataAcsses.UnitOfWorks;
using KiraYonetimi.Entities.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KiraYonetimi.Common.Commands.CommandHandler
{
    public sealed class CreateApartUserCommandHandler
        : IRequestHandler<CreateApartUserCommand, Guid>
    {
        private readonly IDatabaseUnitOfWork _uow;
        public CreateApartUserCommandHandler(IDatabaseUnitOfWork uow) => _uow = uow;

        public async Task<Guid> Handle(CreateApartUserCommand r, CancellationToken ct)
        {
            // 1) User var mı?
            var userRepo = _uow.GetRepository<User>();
            var user = await userRepo.ReadAsync(r.UserPkId, ct);
            if (user is null)
                throw new ArgumentException("User not found by PkId.");

            // 2) Bu User için zaten ApartUser var mı? (unique)
            var auRepo = _uow.GetRepository<ApartUser>();
            // repo'nuzda IQueryable erişimi yoksa uygun bir methodunu kullanın
            var exists = await auRepo.Query.AnyAsync(x => x.UserPkId == r.UserPkId, ct);

            if (exists)
                throw new InvalidOperationException("ApartUser already exists for this User.");

            // 3) Oluştur
            var au = new ApartUser
            {
                UserPkId = r.UserPkId
                // ApartUserId (int) iş numarası ise DB tarafında ValueGeneratedOnAdd verebilirsin
            };

            await auRepo.CreateAsync(au, ct);

            // 4) İsteğe bağlı: bir daireyi hemen bu ApartUser'a bağla
            if (r.ApartmentPkId.HasValue)
            {
                var aptRepo = _uow.GetRepository<Apartment>();
                var apt = await aptRepo.ReadAsync(r.ApartmentPkId.Value, ct)
                          ?? throw new ArgumentException("Apartment not found by PkId.");

                // --- Aşağıdaki iki YOLDAN BİRİNİ kullan ---
                // YOL A (önerilen, FK Guid): Apartment'ta Guid FK varsa:
                // apt.ApartUserPkId = au.PkId;

                // YOL B (FK int 'ApartUserId' kullanıyorsan): 
                //  - ApartUser'a alternate key tanımlamalısın (bkz. notlar)
                // apt.ApartUserId = au.ApartUserId;

                await aptRepo.UpdateAsync(apt, ct);
            }

            await _uow.SaveChangesAsync(ct);
            return au.PkId;
        }
    }
}
   */