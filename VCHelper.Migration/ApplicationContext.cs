using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VCHelper.Migration.Configuration;
using VCHelper.Migration.Models;

namespace VCHelper.Migration
{
    internal class ApplicationContext : DbContext
    {
        private readonly IDbContextConfig _config;

        public ApplicationContext(IOptions<GeneralConfig> options)
        {
            _config = options.Value;

            Database.EnsureCreated();
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<InstrumentType> InstrumentTypes { get; set; }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_config.DefaultConnection);
        }
    }
}
