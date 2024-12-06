using Microsoft.EntityFrameworkCore;
using VCHelper.Migration.Models;

namespace VCHelper.Migration
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<InstrumentType> InstrumentTypes { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=nio210;Username=postgres;Password=postgres");
        }
    }
}
