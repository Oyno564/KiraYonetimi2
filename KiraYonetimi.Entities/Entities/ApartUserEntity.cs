using KiraYonetimi.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiraYonetimi.Entities.Common;


namespace KiraYonetimi.Entities.Entities
{
    public class ApartUser : BaseEntity<bool>
    {
        public int ApartUserId { get; set; }
        public int UserId { get; set; }
        public int ApartId { get; set; }
        public virtual  ICollection<Apartment>? Apartments { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}

