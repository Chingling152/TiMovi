using System;
using UnityEngine;
using System.Collections.Generic;

namespace NewWorld.Data.Streams.Readers.Abstractions
{
    /// <summary>
    /// Interface responsible to deserialize any Map data to a class
    /// </summary>
    /// <typeparam name="T">Type returned after read data</typeparam>
    public interface IMapReader<T>
    {
        /// <summary>
        /// Methods that will be executed to deserialize saved data
        /// </summary>
        [Obsolete("Inherit the interface IMapReader<T>")]
        Func<string, T> ReadMethod { get ; set ;}

        /// <summary>
        /// Event that notifies a Chunk created (position and Size data)
        /// </summary>
        event Action<Vector2, Vector2> OnChunkLoad;//TODO: maybe create a ChunkLoadEventArgs
        /// <summary>
        /// Event that notifies an error to load a chunk
        /// </summary>
        event Action<Exception> OnChunkError;//TODO: maybe create a ChunkErrorEventArgs

        //Y Read<Y>(string path);

        /// <summary>
        /// Reads map data
        /// </summary>
        /// <param name="path">Anything that indicates what should be read</param>
        /// <returns>A Standardized object based on the readed file</returns>
        T Read(string path);        
        /// <summary>
        /// Reads one or more map data 
        /// </summary>
        /// <param name="paths">Paths do access all the map data</param>
        /// <returns>A list with all <paramref name="paths"/> converted to <see cref="T"/></returns>
        IEnumerable<T> Read(params string[] paths);
        /// <summary>
        /// Reads one or more map data and returning using yield 
        /// </summary>
        /// <param name="paths">Paths do access all the map data</param>
        /// <returns>A list with all <paramref name="paths"/> converted to <see cref="T"/></returns>
        IEnumerator<T> ReadGenerator(params string[] paths);
    }
}
