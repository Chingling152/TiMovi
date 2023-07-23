using NUnit.Framework;

namespace TheChest.Tests.Slots.Generics
{
    public partial class ISlotTests
    {
        [Test]
        public void IsEmpty_CurentItemNull_ReturnsTrue()
        {
            var slot = this.slotFaker
                .WithoutItem()
                .Generate();
            Assert.That(slot.IsEmpty, Is.True);
        }

        [Test]
        public void IsEmpty_CurentItemNotNull_ReturnsFalse()
        {
            var slot = this.slotFaker
                .WithItem(itemFaker.Generate())
                .Generate();
            Assert.That(slot.IsEmpty, Is.False);
        }

        [Test]
        public void IsEmpty_SlotIsFull_ReturnsFalse()
        {
            var slot = this.slotFaker
                .WithItem(itemFaker.Generate())
                .Generate();

            Assert.That(slot.IsEmpty, Is.False);
            Assert.That(slot.IsEmpty, Is.Not.EqualTo(slot.IsFull));
        }
    }
}
