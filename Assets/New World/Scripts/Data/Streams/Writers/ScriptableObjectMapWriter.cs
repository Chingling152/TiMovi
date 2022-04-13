using System;
using UnityEngine;
using NewWorld.Data.Streams.Writers.Abstractions;

namespace NewWorld.Data.Streams.Writers
{
    [Obsolete("Not Implemented", true)]
    public class ScriptableObjectMapWriter<T> : MapWriter<T>
        where T : ScriptableObject
    {
        public ScriptableObjectMapWriter()
        {

        }

        public override T Write(string path, T data)
        {
            throw new System.NotImplementedException();
        }
    }
}
