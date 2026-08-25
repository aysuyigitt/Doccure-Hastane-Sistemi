using Doccure.AppoinmentService.Dtos.AppointmentDetailDtos;

namespace Doccure.AppoinmentService.Services
{
    public interface IAppoinmentDetailService
    {
        Task CreateAsync(CreateAppoinmentDetailDto dto);
        Task<ResultAppoinmentDetailDto> GetByAppointmentIdAsync(int appointmentId);
        Task UpdateAsync(UpdateAppoinmentDetailDto dto);
    }
}
