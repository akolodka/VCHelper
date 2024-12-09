using Microsoft.Extensions.Options;
using VCHelper.Migration.Configuration;
using VCHelper.Migration.Entities;

namespace VCHelper.Migration.FileDbStrategies
{
    internal class CustomerStrategy : IFileDbImportStrategy<Customer>
    {
        public string? DbFilePath { get; private set; }

        public CustomerStrategy(IOptions<GeneralConfig> options)
        {
            DbFilePath = options.Value.DbFilePath[DbTypes.Customers];
        }

        public Customer? GetFromTextLine(string textline)
        {
            var temp = textline.Split(Convert.ToChar(9));

            if (temp.Length == 0)
            {
                return null;
            }

            return new Customer()
            {
                ShortName = temp[0],

                INN =  long.TryParse(temp[1], out var result)
                        ? result
                        : null,

                Keyword = temp[2],

                LegalAddress = temp[3]
            };
        }
    }
}
