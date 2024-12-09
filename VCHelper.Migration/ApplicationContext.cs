using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VCHelper.Migration.Configuration;
using VCHelper.Migration.Entities;

namespace VCHelper.Migration
{
    internal class ApplicationContext : DbContext
    {
        private readonly IDbContextConfig Config;

        public DbSet<Customer> Customers { get; set; }

        public DbSet<InstrumentType> InstrumentTypes { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public ApplicationContext(IOptions<GeneralConfig> options)
        {
            Config = options.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Config.DefaultConnection);
        }
    }
}
