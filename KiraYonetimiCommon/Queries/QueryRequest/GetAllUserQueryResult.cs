using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiraYonetimi.Common.Queries.QueryRequest
{
    public  class GetAllUserQueryResult
    {

    public int UserId { get; set; }
        public string? FullName { get; set; }
       public int TcNo { get; set; }
        public string? Email { get; set; }

         public int Phone { get; set; }

        public string? PlakaNo { get; set; }

        public bool Role { get; set; } // 1 ise admin, 0 ise user

    }
}
