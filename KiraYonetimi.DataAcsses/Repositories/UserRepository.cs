using KiraYonetimi.DataAcsses.Context;
using KiraYonetimi.DataAcsses.Interfaces;
using KiraYonetimi.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KiraYonetimi.DataAcsses.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly KiraContext _context;

        public UserRepository(KiraContext context)
        {
            _context = context;
        }

        public int? GetUserIdByPassword(string password)
        {
            return _context.Users
                .Where(u => u.Password == password)
                .Select(u => (int?)u.UserId)   // eşleşmezse null döner
                .FirstOrDefault();
        }



        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByMail(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }


}
