using NewWorld.Data.Standard;
using NewWorld.Data.Streams.Readers;
using NewWorld.Data.Streams.Readers.Abstractions;
using NewWorld.Data.Streams.Writers;
using NewWorld.Data.Streams.Writers.Abstractions;
using NewWorld.World.Adapters.Abstractions;
using System;
using UnityEngine;

namespace NewWorld.Data.Adapters
{
    [Serializable]
    public class MapAdapter : IMapAdapter<ChunkData>
    {
        [SerializeField]
        protected bool isReadOnly;
        public bool IsReadOnly => this.isReadOnly;

        [SerializeField]
        protected MapReader reader;
        public IMapReader<ChunkData> Reader => this.reader;

        [SerializeField]
        protected MapWriter writer;
        public IMapWriter<ChunkData> Writer => this.writer;

        public ChunkData Read(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        public ChunkData Write(int x, int y, object data)
        {
            throw new System.NotImplementedException();
        }
    }
}
