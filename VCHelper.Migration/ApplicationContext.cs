using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VCHelper.Migration.Models;

namespace VCHelper.Migration
{
    internal class ApplicationContext : DbContext
    {
        private readonly GeneralConfig _config;

        public ApplicationContext(IOptions<GeneralConfig> options)
        {
            _config = options.Value;
        }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<InstrumentType> InstrumentTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_config.ConnectionString);
        }
    }
}
