using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VCHelper.Migration.Comparers;
using VCHelper.Migration.Configuration;
using Files = VCHelper.Migration.FileDbStrategies;
using Folders = VCHelper.Migration.FolderDbStrategies;

namespace VCHelper.Migration
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHost();

            var handler = new MigrationHandler();

            using var db = ActivatorUtilities.CreateInstance<ApplicationContext>(host.Services);

            try
            {
                //var folderCustomers = handler.GetFromDbFolder(
                //    ActivatorUtilities.CreateInstance<Folders.CustomerStrategy>(host.Services));

                var existingCustomers = db.Customers.ToList();

                var fileCustomers = handler.GetFromDbFile(
                    ActivatorUtilities.CreateInstance<Files.CustomerStrategy>(host.Services));

                var customers = fileCustomers
                    .Except(existingCustomers, new CustomerEqualityComparer())
                    .ToList();

                db.Customers.AddRange(customers);

                //var employees = handler.GetFromDbFile(
                //    ActivatorUtilities.CreateInstance<Files.EmployeeStrategy>(host.Services));

                //db.Employees.AddRange(employees);

                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static IHost CreateHost()
        {
            var builder = Host.CreateApplicationBuilder();

            builder.Services
                .AddOptions<GeneralConfig>()
                .BindConfiguration(nameof(GeneralConfig));

            return builder.Build();
        }
    }
}