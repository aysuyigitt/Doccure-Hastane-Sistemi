using Doccure.QueueService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.QueueService.Context
{
    public class QueueContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=DoccureQueueDb;Uid=sa;Pwd=aysu123;TrustServerCertificate=True;");
        }

        public DbSet<PatientQueue> PaitentQueues { get; set; }
    }
}
