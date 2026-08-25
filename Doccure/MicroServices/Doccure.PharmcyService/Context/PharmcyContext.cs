using Doccure.PharmcyService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.PharmcyService.Context
{
    public class PharmacyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=DoccurePharmcyDb;Uid=sa;Pwd=aysu123;TrustServerCertificate=True;");
        }
        public DbSet<Medicine> Medicines { get; set; }
    }
}