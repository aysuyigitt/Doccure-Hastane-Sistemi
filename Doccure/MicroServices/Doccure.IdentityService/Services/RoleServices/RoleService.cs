using Doccure.IdentityService.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Doccure.IdentityService.Services.RoleServices
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _manager;

        public RoleService(RoleManager<IdentityRole> manager)
        {
            _manager = manager;
        }

        public async Task<bool> CreateRoleAsync(CreateRegisterDto dto)
        {
            if (await _manager.RoleExistsAsync(dto.RoleName))
                return false;

            var role = new IdentityRole 
            {
                Name = dto.RoleName 
            };

            var result = await _manager.CreateAsync(role);

            return result.Succeeded;
        }
    }
}
