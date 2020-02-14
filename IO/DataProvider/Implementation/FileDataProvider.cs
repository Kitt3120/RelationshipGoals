using System;
using System.IO;
using System.Threading.Tasks;

namespace RelationshipGoals.IO.DataProvider.Implementation
{
    public class FileDataProvider : IDataProvider
    {
        public T Provide<T>(string key, string[] options = null)
        {
            string s = null;
            using (StreamReader streamReader = new StreamReader(File.OpenRead(key)))
                s = streamReader.ReadToEnd();

            return (T)Convert.ChangeType(s, typeof(T));
        }

        public async Task<T> ProvideAsync<T>(string key, string[] options = null)
        {
            string s = null;
            using (StreamReader streamReader = new StreamReader(File.OpenRead(key)))
                s = await streamReader.ReadToEndAsync();

            return (T)Convert.ChangeType(s, typeof(T));
        }
    }
}