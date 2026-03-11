using KiraYonetimi.Entities.Common;

namespace KiraYonetimi.Entities.Entities
{
    public class Payment : BaseEntity
    {
        public int PaymentId { get; set; }

        // FK → Invoice.PkId (Guid)
        public Guid? InvoicePkId { get; set; }
        public virtual Invoice? Invoice { get; set; }

        // FK → User.PkId (Guid)
        public Guid UserPkId { get; set; }
        public int UserId { get; set; }          // iş numarası
        public virtual User? User { get; set; }

        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? PaymentMethod { get; set; }
    }
}
