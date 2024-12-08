using System.Text;
using Microsoft.Extensions.Options;
using VCHelper.Migration.Configuration;
using VCHelper.Migration.Extensions;
using VCHelper.Migration.Models;

namespace VCHelper.Migration.Handlers
{
    internal class MigrationHandler
    {
        protected IMigrationConfig _config;

        protected Encoding _encoding;

        public MigrationHandler(IOptions<GeneralConfig> options)
        {
            _config = options.Value;

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            _encoding = Encoding.GetEncoding("windows-1251");
        }
    }
}
