using System;
using UnityEngine;
using System.Collections.Generic;
using NewWorld.Data.Standard;
using NewWorld.Data.Readers.Abstractions;

namespace NewWorld.Data.Streams.Readers
{
    public abstract class MapReader : IMapReader<ChunkData>
    {
        public Func<string, ChunkData> ReadMethod { get; set; }

        public abstract event Action<Vector2, Vector2> OnChunkLoad;
        public abstract event Action<Exception> OnChunkError;

        public abstract ChunkData Read(string path);
        public abstract IEnumerable<ChunkData> Read(params string[] path);
        public abstract IEnumerator<ChunkData> ReadGenerator(params string[] path);
    }
}
