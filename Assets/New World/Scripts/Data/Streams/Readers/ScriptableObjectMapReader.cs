using System;
using System.Collections.Generic;
using UnityEngine;

namespace NewWorld.Data.Streams.Readers.Files
{
    [Obsolete("Not Implemented",true)]
    public class ScriptableObjectMapReader<T> : MapReader<T> 
        where T : ScriptableObject
    {
        public override Func<string, T> ReadMethod { get ; set; }

        public override event Action<Vector2, Vector2> OnChunkLoad;
        public override event Action<Exception> OnChunkError;

        protected virtual T Deserialize(string path)
        {
            return default;
        } 

        public override T Read(string path)
        {
            T chunk;

            if (this.ReadMethod != null)
            {
                chunk = this.ReadMethod(path);
            }
            else
            {
                chunk = this.Deserialize(path);
            }

            return chunk;
        }
    }
}
