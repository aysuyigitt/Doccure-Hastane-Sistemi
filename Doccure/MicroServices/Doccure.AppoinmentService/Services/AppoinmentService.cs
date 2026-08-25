using AutoMapper;
using Doccure.AppoinmentService.Context;
using Doccure.AppoinmentService.Dtos.AppoinmentDtos;
using Doccure.AppoinmentService.Entities;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Doccure.AppoinmentService.Services
{
    public class AppoinmentService : IAppoinmentService
    {
        private readonly IMapper _mapper;
        private readonly AppoinmentContext _context;

        public AppoinmentService(IMapper mapper, AppoinmentContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task CreateAsync(CreateAppoinmentDto dto)
        {
            var value = _mapper.Map<Appointment>(dto);
            value.Status = "Pending";
            await _context.Appointments.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await _context.Appointments.FindAsync(id);
            _context.Appointments.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultAppoinmentDto>> GetAllAsync()
        {
            var values = await _context.Appointments.ToListAsync();
            return _mapper.Map<List<ResultAppoinmentDto>>(values);
        }

        public async Task<GetAppoinmentByIdDto?> GetByIdAsync(int id)
        {
            var value = await _context.Appointments.FindAsync(id);
            return _mapper.Map<GetAppoinmentByIdDto?>(value);
        }

        public async Task<LastAppoinmentDto> GetLastAppoinmentByPatientIdAsync(string patientId)
        {
            var value = await _context.Appointments.Include(x => x.AppointmentDetail).Where(x => x.PatientId == patientId).OrderByDescending(x => x.AppointmentDate).FirstOrDefaultAsync();

            if (value == null)
                return null;

            return new LastAppoinmentDto
            {
                AppointmentId = value.AppointmentId,
                DoctorId = value.DoctorId,
                BranchId = value.BranchId,
                AppointmentDate = value.AppointmentDate,
                Diagnosis = value.AppointmentDetail.Diagnosis,
                Status = value.Status
            };
        }
        
        public async Task UpdateAsync(UpdateAppoinmentDto dto)
        {
            var value = await _context.Appointments.FindAsync(dto.AppointmentId);
            _context.Appointments.Update(value);
            await _context.SaveChangesAsync();

        }
    }
}

