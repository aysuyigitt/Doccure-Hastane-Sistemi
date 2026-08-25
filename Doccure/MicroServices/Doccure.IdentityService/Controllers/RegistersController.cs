using Doccure.IdentityService.Dtos;
using Doccure.IdentityService.Entities;
using Doccure.IdentityService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.IdentityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public RegistersController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegister(RegisterDto registerDto)
        {
            var result = await _authorService.RegisterAsync(registerDto);

            if (!result)
                return BadRequest("Kullanıcı oluşturulamadı");

            return Ok("Kayıt başarılı");
        }
    }
}
