using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiraYonetimi.Common.Queries.QueryRequest
{
   public  class GetAllApartTypeQueryResult
    {
        public Guid ApartTypePkId { get; set; }

        public string? TypeName { get; set; }

      
    }
}
