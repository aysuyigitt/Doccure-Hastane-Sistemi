using Doccure.Order.Dtos.OrderDtos;

namespace Doccure.Order.Services.OrderServices
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrderDto createOrderDto);
        Task<List<ResultOrderDto>> GetAllOrderAsync();
        Task<GetByIdOrderDto> GetByIdOrderAsync(int id);
    }
}
