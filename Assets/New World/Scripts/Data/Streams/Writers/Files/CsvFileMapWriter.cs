using System;
using NewWorld.Data.Standard;
using NewWorld.Data.Streams.Writers.Abstractions;

namespace NewWorld.Data.Streams.Writers.Files
{
    [Obsolete("Not Implemented", true)]
    public class CsvFileMapWriter : MapWriter<ChunkData>
    {
        public override ChunkData Write(string path, ChunkData data)
        {
            throw new NotImplementedException();
        }
    }
}
