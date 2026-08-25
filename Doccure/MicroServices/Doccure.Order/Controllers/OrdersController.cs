using Doccure.Order.Dtos.OrderDtos;
using Doccure.Order.Services.OrderServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> OrderList()
        {
            var values = await _service.GetAllOrderAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var value = await _service.GetByIdOrderAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto createOrderDto)
        {
            await _service.CreateOrderAsync(createOrderDto);
            return Ok("Sipariş başarıyla oluşturuldu");
        }
    }
}
  