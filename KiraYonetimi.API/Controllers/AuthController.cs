
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
        private readonly DbContext _db;                 // <-- replace with your concrete context type
        private readonly JwtSettings _jwt;
        private readonly PasswordHasher<User> _hasher = new();

        public AuthController(DbContext db, IOptions<JwtSettings> jwt)
        {
            _db = db;
            _jwt = jwt.Value;
        }

      

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest dto, CancellationToken ct)
        {
            var user = await _db.Set<User>().SingleOrDefaultAsync(u => u.Email == dto.Email, ct);
            if (user is null) return Unauthorized("Invalid credentials.");

            var verify = _hasher.VerifyHashedPassword(user, user.Password!, dto.Password); // if renamed: user.PasswordHash
            if (verify == PasswordVerificationResult.Failed) return Unauthorized("Invalid credentials.");

            var token = CreateToken(user);
            return Ok(new
            {
                access_token = token,
                token_type = "Bearer",
                expires_in = 60 * 60 * 12,
                user = new { id = user.PkId, name = user.FullName, email = user.Email, isAdmin = user.Role }
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin-test")]
        public IActionResult AdminOnly() => Ok("Admin ok");

        private string CreateToken(User user)
        {
            // Map your bool Role to a role name for claims
            var roleName = user.Role ? "Admin" : "User";

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.PkId.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.PkId.ToString()),
                new Claim(ClaimTypes.Name, user.FullName ?? string.Empty),
                new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
                new Claim(ClaimTypes.Role, roleName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
             //   notBefore: DateTime.UtcNow,
            //    expires: DateTime.UtcNow.AddHours(12),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

      //  [Authorize(Roles = "Admin")]
        [HttpPost("users/{id:guid}/make-admin")]
        public async Task<IActionResult> MakeAdmin(Guid id, CancellationToken ct)
        {
            var user = await _db.Set<User>().FindAsync(new object?[] { id }, ct);
            if (user is null) return NotFound();
            user.Role = true;
            await _db.SaveChangesAsync(ct);
            return Ok(new { id = user.PkId, isAdmin = user.Role });
        }

       // [Authorize(Roles = "Admin")] 
        [HttpPost("users/{id:guid}/make-user")]
        public async Task<IActionResult> MakeUser(Guid id, CancellationToken ct)
        {
            var user = await _db.Set<User>().FindAsync(new object?[] { id }, ct);
            if (user is null) return NotFound();
            user.Role = false;
            await _db.SaveChangesAsync(ct);
            return Ok(new { id = user.PkId, isAdmin = user.Role });
        }

    }
}
