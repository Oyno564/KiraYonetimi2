using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiraYonetimi.Common.Queries.QueryRequest
{
    public class GetAllMessageQueryResult
    {

        public int MessageId { get; set; }

        public int FromUserId { get; set; }

        public int ToUserId { get; set; }

        public int UserId { get; set; }
        public string? MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
