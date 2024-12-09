
namespace VCHelper.Migration.FileDbStrategies
{
    internal interface IFileDbImportStrategy <TEntity>
    {
        public TEntity? GetFromTextLine(string textline);

        public string? DbFilePath { get; }
    }
}
