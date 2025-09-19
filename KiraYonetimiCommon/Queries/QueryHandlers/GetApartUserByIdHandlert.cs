/* using KiraYonetimi.Common.Queries.QueryRequest;
using KiraYonetimi.DataAcsses.UnitOfWorks;
using KiraYonetimi.Entities.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KiraYonetimi.Common.Queries.QueryHandlers
{
    public sealed class GetApartUserByIdQueryHandler
        : IRequestHandler<GetApartUserByIdQuery, GetApartUserByIdResult?>
    {
        private readonly IDatabaseUnitOfWork _uow;
        public GetApartUserByIdQueryHandler(IDatabaseUnitOfWork uow) => _uow = uow;

        public async Task<GetApartUserByIdResult?> Handle(GetApartUserByIdQuery q, CancellationToken ct)
        {
            var auRepo = _uow.GetRepository<ApartUser>();

            var dto = await auRepo.Query
                .Where(x => x.PkId == q.PkId)
                .Select(x => new GetApartUserByIdResult
                {
                    PkId = x.PkId,          // ApartUser’s Guid PK
                    UserPkId = x.UserPkId,      // FK -> User.PkId
                    UserId = x.User.UserId,   // if your User has an int business id
                    // optional extras:
         
                })
                .SingleOrDefaultAsync(ct);

            return dto;
        }
    }
}
 */