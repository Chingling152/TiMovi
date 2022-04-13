using NewWorld.Data.Streams.Writers.Abstractions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace NewWorld.Data.Streams.Writers.Files
{
    public class SerializableMapWriter<T> : MapWriter<T>
        where T : class
    {
        [SerializeField]
        protected string basePath;

        public SerializableMapWriter()
        {

        }

        protected T Serialize(string path, T data)
        {
            using(var memoryStream = new MemoryStream())
            {
                var fullPath = Path.Combine(basePath, path);

                var serializer = new BinaryFormatter();
                serializer.Serialize(memoryStream, data);
                File.WriteAllBytes(fullPath, memoryStream.ToArray());
            }
            return data;
        }

        public override T Write(string path, T data)
        {
            T chunk;

            if (this.WriteMethod != null)
            {
                var fullPath = Path.Combine(basePath, path);
                chunk = this.WriteMethod(fullPath, data);
            }
            else
            {
                chunk = this.Serialize(path, data);
            }

            return chunk;
        }
    }
}
