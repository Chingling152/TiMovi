using NewWorld.Data.Streams.Readers.Abstractions;

namespace NewWorld.Data.Adapters.Abstractions
{
    public interface IMapReaderAdapter<T>
    {
        IMapReader<T> Reader { get; }
        T Read(int x, int y);
    }
}
