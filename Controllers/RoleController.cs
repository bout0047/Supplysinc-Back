using Microsoft.AspNetCore.Mvc;
using SupplySyncBackend.Services.Interfaces;
using SupplySyncBackend.Dtos.General;

namespace SupplySyncBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleService.GetAllRoles();
            return Ok(roles);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] RoleDto roleDto)
        {
            var role = await _roleService.AddRole(roleDto);
            return Ok(role);
        }
    }
}
