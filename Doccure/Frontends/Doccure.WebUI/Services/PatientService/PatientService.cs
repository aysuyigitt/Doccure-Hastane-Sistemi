using Doccure.WebUI.Dtos.PatientDtos;
using Newtonsoft.Json;

namespace Doccure.WebUI.Services.PatientService
{
    public class PatientService : IPatientService
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _contextAccessor;

        public PatientService(HttpClient client, IHttpContextAccessor contextAccessor)
        {
            _client = client;
            _contextAccessor = contextAccessor;
        }

        public async Task<List<ResultPatientDto>> GetAllPatientsAsync()
        {
            var responseMessage = await _client.GetAsync("http://localhost:5281/api/Patients");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultPatientDto>>(jsonData);
            return values;
        }
    }
}
