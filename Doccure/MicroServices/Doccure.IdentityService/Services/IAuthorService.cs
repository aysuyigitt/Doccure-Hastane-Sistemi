using Doccure.IdentityService.Dtos;

namespace Doccure.IdentityService.Services
{
    public interface IAuthorService
    {
        public Task<bool> RegisterAsync(RegisterDto dto);
        public Task<string?> LoginAsync(LoginDto loginDto);
    }
}
