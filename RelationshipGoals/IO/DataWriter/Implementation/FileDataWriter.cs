using System.IO;
using System.Threading.Tasks;

namespace RelationshipGoals.IO.DataWriter.Implementation
{
    public class FileDataWriter : IDataWriter
    {
        public void Write(string key, object obj, string[] options = null)
        {
            if (!Directory.Exists(Path.GetDirectoryName(key)))
                throw new FileNotFoundException($"The file {Path.GetFileName(key)} can't be written to because {Path.GetDirectoryName(key)} does not exist.");

            using (StreamWriter streamWriter = new StreamWriter(File.OpenRead(key)))
                streamWriter.Write((string)obj);
        }

        public async Task WriteAsync(string key, object obj, string[] options = null)
        {
            if (!Directory.Exists(Path.GetDirectoryName(key)))
                throw new FileNotFoundException($"The file {Path.GetFileName(key)} can't be written to because {Path.GetDirectoryName(key)} does not exist.");

            using (StreamWriter streamWriter = new StreamWriter(File.OpenRead(key)))
                await streamWriter.WriteAsync((string)obj);
        }
    }
}