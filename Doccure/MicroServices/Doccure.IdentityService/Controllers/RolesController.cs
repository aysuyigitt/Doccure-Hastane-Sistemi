using Doccure.IdentityService.Dtos;
using Doccure.IdentityService.Services.RoleServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.IdentityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRegisterDto dto)
        {
            var result = await _roleService.CreateRoleAsync(dto);
            if(!result)
            {
                return BadRequest("Role already exits or failed");
            }

            return Ok("Role created succesfully");
        }

    }
}
