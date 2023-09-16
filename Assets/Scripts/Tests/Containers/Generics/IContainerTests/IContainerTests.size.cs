using NUnit.Framework;
using System;

namespace TheChest.Tests.Containers.Generics.IContainerTests
{
    public partial class IContainerTests
    {
        [Test]
        public void Size_NoInitialValue_SetsSizeToTwenty()
        {
            var container = this.containerFaker.Generate();

            Assert.That(container.Size, Is.EqualTo(20));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void Size_InitialValueInvalid_Throws(int size)
        {
            Assert.That(
                () => this.containerFaker.WithSizeOf(size).Generate(size),
                Throws.Exception.With.TypeOf(typeof(ArgumentOutOfRangeException))
                .And.Message.StartsWith("Invalid Container Size : 20")
            );
        }

        [Test]
        public void Size_ReturnsSlotsLength()
        {
            var container = this.containerFaker.Generate();

            Assert.That(container.Size, Is.EqualTo(container.Slots.Length));
        }

        [Test]
        public void Size_NullSlots_ReturnsZero()
        {
            var container = this.containerFaker
                .WithSizeOf(0)
                .Generate();

            Assert.That(container.Size, Is.EqualTo(0));
        }
    }
}
