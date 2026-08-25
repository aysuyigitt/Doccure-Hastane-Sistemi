using AutoMapper;
using Doccure.PharmcyService.Dtos.MedicineDtos;
using Doccure.PharmcyService.Entities;

namespace Doccure.PharmcyService.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Medicine, ResultMedicineDto>().ReverseMap();
            CreateMap<Medicine, CreateMedicineDto>().ReverseMap();
            CreateMap<Medicine, UpdateMedicineDto>().ReverseMap();
            CreateMap<Medicine, GetByIdMedicineDto>().ReverseMap();
        }
    }
}