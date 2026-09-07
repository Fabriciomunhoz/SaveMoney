using Microsoft.EntityFrameworkCore;
using SaveMoney.Domain.Entities;
using SaveMoney.Domain.Interfaces;
using SaveMoney.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveMoney.Infra.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _ctx;

        public RoleRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            return await _ctx.Roles.ToListAsync();
        }

        public async Task<Role> GetByIdAsync(int? id)
        {
            return await _ctx.Roles.FindAsync(id);
        }
        public async Task<Role> CreateAsync(Role role)
        {
            _ctx.Roles.Add(role);
            await _ctx.SaveChangesAsync();
            return role;
        }

        public async Task<Role> UpdateAsync(Role role)
        {
            _ctx.Roles.Update(role);
            await _ctx.SaveChangesAsync();
            return role;
        }

        public async Task<Role> DeleteAsync(Role role)
        {
            _ctx.Roles.Remove(role);
            await _ctx.SaveChangesAsync();
            return role;
        }

    }
}
