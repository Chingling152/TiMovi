using NUnit.Framework;
using System;

namespace TheChest.Tests.Containers.Generics.IStackContainerTests
{
    public partial class IStackContainerTests
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
            var randomSize = random.Next(10, 20);
			var randomSlot = random.Next(0, randomSize - 1);
			var container = this.containerFaker
				.WithSizeOf(randomSize)
				.FullOfItems(itemFaker.Generate())
				.WithNoItemAt(randomSlot)
				.Generate();

			Assert.That(container.IsFull, Is.False);
		}

        [Test]
        public void IsFull_OneSlotAlmostFull_ReturnsFalse()
        {
            var randomSize = random.Next(10, 20);
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
        public void IsFull_AllSlotsAlmostFull_ReturnsFalse()
        {
            var randomSize = random.Next(10, 20);
            var randomSlot = random.Next(0, randomSize - 1);
            var container = this.containerFaker
                .WithSizeOf(randomSize)
                .FullOfItems(itemFaker.Generate())
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
