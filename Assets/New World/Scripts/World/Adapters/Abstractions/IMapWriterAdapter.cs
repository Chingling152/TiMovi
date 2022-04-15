using NewWorld.Data.Streams.Writers.Abstractions;

namespace NewWorld.World.Adapters.Abstractions
{
    public interface IMapWriterAdapter<T>
    {
        IMapWriter<T> Writer { get; }
        T Write(int x, int y, object data);
    }
}
