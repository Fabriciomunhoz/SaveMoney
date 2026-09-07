using Microsoft.EntityFrameworkCore;
using SaveMoney.Domain.Entities;
using SaveMoney.Domain.Interfaces;
using SaveMoney.Infra.Data.Context;

namespace SaveMoney.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _ctx;

        public UserRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _ctx.Users.ToListAsync();
        }
        
        public async Task<User> GetByIdAsync(int? id)
        {
            return await _ctx.Users.Include(x => x.Role)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> CreateAsync(User user)
        {
            _ctx.Users.Add(user);
            await _ctx.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            _ctx.Users.Update(user);
            await _ctx.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteAsync(User user)
        {
            _ctx.Users.Remove(user);
            await _ctx.SaveChangesAsync();
            return user;
        }
    }
}
