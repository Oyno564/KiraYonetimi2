using KiraYonetimi.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiraYonetimi.Entities.Common;

namespace KiraYonetimi.Entities.Entities
{
    public class Payment : BaseEntity<bool>
    {
        public int PaymentId { get; set; }

        public int InvoiceId { get; set; }

        public virtual Invoice? Invoice { get; set; }

        public int UserId { get; set; }

        public decimal PaymentAmount { get; set; }

        public DateTime PaymentDate { get; set; }

        public string? PaymentMethod { get; set; }



        public virtual  User? User { get; set; }

    }
}
