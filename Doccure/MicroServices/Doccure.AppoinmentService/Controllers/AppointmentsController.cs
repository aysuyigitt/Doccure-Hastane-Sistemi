using Doccure.AppoinmentService.Dtos.AppoinmentDtos;
using Doccure.AppoinmentService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.AppoinmentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppoinmentService _service;
        public AppointmentsController(IAppoinmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointment()
        {
            var values = await _service.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("GetAppointment")]
        public async Task<IActionResult> GetAppointment(int id)
        {
            var value = await _service.GetByIdAsync(id);
            if (value == null)
                return NotFound("Randevu bulunamadı");
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment(CreateAppoinmentDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok("Randevu başarıyla oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppointment(UpdateAppoinmentDto dto)
        {
            await _service.UpdateAsync(dto);
            return Ok("Randevu başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Randevu başarıyla silindi");
        }

        [HttpGet("patient/{patientId}/last")]
        public async Task<IActionResult> GetLastAppointmentByPatientId(string patientId)
        {
            var value = await _service.GetLastAppoinmentByPatientIdAsync(patientId);

            if (value == null)
                return NotFound();

            return Ok(value);
        }
    }
}
