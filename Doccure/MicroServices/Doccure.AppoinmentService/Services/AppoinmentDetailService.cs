using AutoMapper;
using Doccure.AppoinmentService.Context;
using Doccure.AppoinmentService.Dtos.AppointmentDetailDtos;
using Doccure.AppoinmentService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.AppoinmentService.Services
{
    public class AppoinmentDetailService : IAppoinmentDetailService
    {
        private readonly IMapper _mapper;
        private readonly AppoinmentContext _context;

        public AppoinmentDetailService(IMapper mapper, AppoinmentContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task CreateAsync(CreateAppoinmentDetailDto dto)
        {
            var value = _mapper.Map<AppointmentDetail>(dto);
            value.CompletedDate = DateTime.Now;
            await _context.AppointmentDetails.AddAsync(value);
            var appoinment = _context.Appointments.FirstOrDefaultAsync(x => x.AppointmentId == dto.AppointmentId);
            await _context.SaveChangesAsync();
        }

        public async Task<ResultAppoinmentDetailDto> GetByAppointmentIdAsync(int appointmentId)
        {
            var value = await _context.AppointmentDetails.FirstOrDefaultAsync(x => x.AppointmentDetailId == appointmentId);
            return _mapper.Map<ResultAppoinmentDetailDto>(value);

        }

        public async Task UpdateAsync(UpdateAppoinmentDetailDto dto)
        {
            var value = await _context.AppointmentDetails.FirstOrDefaultAsync(x => x.AppointmentDetailId == dto.AppointmentDetailId);
            value.Complaint = dto.Complaint;
            value.Notes = dto.Notes;
            value.Diagnosis = dto.Diagnosis;
            value.Prescription = dto.Diagnosis;
            _context.AppointmentDetails.Update(value);
            await _context.SaveChangesAsync();

        }
    }
}
