using Microsoft.Extensions.Options;
using VCHelper.Migration.Configuration;
using VCHelper.Migration.Extensions;
using VCHelper.Migration.Models;

namespace VCHelper.Migration.Handlers
{
    internal class CustomersHandler : MigrationHandler
    {
        public CustomersHandler(IOptions<GeneralConfig> options) 
            : base(options)
        {
        }

        public List<Customer> GetExistingCustomers()
        {
            var result = new List<Customer>();

            foreach (var folder in Directory.GetDirectories(_config.DbFolderPath[DbTypes.Customers]))
            {
                var filepath = Directory
                    .GetFiles(folder)
                    .FirstOrDefault();

                var customer = GetCustomerFromTxt(filepath);

                result.Add(customer);
            }

            return result;
        }

        private Customer GetCustomerFromTxt(string path)
        {
            var fileContent = File.ReadAllLines(path, _encoding);

            var defaultValue = "недоступно";

            return new Customer()
            {
                Keyword = Path.GetFileNameWithoutExtension(path),

                ShortName = fileContent[0].GetValueFromKeyValuePairLine(),

                FullName = fileContent[1].GetValueFromKeyValuePairLine() == defaultValue
                    ? null
                    : fileContent[1].GetValueFromKeyValuePairLine(),

                Country = fileContent[2].GetValueFromKeyValuePairLine() == defaultValue
                    ? null
                    : fileContent[2].GetValueFromKeyValuePairLine(),

                LegalAddress = fileContent[3].GetValueFromKeyValuePairLine(),

                INN = long.TryParse(fileContent[4].GetValueFromKeyValuePairLine(), out var result) == true
                    ? result
                    : null
            };
        }
    }
}
