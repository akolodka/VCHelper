namespace VCHelper.Migration
{
    public class Configuration
    {
        public string ConnectionString { get; set; }
        public Dictionary<DbTypes,string> DbFilePath { get; set; }

        public Dictionary<DbTypes, string> DbFolderPath { get; set; }
    }

    public enum DbTypes
    {
        customers,
        instruments,
        employees,
        etalons
    }
}
