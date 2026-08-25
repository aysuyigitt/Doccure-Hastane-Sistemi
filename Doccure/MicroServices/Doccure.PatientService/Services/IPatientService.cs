using Doccure.PatientService.Dtos.PatientDtos;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Doccure.PatientService.Services
{
    public interface IPatientService
    {
        Task<List<ResultPatientDto>> GetAllPatientsAsync();
         
    }
}
