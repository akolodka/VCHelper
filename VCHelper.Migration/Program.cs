using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VCHelper.Migration.Configuration;
using VCHelper.Migration.Handlers;

namespace VCHelper.Migration
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHost();

            using var db = ActivatorUtilities.CreateInstance<ApplicationContext>(host.Services);
            
            var iHandler = ActivatorUtilities.CreateInstance<InstrumentTypesHandler>(host.Services);
            iHandler.GetInstrumentTypes();

            
            var cHandler = ActivatorUtilities.CreateInstance<CustomersHandler>(host.Services);
            cHandler.GetExistingCustomers();

            
        }

        public static IHost CreateHost()
        {
            var builder = Host.CreateApplicationBuilder();

            builder.Services.AddOptions<GeneralConfig>()
                .BindConfiguration(nameof(GeneralConfig));

            return builder.Build();
        }
    }
}