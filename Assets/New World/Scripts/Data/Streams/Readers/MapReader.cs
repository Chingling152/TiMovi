using System;
using UnityEngine;
using System.Collections.Generic;
using NewWorld.Data.Readers.Abstractions;

namespace NewWorld.Data.Streams.Readers
{
    public abstract class MapReader<T> : IMapReader<T>
    {
        /// <summary>
        /// Methods that will be executed to deserialize saved data
        /// </summary>
        public virtual Func<string, T> ReadMethod { get; set; }

        public virtual event Action<Vector2, Vector2> OnChunkLoad;
        public virtual event Action<Exception> OnChunkError;

        public abstract T Read(string path);
        public virtual IEnumerable<T> Read(params string[] path)
        {
            var length = path.Length;
            var chunks = new T[length];

            for (int i = 0; i < length; i++)
            {
                try
                {
                    chunks[i] = this.Read(path[i]);
                }
                catch (Exception e)
                {
                    this.OnChunkError?.Invoke(e);
                }
            }

            return chunks;
        }

        public virtual IEnumerator<T> ReadGenerator(params string[] path)
        {
            foreach (var item in path)
            {
                T chunk;
                try
                {
                    chunk = this.Read(item);
                }
                catch (Exception e)
                {
                    this.OnChunkError?.Invoke(e);
                    chunk = default;
                }

                yield return chunk;
            }

            yield return default;
        }
    }
}
