namespace VCHelper.Migration
{
    public class GeneralConfig
    {
        public string? ConnectionString { get; set; }
        public Dictionary<DbTypes,string>? DbFilePath { get; set; }

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
