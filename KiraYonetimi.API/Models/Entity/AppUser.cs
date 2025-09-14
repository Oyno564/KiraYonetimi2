using Microsoft.AspNetCore.Identity;

namespace KiraYonetimi.API.Models.Entity

{
    public class AppUser : IdentityUser
    {
        public Guid AppUserId { get; set; }

        public required string FullName { get; set; }

        public required string Password { get; set; }
    }
}
