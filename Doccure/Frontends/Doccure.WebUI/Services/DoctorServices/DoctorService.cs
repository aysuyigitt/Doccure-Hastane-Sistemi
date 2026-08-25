using Doccure.WebUI.Dtos.BranchDtos;
using Doccure.WebUI.Dtos.DoctorDtos;
using Humanizer;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;
using System.Text;

namespace Doccure.WebUI.Services.DoctorServices
{
    public class DoctorService : IDoctorService
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _contextAccessor;

        public DoctorService(HttpClient httpClient, IHttpContextAccessor contextAccessor)
        {
            _client = httpClient;
            _contextAccessor = contextAccessor;
        }

        public async Task CreateDoctorAsync(CreateDoctorDto createDoctorDto)
        {
            PrepareAuthorizationHeader();
            createDoctorDto.Status = true;
            createDoctorDto.PricePerHour = 1000;

            // Null list'leri boş listeye çevir (API [Required] validation'ı atlat)
            createDoctorDto.Educations ??= new List<EducationDto>();
            createDoctorDto.Experiences ??= new List<ExperienceDto>();
            createDoctorDto.Awards ??= new List<AwardDto>();
            createDoctorDto.Locations ??= new List<LocationDto>();
            createDoctorDto.Services ??= new List<string>();
            createDoctorDto.Specializations ??= new List<string>();

            createDoctorDto.ExperienceYear = createDoctorDto.ExperienceYear == 0 ? 1 : createDoctorDto.ExperienceYear;
            var jsonData = JsonConvert.SerializeObject(createDoctorDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _client.PostAsync("http://localhost:46413/api/Doctors", stringContent);
            await HandleResponseErrors(responseMessage);
        }

        public async Task DeleteDoctorAsync(string id)
        {
            PrepareAuthorizationHeader();
            var responseMessage = await _client.DeleteAsync($"http://localhost:46413/api/doctors?id={id}");
            await HandleResponseErrors(responseMessage);
        }

        public async Task<List<ResultDoctorDto>> GetAllDoctorsAsync()
        {
            PrepareAuthorizationHeader();
            var responseMessage = await _client.GetAsync("http://localhost:46413/api/Doctors");
            await HandleResponseErrors(responseMessage);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultDoctorDto>>(jsonData);
            return values;
        }

        public async Task<GetByIdDoctorDto> GetDoctorByIdAsync(string id)
        {
            PrepareAuthorizationHeader();
            var responseMessage = await _client.GetAsync($"http://localhost:46413/api/Doctors/GetDoctor?id={id}");
            await HandleResponseErrors(responseMessage);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetByIdDoctorDto>(jsonData);
                return values;
            }

            return null;
        }

        public async Task UpdateDoctorAsync(UpdateDoctorDto updateDoctorDto)
        {
            PrepareAuthorizationHeader();
            var jsonData = JsonConvert.SerializeObject(updateDoctorDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await _client.PutAsync("http://localhost:46413/api/Doctors", stringContent);
            await HandleResponseErrors(responseMessage);
        }

        private void PrepareAuthorizationHeader()
        {
            var token = _contextAccessor.HttpContext.Session.GetString("JwtToken");
            token = token?.Trim().Replace("\"", "");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        private async Task HandleResponseErrors(HttpResponseMessage responseMessage)
        {
            if (responseMessage.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new UnauthorizedAccessException("403");
            }

            if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("401");
            }

            if (responseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("404");
            }

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception("Bir hata oluştu");
            }
        }
    }
}





