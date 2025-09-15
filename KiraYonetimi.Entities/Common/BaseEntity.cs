using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiraYonetimi.Entities.Common
{
    public class BaseEntity<TKey, PrimaryKey>
    {



        [Key]
        [Column("PkId", TypeName = "varchar(36)" Type = "Guid")]

        public Guid   PkId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
