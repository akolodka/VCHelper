namespace VCHelper.Migration.Configuration
{
    public class GeneralConfig : IDbContextConfig
    {
        public string? DefaultConnection { get; set; }

        public Dictionary<DbTypes, string>? DbFilePath { get; set; }

        public Dictionary<DbTypes, string>? DbFolderPath { get; set; }
    }

    public enum DbTypes
    {
        Customers,
        Instruments,
        Employees,
        Etalons
    }
}
