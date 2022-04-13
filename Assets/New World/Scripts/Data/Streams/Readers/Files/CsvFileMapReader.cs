using System;
using System.Collections.Generic;
using UnityEngine;
using NewWorld.Data.Standard;
using NewWorld.Data.Streams.Readers.Abstractions;

namespace NewWorld.Data.Streams.Readers.Files
{
    [Obsolete("Not Implemented", true)]
    public class CsvFileMapReader : MapReader<ChunkData>
    {
        [SerializeField]
        protected string basePath;

        [SerializeField]
        protected List<TileData> Tiles;//TODO: remove

        public override event Action<Vector2, Vector2> OnChunkLoad;
        public override event Action<Exception> OnChunkError;

        public CsvFileMapReader()
        {

        }

        public override ChunkData Read(string path)
        {
            throw new NotImplementedException();
        }
    }
}
