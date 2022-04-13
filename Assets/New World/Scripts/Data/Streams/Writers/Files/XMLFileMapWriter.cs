using System;
using NewWorld.Data.Streams.Writers.Abstractions;

namespace NewWorld.Data.Streams.Writers.Files
{
    [Obsolete("Not Implemented", true)]
    public class XMLFileMapWriter<T> : MapWriter<T>
    {
        public override T Write(string path, T data)
        {
            throw new System.NotImplementedException();
        }
    }
}
