using Doccure.WebUI.Dtos.BranchDtos;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Doccure.WebUI.Services.BranchServices
{
    public class BranchService : IBranchService
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _contextAccessor;

        public BranchService(HttpClient client, IHttpContextAccessor contextAccessor)
        {
            _client = client;
            _contextAccessor = contextAccessor;
        }

        public async Task CreateBranchAsync(CreateBranchDto createBranchDto)
        {
            PrepareAuthorizationHeader();
            var jsonData = JsonConvert.SerializeObject(createBranchDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage =await _client.PostAsync("http://localhost:14971/api/Branches", stringContent);
            await HandleResponseErrors(responseMessage);

        }

        public async Task DeleteBranchAsync(string id)
        {
            PrepareAuthorizationHeader();
            var responseMessage = await _client.DeleteAsync($"http://localhost:14971/api/branches?id={id}");
            await HandleResponseErrors(responseMessage);

        }

        public async Task<List<ResultBranchDto>> GetAllBranchesAsync()
        {
            PrepareAuthorizationHeader();
            var responseMessage = await _client.GetAsync("http://localhost:14971/api/Branches");

            await HandleResponseErrors(responseMessage);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBranchDto>>(jsonData);
            return values;
            throw new NotImplementedException();
        }

        public async Task<GetByIdBranchDto> GetBranchByIdAsync(string id)
        {
            PrepareAuthorizationHeader();
            var responseMessage = await _client.GetAsync($"http://localhost:14971/api/Branches/GetBranch?id={id}");
            await HandleResponseErrors(responseMessage);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values =JsonConvert.DeserializeObject<GetByIdBranchDto>(jsonData);
                return values;
            }

            return null;
        }

        public async Task UpdateBranchAsync(UpdateBranchDto dto)
        {
            PrepareAuthorizationHeader();
            var jsonData = JsonConvert.SerializeObject(dto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await _client.PutAsync("http://localhost:14971/api/Branches",stringContent);
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


