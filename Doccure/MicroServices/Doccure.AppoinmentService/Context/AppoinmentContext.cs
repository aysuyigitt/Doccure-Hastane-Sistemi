using Doccure.AppoinmentService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.AppoinmentService.Context
{
    public class AppoinmentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=DoccureAppoinmentDb;Uid=sa;Pwd=aysu123;TrustServerCertificate=True;");
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentDetail> AppointmentDetails { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }

    }
}
