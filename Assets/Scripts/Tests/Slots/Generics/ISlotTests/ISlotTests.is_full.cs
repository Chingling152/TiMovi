using NUnit.Framework;

namespace TheChest.Tests.Slots.Generics
{
    public partial class ISlotTests
    {
        [Test]
        public void IsFull_CurentItemNull_ReturnsFalse()
        {
            var slot = this.slotFaker
                .WithoutItem()
                .Generate();
            Assert.That(slot.IsFull, Is.False);
        }

        [Test]
        public void IsFull_CurentItemNotNull_ReturnsTrue()
        {
            var slot = this.slotFaker
                .WithItem(itemFaker.Generate())
                .Generate();
            Assert.That(slot.IsFull, Is.True);
        }

        [Test]
        public void IsFull_SlotIsEmpty_ReturnsFalse()
        {
            var slot = this.slotFaker
                .WithoutItem()
                .Generate();

            Assert.That(slot.IsFull, Is.False);
            Assert.That(slot.IsFull, Is.Not.EqualTo(slot.IsEmpty));
        }
    }
}
