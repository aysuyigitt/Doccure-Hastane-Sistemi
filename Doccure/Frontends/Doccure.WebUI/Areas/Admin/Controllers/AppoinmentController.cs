using Microsoft.AspNetCore.Mvc;

namespace Doccure.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppoinmentController : Controller
    {
        public IActionResult AppoinmentList()
        {
            return View();
        }
    }
}
