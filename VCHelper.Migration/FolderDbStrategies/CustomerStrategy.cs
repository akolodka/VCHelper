using Microsoft.Extensions.Options;
using VCHelper.Migration.Configuration;
using VCHelper.Migration.Entities;
using VCHelper.Migration.Extensions;

namespace VCHelper.Migration.FolderDbStrategies
{
    internal class CustomerStrategy : BaseStrategy, IFolderDbImportStrategy<Customer>
    {
        public string? DbFolderPath { get; private set; }

        public CustomerStrategy(IOptions<GeneralConfig> options)
        {
            DbFolderPath = options.Value.DbFolderPath[DbTypes.Customers];
        }

        public Customer? GetFromFileContent(string keyword, string[] fileContent)
        {
            return new Customer()
            {
                Keyword = keyword,

                ShortName = fileContent[0].GetValueFromPair(),

                FullName = fileContent[1].GetValueFromPair() == DefaultValue
                    ? null
                    : fileContent[1].GetValueFromPair(),

                Country = fileContent[2].GetValueFromPair() == DefaultValue
                    ? null
                    : fileContent[2].GetValueFromPair(),

                LegalAddress = fileContent[3].GetValueFromPair(),

                INN = long.TryParse(fileContent[4].GetValueFromPair(), out var result) == true
                    ? result
                    : null
            };
        }
    }
}
