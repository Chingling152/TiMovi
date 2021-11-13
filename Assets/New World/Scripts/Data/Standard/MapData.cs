using UnityEngine;

namespace NewWorld.Scripts.Data.Standard
{
    public class MapData
    {
        public Vector2 MapSize { get ; protected set; }
        public Vector2 ChunkSize { get ; protected set; }

        public ChunkData[,] Chunks { get; protected set; }
    }
}
