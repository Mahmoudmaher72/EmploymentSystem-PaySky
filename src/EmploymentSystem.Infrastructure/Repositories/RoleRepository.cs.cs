using EmploymentSystem.Domain.Entities;
using EmploymentSystem.Domain.IRepositories;
using EmploymentSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmploymentSystem.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<Role> GetRoleByNameAsync(string name)
        {
            return await _context.Roles.SingleOrDefaultAsync(r => r.Name == name);
        }

    }
}
