using NUnit.Framework;

namespace TheChest.Tests.Containers.Generics.IStackContainerTests
{
    public partial class IStackContainerTests
    {
        [Test]
        public void IsEmpty_EmptySlots_ReturnsTrue()
        {
            var container = this.containerFaker
                .Generate();
            Assert.That(container.IsEmpty, Is.True);
        }

        [Test]
        public void IsEmpty_SomeEmptySlots_ReturnsFalse()
        {
            var container = this.containerFaker
                .WithItemAt(1, itemFaker.Generate())
                .Generate();
            Assert.That(container.IsEmpty, Is.False);
        }

        [Test]
        public void IsEmpty_AllSlotsFull_ReturnsFalse()
        {
            var container = this.containerFaker
                .FullOfItems(itemFaker.Generate())
                .Generate();
            Assert.That(container.IsEmpty, Is.False);
        }
    }
}
