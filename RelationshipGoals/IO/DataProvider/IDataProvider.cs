using System.Threading.Tasks;

namespace RelationshipGoals.IO.DataProvider
{
    public interface IDataProvider
    {
        T Provide<T>(string key, string[] options = null);

        Task<T> ProvideAsync<T>(string key, string[] options = null);
    }
}