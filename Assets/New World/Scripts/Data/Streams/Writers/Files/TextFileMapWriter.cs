using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NewWorld.Data.Standard;
using NewWorld.Data.Streams.Writers.Abstractions;
using UnityEngine;

namespace NewWorld.Data.Streams.Writers.Files
{
    [Serializable]
    public class TextFileMapWriter : MapWriter<ChunkData>
    {
        [SerializeField]
        protected string basePath;

        [SerializeField]
        protected List<TileData> Tiles;//TODO: remove

        public TextFileMapWriter()
        {

        }

        public override ChunkData Write(string path, ChunkData data)
        {
            var fullPath = Path.Combine(basePath, path);
            ChunkData chunk;

            if (this.WriteMethod != null)
            {
                chunk = this.WriteMethod(fullPath,data);
            }
            else
            {
                chunk = data;

                var strBuilder = new StringBuilder();
                for (int x = 0; x < data.Size.x; x++)
                {
                    for (int y = 0; y < data.Size.y; y++)
                    {
                        var index = this.Tiles.IndexOf(chunk[x, y]);
                        if (index != -1)
                        {
                            strBuilder.Append(index);
                        }
                        else
                        {
                            throw new KeyNotFoundException($"Tile not recognized at {x}:{y}");
                        }
                    }
                }
            }

            return chunk;
        }
    }
}
