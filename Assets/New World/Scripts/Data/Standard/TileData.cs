using System;
using UnityEngine;

namespace NewWorld.Data.Standard
{
    [Serializable]
    public class TileData
    {
        public string Name;
        public Sprite Sprite;
        public double Cost;
        public bool IsWalkable;
        public bool IsOcuppied;

        public int X;
        public int Y;
        public Vector2 Position => new Vector2(X,Y);
    }
}
