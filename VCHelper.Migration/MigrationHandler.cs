using System.Text;
using VCHelper.Migration.FileDbStrategies;
using VCHelper.Migration.FolderDbStrategies;

namespace VCHelper.Migration
{
    internal class MigrationHandler
    {
        private Encoding Encoding { get; }

        public MigrationHandler()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding = Encoding.GetEncoding("windows-1251");
        }

        public List<TEntity> GetFromDbFile<TEntity>(IFileDbImportStrategy<TEntity> strategy)
        {
            var result = new List<TEntity>();

            if (File.Exists(strategy.DbFilePath) == false)
            {
                return result;
            }

            var fileContent = File.ReadAllLines(strategy.DbFilePath, Encoding);

            foreach (var line in fileContent)
            {
                var item = strategy.GetFromTextLine(line);

                if (item is not null)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<TEntity> GetFromDbFolder<TEntity>(IFolderDbImportStrategy<TEntity> strategy)
        {
            var result = new List<TEntity>();

            var subfolders = Directory.GetDirectories(strategy.DbFolderPath);

            if (subfolders.Any() == false)
            {
                return result;
            }

            foreach (var folder in subfolders)
            {
                var filepath = Directory.GetFiles(folder).FirstOrDefault();

                if (filepath is null)
                {
                    continue;
                }

                var keyword = Path.GetFileNameWithoutExtension(filepath);

                var fileContent = File.ReadAllLines(filepath, Encoding);

                var item = strategy.GetFromFileContent(keyword, fileContent);

                if (item is not null)
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }
}
