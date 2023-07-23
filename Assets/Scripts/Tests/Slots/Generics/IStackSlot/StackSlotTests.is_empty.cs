using NUnit.Framework;

namespace TheChest.Tests.Slots.Generics
{
    public partial class StackSlotTests
    {
        [Test]
        public void IsEmpty_StackAmountZero_ReturnsTrue()
        {
            var container = this.slotFaker
                .WithItem(itemFaker.Generate(), 0)
                .Generate();
            Assert.That(container.IsEmpty, Is.True);
        }

        [Test]
        public void IsEmpty_CurrentItemNull_ReturnsTrue()
        {
            var container = this.slotFaker
                .WithoutItem()
                .Generate();
            Assert.That(container.IsEmpty, Is.True);
        }

        [Test]
        public void IsEmpty_CurrentItemNotNull_ReturnsFalse()
        {
            var container = this.slotFaker
                .WithItem(itemFaker.Generate())
                .Generate();
            Assert.That(container.IsEmpty, Is.False);
        }
    }
}
