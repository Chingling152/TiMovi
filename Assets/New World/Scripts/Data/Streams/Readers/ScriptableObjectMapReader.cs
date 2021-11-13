using System;
using UnityEngine;

namespace NewWorld.Data.Streams.Readers
{
    public class ScriptableObjectMapReader<T> : MapReader<T> where T : ScriptableObject
    {
        public override Func<string, T> ReadMethod { get ; set; }

        public override event Action<Vector2, Vector2> OnChunkLoad;
        public override event Action<Exception> OnChunkError;

        public override T Read(string path)
        {
            throw new NotImplementedException();
        }
    }
}
