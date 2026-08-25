using Doccure.PrescriptionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.PrescriptionService.Context
{
    public class PrescriptionContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=DoccureAppoinmentDb;Uid=sa;Pwd=aysu123;TrustServerCertificate=True;");
        }

        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionItem> PrescriptionItem { get; set; }

    }
}
