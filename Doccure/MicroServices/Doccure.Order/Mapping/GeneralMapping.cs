using AutoMapper;
using Doccure.Order.Dtos.OrderDetailDtos;
using Doccure.Order.Dtos.OrderDtos;
using Doccure.OrderService.Entities;

namespace Doccure.Order.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Doccure.OrderService.Entities.Order, CreateOrderDto>().ReverseMap();
            CreateMap<Doccure.OrderService.Entities.Order, GetByIdOrderDto>().ReverseMap();
            CreateMap<Doccure.OrderService.Entities.Order, ResultOrderDto>().ReverseMap();

            CreateMap<OrderDetail, ResultOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailDto>().ReverseMap();
        }
    }
}