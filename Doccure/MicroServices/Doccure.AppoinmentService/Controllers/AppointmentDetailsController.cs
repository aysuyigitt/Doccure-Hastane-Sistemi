using Doccure.AppoinmentService.Dtos.AppointmentDetailDtos;
using Doccure.AppoinmentService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.AppoinmentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentDetailsController : ControllerBase
    {
        private readonly IAppoinmentDetailService _appoinmentDetailService;

        public AppointmentDetailsController(IAppoinmentDetailService appoinmentDetailService)
        {
            _appoinmentDetailService = appoinmentDetailService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointmentDetail(CreateAppoinmentDetailDto createAppoinmentDetailDto)
        {
            await _appoinmentDetailService.CreateAsync(createAppoinmentDetailDto);
            return Ok("Ekleme başarılı");
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointmentDetail(int id)
        {
            var value = await  _appoinmentDetailService.GetByAppointmentIdAsync(id);
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppointmentDetail(UpdateAppoinmentDetailDto updateAppoinmentDetailDto)
        {
            await _appoinmentDetailService.UpdateAsync(updateAppoinmentDetailDto);
            return Ok("Güncelleme başarılı");
        }
    }
}
