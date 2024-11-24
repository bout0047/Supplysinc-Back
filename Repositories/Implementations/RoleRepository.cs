using SupplySyncBackend.Repositories;
using SupplySyncBackend.Models;
using SupplySyncBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace SupplySyncBackend.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role?> GetRoleByIdAsync(int roleId)
        {
            return await _context.Roles.FindAsync(roleId);
        }

        public async Task AddRoleAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int roleId)
        {
            var role = await _context.Roles.FindAsync(roleId);
            if (role == null) throw new Exception("Role not found.");

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }
    }
}
