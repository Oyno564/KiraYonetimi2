using KiraYonetimi.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KiraYonetimi.DataAcsses.Interfaces
{
    public interface IDatabaseUnitOfWork: IDisposable
    {
        object UserRepository { get; }

        Task<IList<T>> GetAllAsync(
    Expression<Func<T, bool>>? predicate = null,
    Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
    Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null,
    bool enableTracking = false);
        public async Task<List<User>> AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return await _context.Users.ToListAsync();
        }
    }
}
