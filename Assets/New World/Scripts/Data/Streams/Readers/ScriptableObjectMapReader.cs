using System;
using UnityEngine;
using System.Collections.Generic;
using NewWorld.Data.Readers.Abstractions;

namespace NewWorld.Data.Streams.Readers
{
    public class ScriptableObjectMapReader<T> : IMapReader<T> where T : ScriptableObject
    {
        public ScriptableObjectMapReader()
        {

        }

        public Func<string, T> ReadMethod { get ; set; }

        public event Action<Vector2, Vector2> OnChunkLoad;
        public event Action<Exception> OnChunkError;

        public T Read(string path)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Read(params string[] paths)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> ReadGenerator(params string[] paths)
        {
            throw new NotImplementedException();
        }
    }
}
