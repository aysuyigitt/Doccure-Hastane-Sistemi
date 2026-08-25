using Doccure.WebUI.Dtos.QueueDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace Doccure.WebUI.ViewComponents.PatientViewComponents
{
    public class _CurrentPatientComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _CurrentPatientComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5155/api/Queues/current");
            var json = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<ResultPatientQueueDto>(json);
            return View(value);
        }
    }
}