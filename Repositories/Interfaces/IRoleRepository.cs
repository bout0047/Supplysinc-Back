using SupplySyncBackend.Models;

namespace SupplySyncBackend.Repositories
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role?> GetRoleByIdAsync(int roleId);
        Task AddRoleAsync(Role role);
        Task DeleteRoleAsync(int roleId);
    }
}
