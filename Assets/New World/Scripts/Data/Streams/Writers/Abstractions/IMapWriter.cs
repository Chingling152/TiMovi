using System;

namespace NewWorld.Data.Streams.Writers.Abstractions
{
    public interface IMapWriter<T>
    {

        Func<string,T, T> WriteMethod { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        T Write(string path, T data);
    }
}
