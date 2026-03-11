
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


    public class GetAllApartTypeHandler : IRequestHandler<GetAllApartTypeQuery, IList<GetAllApartTypeQueryResult>>
    {
        private readonly KiraContext _context;

        public GetAllApartTypeHandler(KiraContext context)
        {
            _context = context;


        }


        public async Task<IList<GetAllApartTypeQueryResult>> Handle(
              GetAllApartTypeQuery request,
              CancellationToken cancellationToken)
        {
            return await _context.ApartTypes
                .Select(u => new GetAllApartTypeQueryResult
                {
                  ApartTypeId = u.ApartTypeId,
                  TypeName = u.TypeName,
                  ApartTypePkId = u.PkId
                })
                .ToListAsync(cancellationToken);
        }

        //Task<IList<GetAllUserQueryResult>> IRequestHandler<GetAllUserQuery, IList<GetAllUserQueryResult>>.Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
    }
};

