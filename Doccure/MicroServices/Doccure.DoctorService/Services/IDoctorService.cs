using Doccure.DoctorService.Dtos.DoctorDtos;

namespace Doccure.DoctorService.Services
{
    public interface IDoctorService
    {
        Task<List<ResultDoctorDto>> GetAllAsync();
        Task<GetByIdDoctorDto> GetByIdAsync(string id);
        Task CreateAsync(CreateDoctorDto dto);
        Task UpdateAsync(UpdateDoctorDto dto);
        Task DeleteAsync(string id);
        Task<GetDoctorNameAndSurnameByıdDto> GetDoctorByIdAsync(string id);
    }
}
