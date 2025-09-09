using KiraYonetimi.DataAcsses.Context;
using KiraYonetimi.DataAcsses.Interfaces;
using KiraYonetimi.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace KiraYonetimi.DataAcsses.Repositories.UserRepository
{
 public  class UserWriteRepository : IWriteRepository<User>
    {

        private readonly KiraContext _context;

        public UserWriteRepository(KiraContext context)
        {
            _context = context;
        }
        public Task<bool> AddAsync(User model)
        {
            EntityEntry<User> entityEntry = await _context.Users.AddAsync(User);
            return entityEntry.State == EntityState.Added; // entity girilen yere başarılı bir şekilde eklenip eklenmediğini dönüyor.
        }

        public Task<bool> AddAllAsync(List<User> model)
        {
            throw new NotImplementedException();
        }

   

        public bool Remove(User model)
        {
            EntityEntry<User> entityEntry = _context.Users.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool RemoveRange(List<User> model)
        {
            _context.Users.RemoveRange(model);
            _context.SaveChanges();
            return true;
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public bool Update(User model)
        {
            throw new NotImplementedException();
        }
    }
}
*/