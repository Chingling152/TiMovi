using NUnit.Framework;
using System;

namespace TheChest.Tests.Containers.Generics.IContainerTests
{
    public partial class IContainerTests
    {
        [Test]
        public void Index_ValidIndex_ReturnsSlotItemFromIndex()
        {
            var randomSize = random.Next(10, 20);
            var container = this.containerFaker
                .FullOfItems(this.itemFaker.Generate(randomSize).ToArray())
                .Generate();

            var randomIndex = random.Next(0, randomSize - 1);
            Assert.That(container[randomIndex], Is.EqualTo(container.Slots[randomIndex]));
        }

        [TestCase(-1)]
        [TestCase(21)]
        public void Index_InvalidIndex_ThrowsIndexOutOfRangeException(int index)
        {
            var randomSize = random.Next(10, 20);
            var container = this.containerFaker
                .FullOfItems(this.itemFaker.Generate(randomSize).ToArray())
                .Generate();

            Assert.That(
                () => container[index], 
                Throws.Exception.With.TypeOf(typeof(IndexOutOfRangeException))
                .And.Message.StartsWith("Index was outside the bounds of the array")
            );
        }
    }
}
