using KiraYonetimi.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiraYonetimi.Entities.Common;
namespace KiraYonetimi.Entities.Entities
{
    public class Invoice : BaseEntity<bool>
    {
        public int InvoiceId { get; set; }

        public int ApartId { get; set; }

        public int InvoiceMonth { get; set; }

        public int InvoiceYear { get; set; }

        public decimal InvoiceAmount { get; set; }

        public bool InvoiceStatus { get; set; }


        public virtual ApartUser? ApartUser { get; set; }


        public virtual Apartment? Apartment { get; set; }

        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    };
};