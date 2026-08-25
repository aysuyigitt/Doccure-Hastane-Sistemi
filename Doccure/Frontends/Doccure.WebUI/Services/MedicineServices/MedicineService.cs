using Doccure.WebUI.Dtos.MedicineDtos;
using Humanizer;
using Newtonsoft.Json;
using System.Text;

namespace Doccure.WebUI.Services.MedicineServices
{
    public class MedicineService : IMedicineService
    {
        private readonly HttpClient _httpClient;

        public MedicineService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateMedicineAsync(CreateMedicineDto createMedicineDto)
        {
            var jsonData = JsonConvert.SerializeObject(createMedicineDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync("http://localhost:5028/api/Medicines", stringContent);
        }

        public async Task DeleteMedicineAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"http://localhost:5028/api/Medicines?id={id}");
        }

        public async Task<List<ResultMedicineDto>> GetAllMedicinesAsync()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5028/api/Medicines");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultMedicineDto>>(jsonData);
            return values;
        }

        public async  Task<GetByIdMedicineDto> GetMedicineByIdAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"http://localhost:5028/api/Medicines/GetMedicine?id={id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetByIdMedicineDto>(jsonData);
            return values;
        }

        public async Task UpdateMedicineAsync(UpdateMedicineDto updateMedicineDto)
        {
            var jsonData = JsonConvert.SerializeObject(updateMedicineDto); StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PutAsync("http://localhost:5028/api/Medicines", stringContent);
        }
    }
}
