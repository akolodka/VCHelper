﻿using System.Text;
using Microsoft.Extensions.Options;
using VCHelper.Migration.Extensions;
using VCHelper.Migration.Models;

namespace VCHelper.Migration
{
    internal class MigrationHandler
    {

        private GeneralConfig _config;

        public MigrationHandler(IOptions<GeneralConfig> options)
        {
            _config = options.Value;
        } 

        public List<InstrumentType> GetInstrumentTypes()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding win1251 = Encoding.GetEncoding("windows-1251");

            var fileContent = File.ReadAllLines(_config.DbFilePath[DbTypes.Instruments], win1251);

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
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding win1251 = Encoding.GetEncoding("windows-1251");

            var fileContent = File.ReadAllLines(path, win1251);

            return new Customer()
            {
                Keyword = Path.GetFileNameWithoutExtension(path),

                ShortName = fileContent[0].GetValueFromKeyValuePairLine(),

                FullName = fileContent[1].GetValueFromKeyValuePairLine() == "недоступно"
                    ? null
                    : fileContent[1].GetValueFromKeyValuePairLine(),

                Country = fileContent[2].GetValueFromKeyValuePairLine() == "недоступно"
                    ? null
                    : fileContent[2].GetValueFromKeyValuePairLine(),

                LegalAddress = fileContent[3].GetValueFromKeyValuePairLine(),

                INN = long.TryParse(fileContent[4].GetValueFromKeyValuePairLine(), out long result) == true
                    ? result
                    : null
            };
        }



    }
}
