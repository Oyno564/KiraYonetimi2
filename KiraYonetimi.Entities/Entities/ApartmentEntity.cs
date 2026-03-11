using KiraYonetimi.Entities.Common;

namespace KiraYonetimi.Entities.Entities
{
    public class Apartment : BaseEntity
    {
        public int ApartId { get; set; }
        public int ApartBlock { get; set; }
        public bool ApartStatus { get; set; }       // true=dolu, false=boş
        public int ApartFloor { get; set; }
        public int ApartNo { get; set; }
        public bool ApartOwnerOrTenant { get; set; } // true=mal sahibi, false=kiracı

        public int ApartTypeId { get; set; }          // iş numarası (sıra)
        public Guid ApartTypePkId { get; set; }       // Guid FK → ApartType.PkId
        public virtual ApartType? ApartType { get; set; }

        public int? ApartUserId { get; set; }
        public Guid? ApartUserPkId { get; set; }      // Guid FK → ApartUser.PkId
        public virtual ApartUser? ApartUser { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
