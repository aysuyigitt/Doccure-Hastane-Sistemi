using Doccure.IdentityService.Dtos;
using Doccure.IdentityService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.IdentityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public LoginsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(LoginDto dto)
        {
            var token = await _authorService.LoginAsync(dto);

            if(token == null)
                return Unauthorized("Email veya şifre hatalı");

            return Ok(new {token});
        } 
    }
}
