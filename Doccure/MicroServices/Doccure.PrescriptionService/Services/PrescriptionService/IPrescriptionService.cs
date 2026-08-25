using Doccure.PrescriptionService.Dtos.PrescriptionDto;

namespace Doccure.PrescriptionService.Services.PrescriptionService
{
    public interface IPrescriptionService
    {
        Task CreateAsync(CreatePrescriptionDto dto);
        Task<ResultPrescriptionDto> GetByAppoinmentIdAsync(int appoinmentId);
        Task<List<ResultPrescriptionDto>> GetByPatientIdAsync(string patientId);
        Task<ResultPrescriptionDto> GetByIdAsync(int id);
    }
}
