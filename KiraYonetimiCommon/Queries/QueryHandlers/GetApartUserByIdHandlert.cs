using KiraYonetimi.Common.Queries.QueryRequest;
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

            // IQueryable<T> Query özelliğin varsa SELECT ile direkt proje et (Include gerektirmez)
            var dto = await auRepo.Query
                .Where(x => x.PkId == q.PkId)
                .Select(x => new GetApartUserByIdResult
                {
                  //  PkId = x.PkId,
                    UserPkId = x.UserPkId,
                    ApartUserId = x.ApartUserId,
                    UserId = x.User.UserId,
               
                })
                .SingleOrDefaultAsync(ct);

            return dto; // yoksa null -> controller 404 döner
        }
    }
}
