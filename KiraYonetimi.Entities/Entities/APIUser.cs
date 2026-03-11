using KiraYonetimi.Entities.Common;

namespace KiraYonetimi.Entities.Entities
{
    public class APIUser : BaseEntity
    {
        public Guid APIUserPkId { get; set; }
        public string? UserName { get; set; }
        public string? PasswordHash { get; set; }
        public string? Email { get; set; }
        public bool? Role { get; set; }
    }
}
