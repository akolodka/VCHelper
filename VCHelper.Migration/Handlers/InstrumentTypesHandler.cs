using Microsoft.Extensions.Options;
using System.Text;
using VCHelper.Migration.Configuration;
using VCHelper.Migration.Models;

namespace VCHelper.Migration.Handlers
{
    internal class InstrumentTypesHandler : MigrationHandler
    {
        public InstrumentTypesHandler(IOptions<GeneralConfig> options) 
            : base(options)
        {
        }

        public List<InstrumentType> GetInstrumentTypes()
        {
            var fileContent = File.ReadAllLines(
                _config.DbFilePath[DbTypes.Instruments], 
                _encoding);

            var result = new List<InstrumentType>();

            foreach (var line in fileContent)
            {
                var item = GetTypeFromLine(line);

                if (item is not null)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        private InstrumentType? GetTypeFromLine(string source)
        {
            var temp = source.Split(Convert.ToChar(9));

            if (temp.Length == 0)
            {
                return null;
            }

            var result = new InstrumentType()
            {
                TypeName = temp[1],
                FullName = temp[0],
                RegNumber = temp[2],
                Methodic = temp[3]
            };

            return result;
        }
    }
}
