 /* // ApartUser.cs
using KiraYonetimi.Entities.Common;
using KiraYonetimi.Entities.Entities;

public class ApartUser : BaseEntity
{
    public Guid UserPkId { get; set; }                 // FK -> User.PkId
    public virtual User User { get; set; } = default!; // 1–1

    public Guid? ApartUserPkId { get; set; }

    public virtual ICollection<Apartment> Apartments { get; set; } = new List<Apartment>();
    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
 */