using KiraYonetimi.Entities.Common;

namespace KiraYonetimi.Entities.Entities
{
    public class Invoice : BaseEntity
    {
        public int InvoiceId { get; set; }
        public Guid ApartPkId { get; set; }          // FK → Apartment.PkId
        public Guid? ApartUserPkId { get; set; }     // FK → ApartUser.PkId (nullable)
        public int InvoiceMonth { get; set; }
        public int InvoiceYear { get; set; }
        public decimal InvoiceAmount { get; set; }
        public bool InvoiceStatus { get; set; }

        public virtual ApartUser? ApartUser { get; set; }
        public virtual Apartment? Apartment { get; set; }
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
