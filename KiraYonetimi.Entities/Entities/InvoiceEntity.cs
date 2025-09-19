using KiraYonetimi.Entities.Common;

namespace KiraYonetimi.Entities.Entities
{
    public class Invoice : BaseEntity
    {
        // Business code (NOT PK)
        public int InvoiceId { get; set; }

        // FKs (nullable so records can survive deletions/unassignments)
        public Guid? ApartmentPkId { get; set; }   // -> Apartment.PkId
        public Guid? ApartUserPkId { get; set; }   // -> ApartUser.PkId

        // Data
        public int InvoiceMonth { get; set; }      // 1..12
        public int InvoiceYear { get; set; }
        public decimal InvoiceAmount { get; set; }
        public bool InvoiceStatus { get; set; }    // paid/unpaid etc.

        // Navigations
        public virtual Apartment? Apartment { get; set; }
   
     
    }
}
