using Newtonsoft.Json;

namespace VCHelper.Migration
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var config = new Configuration()
            {
                ConnectionString = "Host=localhost;Port=5432;Database=nio210;Username=postgres;Password=postgres",

                DbFilePath = new Dictionary<DbTypes, string>
                {
                    { DbTypes.customers, @"\\192.168.80.24\nio210\Помощник ПКР\210_customers.cuDb" },
                    { DbTypes.instruments, @"\\192.168.80.24\nio210\Помощник ПКР\210_instruments.miDb" },
                    { DbTypes.employees, @"\\192.168.80.24\nio210\Помощник ПКР\210_employees.nmDb" }
                },

                DbFolderPath = new Dictionary<DbTypes, string>
                {
                    {DbTypes.customers, @"\\192.168.80.24\nio210\Помощник ПКР\organisations" }
                }
            };

            var content = JsonConvert.SerializeObject(config);


            
            var filePath = Path.Combine(
                Directory.GetParent(
                      Environment.CurrentDirectory)
                    .Parent.Parent.FullName,
                "appsettings.json");

            File.AppendAllText(filePath, content);

            //var handler = new MigrationHandler();

            //var types = handler.GetInstrumentTypes();

            //using var db = new ApplicationContext();

            //db.InstrumentTypes.AddRange(types);
            //db.SaveChanges();

            /* var customers = db.Customers.ToList();
             Console.WriteLine("Customer list: ");

             foreach (var customer in customers)
             {
                 Console.WriteLine($"{customer.CustomerId} -- {customer.ShortName}");
             }
            */
        }
    }
}