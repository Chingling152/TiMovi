using NUnit.Framework;

namespace TheChest.Tests.Slots.Generics
{
    public partial class ISlotTests
    {
        [Test]
        public void IsEmpty_CurentItemNull_ReturnsTrue()
        {
            var container = this.slotFaker
                .WithoutItem()
                .Generate();
            Assert.That(container.IsEmpty, Is.True);
        }

        [Test]
        public void IsEmpty_CurentItemNotNull_ReturnsFalse()
        {
            var container = this.slotFaker
                .WithItem(itemFaker.Generate())
                .Generate();
            Assert.That(container.IsEmpty, Is.False);
        }

        [Test]
        public void IsEmpty_SlotIsFull_ReturnsFalse()
        {
            var container = this.slotFaker
                .WithItem(itemFaker.Generate())
                .Generate();

            Assert.That(container.IsEmpty, Is.False);
            Assert.That(container.IsEmpty, Is.Not.EqualTo(container.IsFull));
        }
    }
}
