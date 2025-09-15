using KiraYonetimi.DataAcsses.Context;
using KiraYonetimi.DataAcsses.Interfaces;
using KiraYonetimi.Entities.Common;
using KiraYonetimi.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace KiraYonetimi.DataAcsses.Repositories
{

    public sealed class EntityFrameworkRepository<Entity> : IRepository<Entity>
               where Entity : BaseEntity<int, string>, new()
    {

        private readonly KiraContext _context;
        public EntityFrameworkRepository(KiraContext context)
        {
            _context = context;
        }

        public DbSet<Entity> Table { get; set; }

        public IQueryable<Entity> Queryable => _context.Set<Entity>().AsNoTracking();

        public IQueryable<Entity> AsQueryable => _context.Set<Entity>().AsQueryable();



        public async Task<Entity> Create(Entity entity)
        {


            if (entity.PkId == Guid.Empty)
            {
                entity.PkId = Guid.NewGuid();
            }
            entity.CreatedDate = DateTime.Now;
            Table.Add(entity);


            await Table.AddAsync(entity);  // EF Core’un AddAsync metodu
            return entity;
        }
    

        


        public Task DeleteAsync(Entity entity)
        {
           Table.Remove(entity);
          return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
           await DeleteAsync(await ReadAsync(id));
        }

   

        public Task<Entity?> ReadAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Entity> UpdateAsync(Entity entity)
        {
            throw new NotImplementedException();
        }
    }

}




















   /* public class UserRepository : IUserRepository
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


} */
