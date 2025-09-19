
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiraYonetimi.DataAcsses;
using KiraYonetimi.DataAcsses.Context;
using KiraYonetimi.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using KiraYonetimi.Common.Queries.QueryRequest;
using KiraYonetimi.DataAcsses.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace KiraYonetimi.Common.Queries.QueryHandlers
{

    public class GetAllApartQueryHandler : IRequestHandler<GetAllApartQuery, IList<GetAllApartQueryResult>>
    {
        private readonly KiraContext _context;

        public GetAllApartQueryHandler(KiraContext context)
        {
            _context = context;
        }


        public async Task<IList<GetAllApartQueryResult>> Handle(
              GetAllApartQuery request,
              CancellationToken cancellationToken)
        {
            return await _context.Apartments
                .Select(a => new GetAllApartQueryResult
                {
                 ApartId = a.ApartId,
                    ApartBlock = a.ApartBlock,
                    ApartStatus = a.ApartStatus,
                    ApartFloor = a.ApartFloor,
                    ApartNo = a.ApartNo,
                    ApartOwnerOrTenant = a.ApartOwnerOrTenant,
                  

                })
                .ToListAsync(cancellationToken);
        }
    }
}
