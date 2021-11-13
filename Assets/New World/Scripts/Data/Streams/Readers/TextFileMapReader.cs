using NewWorld.Scripts.Data.Standard;
using System.Collections.Generic;

namespace NewWorld.Scripts.Data.Streams.Readers
{
    public class TextFileMapReader : MapReader
    {
        private readonly string basePath;

        public TextFileMapReader(string basePath)
        {
            this.basePath = basePath;
        }

        public override IEnumerable<ChunkData> Read(params string[] paths)
        {
            var chunks = new ChunkData[paths.Length];
            foreach (var path in paths)
            {

            }

            return chunks;
        }

        public override IEnumerable<ChunkData> ReadAll(params string[] paths)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerator<ChunkData> ReadGenerator(params string[] paths)
        {
            foreach (var path in paths)
            {
                yield return new ChunkData();
            }

            yield return null;
        }

        public override IEnumerator<ChunkData> ReadGeneratorAll(params string[] paths)
        {
            foreach (var path in paths)
            {
                yield return new ChunkData();
            }

            yield return null;
        }
    }
}
