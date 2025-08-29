using KiraYonetimi.Entities.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiraYonetimi.Common.Queries.QueryRequest
{
  public class GetAllUserQuery : IRequest<IList<GetAllUserQueryResult>>
    {
    }
}
