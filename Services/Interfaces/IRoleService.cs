using SupplySyncBackend.Dtos;

namespace SupplySyncBackend.Services.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetAllRoles();
        Task<RoleDto?> GetRoleById(int id);
        Task<RoleDto> AddRole(RoleDto roleDto);
        Task<bool> UpdateRole(int id, RoleDto roleDto);
        Task<bool> DeleteRole(int id);
        Task<bool> AssignRoleToUser(int userId, int roleId);
    }
}
