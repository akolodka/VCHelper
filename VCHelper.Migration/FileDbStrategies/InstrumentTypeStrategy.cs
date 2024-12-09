using Microsoft.Extensions.Options;
using VCHelper.Migration.Configuration;
using VCHelper.Migration.Entities;

namespace VCHelper.Migration.FileDbStrategies
{
    internal class InstrumentTypeStrategy : IFileDbImportStrategy<InstrumentType>
    {
        public string? DbFilePath { get; private set; }

        public InstrumentTypeStrategy(IOptions<GeneralConfig> options)
        {
            DbFilePath = options.Value.DbFilePath[DbTypes.Instruments];
        }

        public InstrumentType? GetFromTextLine(string textline)
        {
            var temp = textline.Split(Convert.ToChar(9));

            if (temp.Length == 0)
            {
                return null;
            }

            return new InstrumentType()
            {
                TypeName = temp[1],
                FullName = temp[0],
                RegNumber = temp[2],
                Methodic = temp[3]
            };
        }
    }
}
