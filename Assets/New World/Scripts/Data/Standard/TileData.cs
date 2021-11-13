using UnityEngine;

namespace NewWorld.Scripts.Data.Standard
{
    public class TileData
    {
        public string Name { get; protected set; }
        public Sprite Sprite { get; protected set; }
        public double Cost { get; protected set; }
        public bool IsWalkable { get; protected set; }
        public bool IsOcuppied { get; protected set; }
    }
}
