using KiraYonetimi.Entities.Common;
using KiraYonetimi.Entities.Entities;

public class Apartment : BaseEntity
{
    // business fields (keep if you need them)
    public int ApartId { get; set; }
    public int ApartBlock { get; set; }
    public bool ApartStatus { get; set; }
    public int ApartFloor { get; set; }
    public int ApartNo { get; set; }
    public bool ApartOwnerOrTenant { get; set; }

    public Guid ApartTypePkId { get; set; }
    public virtual ApartType ApartType { get; set; } = default;

    // FK to ApartUser (nullable if unassigned)
 

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
