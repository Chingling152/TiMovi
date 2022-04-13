using System;

namespace NewWorld.Data.Streams.Writers.Abstractions
{
    public abstract class MapWriter<T> : IMapWriter<T>
    {
        public MapWriter()
        {

        }

        public virtual Func<string, T, T> WriteMethod { get; set; }

        public abstract T Write(string path, T data);
    }
}
