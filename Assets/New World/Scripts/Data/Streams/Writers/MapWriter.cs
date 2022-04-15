using NewWorld.Data.Standard;
using NewWorld.Data.Streams.Writers.Abstractions;
using System;

namespace NewWorld.Data.Streams.Writers
{
    public class MapWriter : IMapWriter<ChunkData>
    {
        public Func<string, ChunkData, ChunkData> WriteMethod { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ChunkData Write(string path, ChunkData data)
        {
            throw new NotImplementedException();
        }
    }
}
