using AutoMapper;
using Doccure.PrescriptionService.Dtos.PrescriptionDto;
using Doccure.PrescriptionService.Entities;

namespace Doccure.PrescriptionService.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Prescription, ResultPrescriptionDto>();
            CreateMap<CreatePrescriptionDto, Prescription>();
            CreateMap<PrescriptionItem, PrescriptionItemDto>().ReverseMap();
        }
    }
}
   