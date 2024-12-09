namespace VCHelper.Migration.FolderDbStrategies
{
    internal interface IFolderDbImportStrategy <TEntity>
    {
        public TEntity? GetFromFileContent(string keyword, string[] fileContent);

        public string? DbFolderPath { get; }
    }
}
