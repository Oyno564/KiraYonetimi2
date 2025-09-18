using KiraYonetimi.Entities.Common;

namespace KiraYonetimi.API.Models.Entity
{
    public class APIUser : BaseEntity
    {

        public Guid APIUserPkId { get; set; }

        public string? UserName { get; set; } = default;

        public string? PasswordHash { get; set; } = default;

        public string? Email { get; set; } = default;

        public bool? Role { get; set; } // 1 admin 0 user
    }
}
