using KiraYonetimi.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiraYonetimi.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KiraYonetimi.Entities.Entities
{
    public class ApartUser : BaseEntity
    {
        [Key]
        [Column("ApartUserId", TypeName = "Guid")]
        public Guid PkId { get; set; }
        public int ApartUserId { get; set; }
        public int UserId { get; set; }
        public int ApartId { get; set; }
        public virtual  ICollection<Apartment>? Apartments { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}

