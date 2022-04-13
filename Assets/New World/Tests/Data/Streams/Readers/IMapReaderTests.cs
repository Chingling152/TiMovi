using NewWorld.Data.Readers.Abstractions;
using NUnit.Framework;
using System;

namespace NewWorld.Tests.Data.Streams.Readers
{
    public abstract class IMapReaderTests<T>
    {
        protected IMapReader<T> reader;
        protected Random random;

        public IMapReaderTests()
        {
            this.random = new Random();
        }

        [SetUp]
        public abstract void SetUp();

        [TearDown]
        public abstract void TearDown();
    }

}