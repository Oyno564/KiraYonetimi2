using KiraYonetimi.Entities.Common;

namespace KiraYonetimi.Entities.Entities
{
    public class ApartUser : BaseEntity
    {
        public Guid UserPkId { get; set; }
        public int ApartUserId { get; set; }  // sequential business number
        public int UserId { get; set; }

        public virtual User User { get; set; } = default!;
        public virtual ICollection<Apartment> Apartments { get; set; } = new List<Apartment>();
        public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
