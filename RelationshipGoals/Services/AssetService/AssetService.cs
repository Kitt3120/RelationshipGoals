using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RelationshipGoals.Services.AssetService
{
    public class AssetService : AssetFolder
    {
        public AssetService() : base(null, Path.Combine(AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin")), "Assets"))
        { }

        public AssetFolder FindSub(string path) => FindSub(path.Split(Path.DirectorySeparatorChar));

        public AssetFolder FindSub(string[] chain)
        {
            if (chain.Length == 0)
                return this;

            AssetFolder assetFolder = FilterSubs(chain[0]).FirstOrDefault();
            if (assetFolder == null)
                throw new DirectoryNotFoundException($"Directory {Path.Combine(Information.FullName, chain[0])} not found.");

            for (int i = 1; i < chain.Length; i++)
            {
                AssetFolder next = assetFolder.FilterSubs(chain[i]).FirstOrDefault();
                if (next == null)
                    throw new DirectoryNotFoundException($"Directory {Path.Combine(assetFolder.Information.FullName, chain[i])} not found.");
                assetFolder = next;
            }

            return assetFolder;
        }

        public async Task WriteToAsync(AssetFolder assetFolder, string fileName, byte[] data, FileMode fileMode)
        {
            //await File.WriteAllBytesAsync(Path.Combine(assetFolder.FolderPath, fileName), data); Replaced by version below so file content can also be appended with FileMode.

            using (FileStream fileStream = File.Open(Path.Combine(assetFolder.Information.FullName, fileName), fileMode, FileAccess.Write))
                await fileStream.WriteAsync(data, 0, data.Length);
        }

        public byte[] ReadFromAsync(AssetFolder assetFolder, string fileName) => File.ReadAllBytes(Path.Combine(assetFolder.Information.FullName, fileName));
    }
}