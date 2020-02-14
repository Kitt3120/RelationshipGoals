using System.Threading.Tasks;

namespace RelationshipGoals.IO.DataWriter
{
    public interface IDataWriter
    {
        void Write(string key, object obj, string[] options = null);

        Task WriteAsync(string key, object obj, string[] options = null);
    }
}