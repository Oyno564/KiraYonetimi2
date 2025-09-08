using KiraYonetimi.Entities.Common;
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
    public class Apartment : BaseEntity<int>
    {


 public int ApartId { get; set; }
        public int ApartBlock { get; set; }
        public bool ApartStatus { get; set; } // true ise sdolu, false ise boş
        public int ApartFloor { get; set; }
        public int ApartNo { get; set; }
        public bool ApartOwnerOrTenant { get; set; } // true ise owner, false ise tenant

        public int ApartTypeId { get; set; }

        public virtual ApartType? ApartType { get; set; }

        public virtual  ApartUser? ApartUser { get; set; }


        public int ApartUserId { get; set; }


        public virtual ICollection<Invoice>? Invoices { get; set; }
    };
}
