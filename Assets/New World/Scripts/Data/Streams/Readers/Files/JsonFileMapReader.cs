using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using NewWorld.Data.Streams.Readers.Abstractions;

namespace NewWorld.Data.Streams.Readers.Files
{
    public class JsonFileMapReader<T> : MapReader<T>
    {
        [SerializeField]
        protected string basePath; 
        
        public override event Action<Vector2, Vector2> OnChunkLoad;
        public override event Action<Exception> OnChunkError;

        public JsonFileMapReader()
        {

        }

        private T Deserialize(string path)
        {
            return JsonConvert.DeserializeObject<T>(path);
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
                chunk = this.Deserialize(fullPath);
            }

            return chunk;
        }
    }
}
