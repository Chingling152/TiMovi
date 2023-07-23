using NUnit.Framework;

namespace TheChest.Tests.Slots.Generics
{
    public partial class StackSlotTests
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
        public void IsFull_CurentItemInHalfMaxStack_ReturnsFalse()
        {
            var maxStack = random.Next(5,20);

            var container = this.slotFaker
                .WithMaxAmount(maxStack)
                .WithItem(itemFaker.Generate(), maxStack / 2)
                .Generate();

            Assert.That(container.IsFull, Is.False);
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

        [Test]
        public void IsFull_CurentItemInMaxStack_ReturnsTrue()
        {
            var maxStack = random.Next(5, 20);

            var container = this.slotFaker
                .WithMaxAmount(maxStack)
                .WithItem(itemFaker.Generate(), maxStack)
                .Generate();

            Assert.That(container.IsFull, Is.True);
        }
    }
}
