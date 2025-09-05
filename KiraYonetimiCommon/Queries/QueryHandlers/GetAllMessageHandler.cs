
using MediatR;

using KiraYonetimi.DataAcsses.Context;
using KiraYonetimi.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using KiraYonetimi.Common.Queries.QueryRequest;
using KiraYonetimi.DataAcsses.Repositories;
using System.Reflection.Metadata.Ecma335;
namespace KiraYonetimi.Common.Queries.QueryHandlers
{
    public class GetAllMessageHandler : IRequestHandler<GetAllMessageQuery, IList<GetAllMessageQueryResult>>
    {
        private readonly KiraContext _context;

        public GetAllMessageHandler(KiraContext context)
        {
            _context = context;
        }


        public async Task<IList<GetAllMessageQueryResult>> Handle(
              GetAllMessageQuery request,
              CancellationToken cancellationToken)
        {
            return await _context.Messages
                .Select(m => new GetAllMessageQueryResult
                {
                    MessageContent = m.MessageContent,
                 MessageId = m.MessageId,
                 FromUserId = m.FromUserId,
                    ToUserId = m.ToUserId,
                    UserId = m.UserId,
                    MessageDate = m.MessageDate,


                })
                .ToListAsync(cancellationToken);
        }
    }
}
