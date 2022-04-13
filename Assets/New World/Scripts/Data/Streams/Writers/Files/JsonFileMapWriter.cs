using Newtonsoft.Json;
using NewWorld.Data.Streams.Writers.Abstractions;
using System.IO;
using UnityEngine;

namespace NewWorld.Data.Streams.Writers.Files
{
    public class JsonFileMapWriter<T> : MapWriter<T>
    {
        [SerializeField]
        protected string basePath;

        public JsonFileMapWriter()
        {

        }

        protected T Serialize(string path, T data)
        {
            var fullPath = Path.Combine(basePath,path);

            var serializedData = JsonConvert.SerializeObject(data);
            File.WriteAllText(fullPath,serializedData);

            return JsonConvert.DeserializeObject<T>(fullPath);
        }

        public override T Write(string path, T data)
        {
            T chunk;

            if (this.WriteMethod != null)
            {
                chunk = this.WriteMethod(path, data);
            }
            else
            {
                chunk = this.Serialize(path,data);
            }

            return chunk;
        }
    }
}
