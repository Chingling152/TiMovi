using NewWorld.Data.Streams.Readers.Abstractions;
using NewWorld.Data.Streams.Writers.Abstractions;

namespace NewWorld.Data.Adapters.Abstractions
{
    public interface IMapAdapter<T>
    {
        bool IsReadOnly { get; }

        IMapReader<T> Reader { get; }
        IMapWriter<T> Writer { get; }

        T Read(int x, int y);
        T Write(int x, int y, object data);
    }
}
