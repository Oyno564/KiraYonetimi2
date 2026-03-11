using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiraYonetimi.Entities.Entities;
namespace KiraYonetimi.Common.Queries.QueryRequest
{
    public class GetAllInvoiceQuery : IRequest<IList<GetAllInvoiceQueryResult>>
    {
    }
}
