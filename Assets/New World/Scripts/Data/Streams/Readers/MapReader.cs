using System;
using System.Collections.Generic;
using UnityEngine;
using NewWorld.Data.Standard;
using NewWorld.Data.Streams.Readers.Abstractions;

namespace NewWorld.Data.Streams.Readers
{
    public class MapReader : IMapReader<ChunkData>
    {
        public Func<string, ChunkData> ReadMethod { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event Action<Vector2, Vector2> OnChunkLoad;
        public event Action<Exception> OnChunkError;

        public ChunkData Read(string path)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ChunkData> Read(params string[] paths)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ChunkData> ReadGenerator(params string[] paths)
        {
            throw new NotImplementedException();
        }
    }
}
