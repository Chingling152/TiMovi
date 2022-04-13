using System;
using UnityEngine;

namespace NewWorld.Data.Standard
{
    [Serializable]
    public class ChunkData
    {
        public int X;
        public int Y;
        public Vector2 Position => new Vector2(X, Y);
        public Vector2 Size => new Vector2(Tiles.GetLength(1), Tiles.GetLength(0));

        //TODO: multilayers (instances, objects, tiles, etc..)
        public TileData[,] Tiles;

        public TileData this[int x,int y]
        {
            get
            {
                return this.Tiles[x,y];
            }

            set
            {
                this.Tiles[x,y] = value;
            }
        }
    }
}
