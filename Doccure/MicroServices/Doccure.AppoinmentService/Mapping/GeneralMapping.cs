using AutoMapper;
using Doccure.AppoinmentService.Dtos.AppoinmentDtos;
using Doccure.AppoinmentService.Dtos.AppointmentDetailDtos;
using Doccure.AppoinmentService.Entities;

namespace Doccure.AppoinmentService.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Appointment, ResultAppoinmentDto>().ReverseMap();
            CreateMap<Appointment, CreateAppoinmentDto>().ReverseMap();
            CreateMap<Appointment, UpdateAppoinmentDto>().ReverseMap();
            CreateMap<Appointment, GetAppoinmentByIdDto>().ReverseMap();

            CreateMap<AppointmentDetail, ResultAppoinmentDetailDto>().ReverseMap();
            CreateMap<AppointmentDetail, CreateAppoinmentDetailDto>().ReverseMap();
            CreateMap<AppointmentDetail, UpdateAppoinmentDetailDto>().ReverseMap();
            CreateMap<AppointmentDetail, GetByIdAppoinmentDetailDto>().ReverseMap();
        }
    }
}
