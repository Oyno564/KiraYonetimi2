namespace KiraYonetimi.API.Models.Entity
{
    public sealed class RegisterRequest
    {
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string? Phone { get; set; }
        public string? TcNo { get; set; }
    }
}
