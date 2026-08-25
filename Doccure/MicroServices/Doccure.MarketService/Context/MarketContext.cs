using Doccure.MarketService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.MarketService.Context
{
    public class MarketContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=DoccureMarketDb;Uid=sa;Pwd=aysu123;TrustServerCertificate=True;");
        }

        public DbSet<Product> Products { get; set; }
    }
}
