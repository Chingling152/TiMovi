using NUnit.Framework;
using System;
using TheChest.Containers;
using TheChest.Items;

namespace TheWorld.Tests.TheChest
{
    public partial class SlotTests
    {
        public System.Random random;

        public SlotTests()
        {
            random = new System.Random();
        }

        private Item DefaultItemGenerator()
        {
            return new Item(
              id: Guid.NewGuid().ToString(),
              name: Guid.NewGuid().ToString(),
              description: Guid.NewGuid().ToString(),
              image: null,
              maxStack: random.Next(1,20)
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
