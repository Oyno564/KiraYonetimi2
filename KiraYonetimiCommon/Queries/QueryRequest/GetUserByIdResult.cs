using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiraYonetimi.Common.Queries.QueryRequest
{
    public sealed class GetUserByIdResult
    {
        public Guid PkId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }     // you changed these to string
        public bool Role { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
