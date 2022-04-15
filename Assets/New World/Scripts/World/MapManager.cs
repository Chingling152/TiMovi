using UnityEngine;
using NewWorld.World.Adapters;
using NewWorld.World.Generics;

namespace NewWorld.World
{
    public class MapManager : MonoBehaviour, IMapManager
    {
        [SerializeField]
        protected MapAdapter adapter;
    }
}
