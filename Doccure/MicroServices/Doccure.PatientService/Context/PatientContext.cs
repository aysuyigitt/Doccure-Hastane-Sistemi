using Doccure.PatientService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.PatientService.Context
{
    public class PatientContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=DoccurePatientDb;Uid=sa;Pwd=aysu123;TrustServerCertificate=True;");
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientVisit> PatientVisits { get; set; }
    }
}
