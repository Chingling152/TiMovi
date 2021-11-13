using System.Collections.Generic;

namespace NewWorld.Scripts.Data.Readers.Abstractions
{
    public interface IMapReader<T>
    {
        IEnumerable<T> ReadAll(params string[] paths);
        IEnumerable<T> Read(params string[] paths);

        IEnumerator<T> ReadGeneratorAll(params string[] paths);
        IEnumerator<T> ReadGenerator(params string[] paths);
    }
}
