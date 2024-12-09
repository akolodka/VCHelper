using Microsoft.Extensions.Options;
using VCHelper.Migration.Configuration;
using VCHelper.Migration.Entities;

namespace VCHelper.Migration.FileDbStrategies
{
    internal class EmployeeStrategy : IFileDbImportStrategy<Employee>
    {
        public string? DbFilePath { get; private set; }

        public EmployeeStrategy(IOptions<GeneralConfig> options)
        {
            DbFilePath = options.Value.DbFilePath[DbTypes.Employees];
        }

        public Employee? GetFromTextLine(string textline)
        {
            var temp = textline.Split(Convert.ToChar(9));

            if (temp.Length == 0)
            {
                return null;
            }

            var fullName = temp[0].Split(" ");

            return new Employee()
            {
                Lastname = fullName[0],
                Firstname = fullName[1],
                MiddleName = fullName[2],

                State = temp[1]
            };
        }
    }
}
