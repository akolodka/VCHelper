using Newtonsoft.Json;

namespace VCHelper.Migration
{
    internal class HardcodeSavior
    {
        public void Execute()
        {
            var GeneralConfig = new GeneralConfig()
            {
                ConnectionString = "Host=localhost;Port=5432;Database=nio210;Username=postgres;Password=postgres",

                DbFilePath = new Dictionary<DbTypes, string>
                {
                    { DbTypes.Customers, @"\\192.168.80.24\nio210\Помощник ПКР\210_customers.cuDb" },
                    { DbTypes.Instruments, @"\\192.168.80.24\nio210\Помощник ПКР\210_instruments.miDb" },
                    { DbTypes.Employees, @"\\192.168.80.24\nio210\Помощник ПКР\210_employees.nmDb" }
                },

                DbFolderPath = new Dictionary<DbTypes, string>
                {
                    {DbTypes.Customers, @"\\192.168.80.24\nio210\Помощник ПКР\organisations" }
                }
            };

            var wrapper = new { GeneralConfig };

            var content = JsonConvert.SerializeObject(wrapper, Formatting.Indented);

            var projectFolderPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            var filePath = Path.Combine(projectFolderPath, "appsettings.json");

            File.WriteAllText(filePath, content);

            Console.WriteLine(content);
        }
    }
}
