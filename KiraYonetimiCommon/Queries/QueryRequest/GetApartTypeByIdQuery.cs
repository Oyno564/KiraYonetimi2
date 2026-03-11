using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiraYonetimi.Common.Queries.QueryRequest
{
    public sealed record GetApartTypeByIdQuery(Guid PkId) : IRequest<GetApartTypeByIdResult?>;    
    
}
