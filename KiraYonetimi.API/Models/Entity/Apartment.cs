using Microsoft.AspNet.Identity.EntityFramework;

namespace KiraYonetimi.API.Models.Entity
{
    public class Apartment : IdentityUser
    {

        public Guid ApartId { get; set; }
        public int ApartBlock { get; set; }
        public bool ApartStatus { get; set; } // true ise sdolu, false ise boş
        public int ApartFloor { get; set; }
        public int ApartNo { get; set; }
        public bool ApartOwnerOrTenant { get; set; } // true ise owner, false ise tenant

        public int ApartTypeId { get; set; }
    }
}
