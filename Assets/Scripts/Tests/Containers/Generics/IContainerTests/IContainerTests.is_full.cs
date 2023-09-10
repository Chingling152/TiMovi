using NUnit.Framework;

namespace TheChest.Tests.Containers.Generics.IContainerTests
{
    public partial class IContainerTests
    {
        [Test]
        public void IsFull_EmptySlots_ReturnsFalse() 
        {
            var container = this.containerFaker.Generate();

            Assert.That(container.IsFull, Is.False);
        }

        [Test]
        public void IsFull_OneEmptySlot_ReturnsFalse()
        {
            var randomSize = random.Next(10,20);
            var randomSlot = random.Next(0, randomSize - 1);
            var container = this.containerFaker
                .WithSizeOf(randomSize)
                .FullOfItems(itemFaker.Generate())
                .WithNoItemAt(randomSlot)
                .Generate();

            Assert.That(container.IsFull, Is.False);
        }

        [Test]
        public void IsFull_OneFullSlot_ReturnsFalse()
        {
            var randomSize = random.Next(10, 20);
            var randomSlot = random.Next(0, randomSize - 1);
            var container = this.containerFaker
                .WithSizeOf(randomSize)
                .WithItemAt(randomSlot, itemFaker.Generate())
                .Generate();

            Assert.That(container.IsFull, Is.False);
        }

        [Test]
        public void IsFull_AllSlotsFull_ReturnsTrue()
        {
            var container = this.containerFaker
                .FullOfItems(itemFaker.Generate())
                .Generate();

            Assert.That(container.IsFull, Is.True);
        }
    }
}
