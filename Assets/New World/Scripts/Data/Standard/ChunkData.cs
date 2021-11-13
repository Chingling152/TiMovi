using UnityEngine;

namespace NewWorld.Data.Standard
{
    public class ChunkData
    {
        public int X;
        public int Y;
        public Vector2 Position => new Vector2(X, Y);
        public Vector2 Size => new Vector2(Tiles.GetLength(1), Tiles.GetLength(0));

        public TileData[,] Tiles;
        //TODO: multilayers (instances, objects, tiles, etc..)
    }
}
