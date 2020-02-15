using RelationshipGoals.IO.DataProvider.Implementation;
using RelationshipGoals.IO.DataWriter.Implementation;

namespace RelationshipGoals.IO
{
    public static class IOHandlers
    {
        public static FileDataProvider FileDataProvider { get; } = new FileDataProvider();
        public static WebContentProvider WebContentProvider { get; } = new WebContentProvider();
        public static FileDataWriter FileDataWriter { get; } = new FileDataWriter();
    }
}