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

        public IEnumerable<User> GetByMail(string email, int userId)
        {
            return _context.Users
                           .Where(u => u.Email == email && u.UserId == userId)
                           .ToList();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<List<User>> AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return await _context.Users.ToListAsync();
        }
        
           
        
    }
}
