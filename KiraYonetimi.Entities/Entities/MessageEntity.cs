using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiraYonetimi.Entities.Common;



namespace KiraYonetimi.Entities.Entities
{
    public class Message : BaseEntity
    {
       
        public int MessageId { get; set; }

        public int FromUserId { get; set; }

        public int ToUserId { get; set; }

        public string? MessageContent { get; set; }

        public DateTime MessageDate { get; set; }

        public int UserId { get; set; }

        public virtual User? User { get; set; }


    }
}
