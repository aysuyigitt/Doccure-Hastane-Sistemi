using Doccure.PrescriptionService.Dtos.PrescriptionDto;
using Doccure.PrescriptionService.Services.PrescriptionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.PrescriptionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionService _service;

        public PrescriptionsController(IPrescriptionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrescription(CreatePrescriptionDto createPrescriptionDto)
        {
            await _service.CreateAsync(createPrescriptionDto);
            return Ok("Ekleme başarılı");
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _service.GetByIdAsync(id);
            if(value == null)
                return NotFound("Reçete bulunamadı");

            return Ok(value);
        }

        [HttpGet("GetByAppointmentId")]
        public async Task<IActionResult> GetByAppointmentId(int id)
        {
            var value = await _service.GetByAppoinmentIdAsync(id);

            if (value == null)
                return NotFound("Reçete bulunamadı");

            return Ok(value);
        }

        [HttpGet("GetByPatientId")]
        public async Task<IActionResult> GetByPatientId(string id)
        {
            var values = await _service.GetByPatientIdAsync(id);
            if (values == null)
                return NotFound("Reçete bulunamadı");

            return Ok(values);
        }


    }
}
