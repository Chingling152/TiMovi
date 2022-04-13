using System;
using UnityEngine;

namespace NewWorld.Data.Standard
{
    [Serializable]
    public class MapData
    {
        public Vector2 MapSize;
        public Vector2 ChunkSize;

        public ChunkData[,] Chunks;
    }
}
