using System;
using UnityEngine;
using System.Collections.Generic;
using NewWorld.Data.Readers.Abstractions;

namespace NewWorld.Data.Streams.Readers
{
    [System.Obsolete]
    public abstract class MapReader<T> : IMapReader<T>
    {
        public Func<string, T> ReadMethod { get; set; }

        public abstract event Action<Vector2, Vector2> OnChunkLoad;
        public abstract event Action<Exception> OnChunkError;

        public abstract T Read(string path);
        public abstract IEnumerable<T> Read(params string[] path);
        public abstract IEnumerator<T> ReadGenerator(params string[] path);
    }
}
