using KiraYonetimi.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiraYonetimi.Entities.Common;
using System.ComponentModel.DataAnnotations;


namespace KiraYonetimi.Entities.Entities
{
    public class ApartUser : BaseEntity
    {
        public Guid UserPkId { get; set; }
        public int ApartUserId { get; set; } // PK değil
        public int UserId { get; set; }
        public int ApartId { get; set; }
        public virtual User User { get; set; } = default!;
        public virtual ICollection<Apartment>? Apartments { get; set; } = new List<Apartment>();
        public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }

}

