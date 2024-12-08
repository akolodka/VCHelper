namespace VCHelper.Migration.Configuration
{
    internal interface IMigrationConfig
    {
        public Dictionary<DbTypes, string>? DbFilePath { get; set; }

        public Dictionary<DbTypes, string>? DbFolderPath { get; set; }
    }
}
