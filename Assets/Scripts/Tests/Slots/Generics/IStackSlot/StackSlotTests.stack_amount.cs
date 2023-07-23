using NUnit.Framework;
using System;

namespace TheChest.Tests.Slots.Generics
{
    public partial class StackSlotTests
    {
        [Test]
        public void StackAmount_SmallerThanZero_ThrowsException()
        {
            Assert.That(
                () => this.slotFaker.WithItem(itemFaker.Generate(), -1).Generate(),
                Throws.Exception
                    .With.TypeOf(typeof(ArgumentOutOfRangeException))
                    .And.Message.StartsWith("The amount property cannot be smaller than zero")
            );
        }

        [Test]
        public void StackAmount_BiggerThanMaxAmount_ThrowsException()
        {
            var maxAmount = random.Next(10,20);
            Assert.That(
                () => 
                    this.slotFaker
                        .WithMaxAmount(maxAmount)
                        .WithItem(itemFaker.Generate(), maxAmount + 1)
                        .Generate(),
                Throws.Exception
                    .With.TypeOf(typeof(ArgumentOutOfRangeException))
                    .And.Message.StartsWith("The amount property cannot be bigger than maxAmount")
            );
        }
    }
}
