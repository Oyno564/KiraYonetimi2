using KiraYonetimi.API.Models.Entity;
using KiraYonetimi.DataAcsses.Context;
using KiraYonetimi.Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KiraYonetimi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly KiraContext _db;
        private readonly JwtSettings _jwt;
        private readonly PasswordHasher<User> _hasher = new();

        public AuthController(KiraContext db, IOptions<JwtSettings> jwt)
        {
            _db = db;
            _jwt = jwt.Value;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest dto, CancellationToken ct)
        {
            var user = await _db.Users.SingleOrDefaultAsync(u => u.Email == dto.Email, ct);
            if (user is null) return Unauthorized("Geçersiz kimlik bilgileri.");

            var verify = _hasher.VerifyHashedPassword(user, user.Password!, dto.Password);
            if (verify == PasswordVerificationResult.Failed)
                return Unauthorized("Geçersiz kimlik bilgileri.");

            var token = CreateToken(user);
            return Ok(new
            {
                access_token = token,
                token_type = "Bearer",
                expires_in = 60 * 60 * 12,
                user = new { id = user.PkId, name = user.FullName, email = user.Email, isAdmin = user.Role }
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest dto, CancellationToken ct)
        {
            if (await _db.Users.AnyAsync(u => u.Email == dto.Email, ct))
                return Conflict("Bu e-posta zaten kayıtlı.");

            var hasher = new PasswordHasher<User>();
            var user = new User
            {
                PkId = Guid.NewGuid(),
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone ?? "",
                TcNo = dto.TcNo ?? "",
                IsActive = true,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };
            user.Password = hasher.HashPassword(user, dto.Password);

            _db.Users.Add(user);
            await _db.SaveChangesAsync(ct);

            return Ok(new { id = user.PkId, name = user.FullName });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin-test")]
        public IActionResult AdminOnly() => Ok("Admin ok");

        [HttpPost("users/{id:guid}/make-admin")]
        public async Task<IActionResult> MakeAdmin(Guid id, CancellationToken ct)
        {
            var user = await _db.Users.FindAsync(new object?[] { id }, ct);
            if (user is null) return NotFound();
            user.Role = true;
            await _db.SaveChangesAsync(ct);
            return Ok(new { id = user.PkId, isAdmin = user.Role });
        }

        [HttpPost("users/{id:guid}/make-user")]
        public async Task<IActionResult> MakeUser(Guid id, CancellationToken ct)
        {
            var user = await _db.Users.FindAsync(new object?[] { id }, ct);
            if (user is null) return NotFound();
            user.Role = false;
            await _db.SaveChangesAsync(ct);
            return Ok(new { id = user.PkId, isAdmin = user.Role });
        }

        private string CreateToken(User user)
        {
            var roleName = user.Role ? "Admin" : "User";
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.PkId.ToString()),
                new(ClaimTypes.NameIdentifier, user.PkId.ToString()),
                new(ClaimTypes.Name, user.FullName ?? string.Empty),
                new(ClaimTypes.Email, user.Email ?? string.Empty),
                new(ClaimTypes.Role, roleName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(12),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
