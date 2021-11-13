using System;
using UnityEngine;
using System.Collections.Generic;
using NewWorld.Scripts.Data.Standard;
using NewWorld.Scripts.Data.Readers.Abstractions;

namespace NewWorld.Scripts.Data.Streams.Readers
{
    public abstract class MapReader : IMapReader<ChunkData>
    {
        public bool NotifyEvents { get ; set;}

        public event Action<Vector2, Vector2> OnChunkLoad;
        public event Action<Exception> OnChunkError;

        public abstract IEnumerable<ChunkData> Read(params string[] path);
        public abstract IEnumerable<ChunkData> ReadAll(params string[] path);
        public abstract IEnumerator<ChunkData> ReadGenerator(params string[] path);
        public abstract IEnumerator<ChunkData> ReadGeneratorAll(params string[] path);
    }
}
