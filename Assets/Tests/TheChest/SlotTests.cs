using NUnit.Framework;
using System;
using TheChest.Containers;
using TheChest.Items;

namespace TheWorld.Tests.TheChest
{
    public partial class SlotTests
    {
        public System.Random random;

        const int low_amount = 10;
        const int high_amount = 20;

        public SlotTests()
        {
            random = new Random();

            Assert.IsTrue(low_amount < high_amount);
        }

        private Item DefaultItemGenerator()
        {
            return new Item(
              id: Guid.NewGuid().ToString(),
              name: Guid.NewGuid().ToString(),
              description: Guid.NewGuid().ToString(),
              image: null,
              maxStack: random.Next(1, high_amount)
           );
        }

        [Test]
        public void SlotConstrutorEmpty()
        {
            var slot = new Slot();
            Assert.IsTrue(slot.isEmpty);
            Assert.IsNull(slot.CurrentItem);
        }

        [Test]
        public void SlotConstrutorWithItem()
        {
            var item = new Item();
            var slot = new Slot(item);

            Assert.IsFalse(slot.isEmpty);
            Assert.IsNotNull(slot.CurrentItem);
            Assert.AreEqual(item, slot.CurrentItem);
        }
    }
}
