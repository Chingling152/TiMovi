using UnityEngine;
using NewWorld.Data.Streams.Readers.Abstractions;
using NewWorld.Data.Streams.Writers.Abstractions;

namespace NewWorld.Data.Adapters.Abstractions
{
    public abstract class MapAdapter<T> : IMapAdapter<T>
    {
        [SerializeField]
        protected bool isReadOnly;
        public virtual bool IsReadOnly => this.isReadOnly;

        public abstract IMapReader<T> Reader { get ; }
        public abstract IMapWriter<T> Writer { get; }

        public abstract T Read(int x, int y);

        public abstract T Write(int x, int y, object data);
    }
}
