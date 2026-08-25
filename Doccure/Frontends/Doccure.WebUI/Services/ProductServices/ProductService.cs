using Doccure.WebUI.Dtos.ProductDtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace Doccure.WebUI.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _contextAccessor;

        public ProductService(HttpClient client, IHttpContextAccessor contextAccessor)
        {
            _client = client;
            _contextAccessor = contextAccessor;
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            var responseMessage = await _client.GetAsync("http://localhost:5206/api/Products");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return values;
        }
    }
}
