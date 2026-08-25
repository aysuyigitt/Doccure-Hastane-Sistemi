using Microsoft.AspNetCore.Mvc;

namespace Doccure.WebUI.Areas.Admin.ViewComponents
{
    public class _AdminLayoutSriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}