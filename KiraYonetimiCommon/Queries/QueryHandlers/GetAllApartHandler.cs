

using KiraYonetimi.DataAcsses.Context;
using MediatR;
using KiraYonetimi.Entities.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using KiraYonetimi.Common.Queries.QueryRequest;

namespace KiraYonetimi.Common.Queries.QueryHandlers
{
    public class GetAllApartQueryHandler : IRequestHandler<GetAllApartQuery, List<Apartment>>
    {
        private readonly KiraContext _context;

        public GetAllApartQueryHandler(KiraContext context)
        {
            _context = context;
        }


        public Task<List<Apartment>> Handle(GetAllApartQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
