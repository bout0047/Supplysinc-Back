using Microsoft.EntityFrameworkCore;
using SupplySyncBackend.Services.Interfaces;
using SupplySyncBackend.Data;
using SupplySyncBackend.Dtos;
using SupplySyncBackend.Models;

namespace SupplySyncBackend.Services
{
    public class RoleService : IRoleService
    {
        private readonly ApplicationDbContext _context;

        public RoleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoleDto>> GetAllRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            return roles.Select(r => new RoleDto
            {
                RoleId = r.RoleId,
                RoleName = r.RoleName
            });
        }

        public async Task<RoleDto?> GetRoleById(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            return role != null ? new RoleDto { RoleId = role.RoleId, RoleName = role.RoleName } : null;
        }

        public async Task<RoleDto> AddRole(RoleDto roleDto)
        {
            var role = new Role { RoleName = roleDto.RoleName };
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();

            roleDto.RoleId = role.RoleId;
            return roleDto;
        }

        public async Task<bool> UpdateRole(int id, RoleDto roleDto)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return false;

            role.RoleName = roleDto.RoleName;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return false;

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AssignRoleToUser(int userId, int roleId)
        {
            var user = await _context.Users.FindAsync(userId);
            var role = await _context.Roles.FindAsync(roleId);
            if (user == null || role == null) return false;

            user.Roles.Add(role);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
