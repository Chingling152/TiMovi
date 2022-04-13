using NewWorld.Data.Streams.Readers.Abstractions;
using System;

namespace NewWorld.Data.Streams.Readers.Files
{
    [Obsolete("Not Implemented", true)]
    public class XMLFileMapReader<T> : MapReader<T>
    {
        public override T Read(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}
