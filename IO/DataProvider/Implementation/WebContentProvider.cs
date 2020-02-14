using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RelationshipGoals.IO.DataProvider.Implementation
{
    public class WebContentProvider : IDataProvider
    {
        public T Provide<T>(string key, string[] options = null)
        {
            using (WebClient webClient = new WebClient())
                return (T)Convert.ChangeType(webClient.DownloadString(key), typeof(T));
        }

        public async Task<T> ProvideAsync<T>(string key, string[] options = null)
        {
            using (WebClient webClient = new WebClient())
                return (T)Convert.ChangeType(await webClient.DownloadStringTaskAsync(key), typeof(T));
        }
    }
}