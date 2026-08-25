using Doccure.WebUI.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> ProductList()
        {
            var values = await _service.GetAllProductsAsync();
            return View(values);
        }
    }
}
