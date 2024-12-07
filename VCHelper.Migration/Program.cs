using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace VCHelper.Migration
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHost();

            var handler = ActivatorUtilities.CreateInstance<MigrationHandler>(host.Services);

            handler.GetInstrumentTypes();
            
        }

        public static IHost CreateHost()
        {
            var builder = Host.CreateApplicationBuilder();

            builder.Configuration.Sources.Clear();

            builder.Configuration.AddJsonFile("appsettings.json",
                optional: false, reloadOnChange: true);

            builder.Services.Configure<GeneralConfig>(
                builder.Configuration.GetSection(nameof(GeneralConfig))
            );

            return builder.Build();
        }
    }
}