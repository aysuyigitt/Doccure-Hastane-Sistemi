using Doccure.WebUI.Models.Auth;
using Doccure.WebUI.Services.RegisterServices;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegisterService _service;

        public RegisterController(IRegisterService service)
        {
            _service = service;
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterViewModel model)
        {
            await _service.RegisterAsync(model);
            return RedirectToAction("SignIn", "Login");
        }
    }
}
