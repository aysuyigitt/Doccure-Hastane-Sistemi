using Doccure.AppoinmentService.Dtos.AppoinmentDtos;
using Doccure.AppoinmentService.Entities;

namespace Doccure.AppoinmentService.Services
{
    public interface IAppoinmentService
    {
        public Task<List<ResultAppoinmentDto>> GetAllAsync();
        public Task<GetAppoinmentByIdDto?> GetByIdAsync(int id);
        Task CreateAsync(CreateAppoinmentDto dto);
        Task UpdateAsync(UpdateAppoinmentDto dto);
        public Task DeleteAsync(int id);
        Task<LastAppoinmentDto> GetLastAppoinmentByPatientIdAsync(string patientId);
    }
}
