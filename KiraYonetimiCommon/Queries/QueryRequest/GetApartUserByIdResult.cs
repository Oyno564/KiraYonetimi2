using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiraYonetimi.Common.Queries.QueryRequest
{
    public sealed class GetApartUserByIdResult
    {
        public Guid UserPkId { get; set; }
        public int ApartUserId { get; set; } // PK değil
        public int UserId { get; set; }
        public Guid ApartId { get; set; }
    }
}
