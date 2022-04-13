using System;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NewWorld.Data.Streams.Readers.Files
{
    [Serializable]
    public class SerializableMapReader<T> : MapReader<T> 
        where T : class
    {
        [SerializeField]
        protected string basePath;

        public SerializableMapReader()
        {

        }

        public override event Action<Vector2, Vector2> OnChunkLoad;
        public override event Action<Exception> OnChunkError;

        protected T Deserialize(string path)
        {
            byte[] bytes = File.ReadAllBytes(path);
            using (var stream = new MemoryStream(bytes))
            {
                var deserializer = new BinaryFormatter();
                return deserializer.Deserialize(stream) as T;
            }
        }

        public override T Read(string path)
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
