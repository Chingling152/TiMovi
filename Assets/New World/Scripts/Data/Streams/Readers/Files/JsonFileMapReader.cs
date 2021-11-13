using System;
using UnityEngine;
using System.Collections.Generic;
namespace NewWorld.Data.Streams.Readers.Files
{
    [System.Obsolete("Not Implemented", true)]
    public class JsonFileMapReader<T> : MapReader<T>
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
