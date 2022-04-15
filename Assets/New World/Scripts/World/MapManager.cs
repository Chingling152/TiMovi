using UnityEngine;
using NewWorld.Data.Adapters;
using NewWorld.World.Generics;

namespace NewWorld.World
{
    public class MapManager : MonoBehaviour, IMapManager
    {
        [SerializeField]
        protected MapAdapter adapter;
    }
}
