using Microsoft.Extensions.Options;
using VCHelper.Migration.Configuration;
using VCHelper.Migration.Models;

namespace VCHelper.Migration.Handlers
{
    internal class EmployeesHandler :MigrationHandler
    {
        public EmployeesHandler(IOptions<GeneralConfig> options) : base(options)
        {
        }

        public List<Employee> GetEmployees()
        {
            var fileContent = File.ReadAllLines(
                _config.DbFilePath[DbTypes.Employees],
                _encoding);

            var result = new List<Employee>();

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

        private Employee? GetTypeFromLine(string source)
        {
            var temp = source.Split(Convert.ToChar(9));

            if (temp.Length == 0)
            {
                return null;
            }

            var fullName = temp[0].Split(" ");

            var result = new Employee()
            {
                Lastname = fullName[0],
                Firstname = fullName[1],
                MiddleName= fullName[2],

                State = temp[1]
            };

            return result;
        }
    }
}
