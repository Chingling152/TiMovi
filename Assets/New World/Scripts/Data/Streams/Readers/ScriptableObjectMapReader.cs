using System;
using UnityEngine;
using System.Collections.Generic;
using NewWorld.Data.Readers.Abstractions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NewWorld.Data.Streams.Readers
{
    public class ScriptableObjectMapReader<T> : IMapReader<T> 
        where T : ScriptableObject
    {
        private readonly string basePath;

        public ScriptableObjectMapReader(string basePath)
        {
            this.basePath = basePath;
        }

        public Func<string, T> ReadMethod { get ; set; }

        public event Action<Vector2, Vector2> OnChunkLoad;
        public event Action<Exception> OnChunkError;

        public virtual T Deserialize(string path)
        {
            byte[] bytes = File.ReadAllBytes(path);
            using(MemoryStream stream = new MemoryStream(bytes))
            {
                BinaryFormatter deserializer = new BinaryFormatter();
                return deserializer.Deserialize(stream) as T;
            }            
        }

        public virtual T Read(string path)
        {
            var fullPath = Path.Combine(basePath, path);
            T chunk;

            if (this.ReadMethod != null)
            {
                chunk = this.ReadMethod(fullPath);
            }
            else
            {
                chunk = this.Deserialize(path);
            }

            return chunk;
        }
    }
}
