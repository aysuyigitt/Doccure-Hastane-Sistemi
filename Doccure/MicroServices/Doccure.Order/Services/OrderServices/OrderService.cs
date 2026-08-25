using AutoMapper;
using Doccure.Order.Dtos.OrderDtos;
using Doccure.OrderService.Context;
using Microsoft.EntityFrameworkCore;

namespace Doccure.Order.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly OrderContext _context;
        private readonly IMapper _mapper;

        public OrderService(OrderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            var value = _mapper.Map<Doccure.OrderService.Entities.Order>(createOrderDto);
            value.OrderDate = DateTime.Now;
            value.Status = "Waiting";
            await _context.Orders.AddAsync(value);
            await _context.SaveChangesAsync();

        }

        public async Task<List<ResultOrderDto>> GetAllOrderAsync()
        {
            var values = await _context.Orders.ToListAsync();
            return _mapper.Map<List<ResultOrderDto>>(values);

        }

        public async Task<GetByIdOrderDto> GetByIdOrderAsync(int id)
        {
            var value = await _context.Orders.Include(x => x.OrderDetails).FirstOrDefaultAsync(x => x.OrderId == id);
            return _mapper.Map<GetByIdOrderDto>(value);
        }
    }
}
