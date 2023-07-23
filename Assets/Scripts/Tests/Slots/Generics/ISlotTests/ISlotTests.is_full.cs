using NUnit.Framework;

namespace TheChest.Tests.Slots.Generics
{
    public partial class ISlotTests
    {
        [Test]
        public void IsFull_CurentItemNull_ReturnsFalse()
        {
            var container = this.slotFaker
                .WithoutItem()
                .Generate();
            Assert.That(container.IsFull, Is.False);
        }

        [Test]
        public void IsFull_CurentItemNotNull_ReturnsTrue()
        {
            var container = this.slotFaker
                .WithItem(itemFaker.Generate())
                .Generate();
            Assert.That(container.IsFull, Is.True);
        }

        [Test]
        public void IsFull_SlotIsEmpty_ReturnsFalse()
        {
            var container = this.slotFaker
                .WithoutItem()
                .Generate();

            Assert.That(container.IsFull, Is.False);
            Assert.That(container.IsFull, Is.Not.EqualTo(container.IsEmpty));
        }
    }
}
