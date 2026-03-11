using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiraYonetimi.Common.Queries.QueryRequest
{
    public class GetAllApartQueryResult
    {

        public int ApartId { get; set; }
        public int ApartBlock { get; set; }
        public bool ApartStatus { get; set; } // true ise sdolu, false ise boş
        public int ApartFloor { get; set; }
        public int ApartNo { get; set; }
        public bool ApartOwnerOrTenant { get; set; } // true ise owner, false ise tenant

        public int ApartTypeId { get; set; }
    }
}
