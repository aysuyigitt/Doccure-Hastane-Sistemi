using Doccure.WebUI.Dtos.PatientDtos;

namespace Doccure.WebUI.Services.PatientService
{
    public interface IPatientService
    {

        Task<List<ResultPatientDto>> GetAllPatientsAsync();
    }
}
