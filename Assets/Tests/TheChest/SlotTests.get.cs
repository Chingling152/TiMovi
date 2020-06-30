using NUnit.Framework;
using System;
using TheChest.Containers;
using TheChest.Items;

namespace TheWorld.Tests.TheChest
{
    public partial class SlotTests
    {
        [Test]
        public void ShouldReturnItemFromSlot()
        {
            var item = new Item(
              id: Guid.NewGuid().ToString(),
              name: Guid.NewGuid().ToString(),
              description: Guid.NewGuid().ToString(),
              image: null,
              maxStack: 1
           );

            var slot = new Slot(item);

            var resultItem = slot.GetOne();

            Assert.AreEqual(item,resultItem);
            Assert.IsTrue(slot.isEmpty);
            Assert.IsNull(slot.CurrentItem);
        }

        [Test]
        public void ShouldReturnAllItemsFromSlot()
        {
            var stackAmount = random.Next(2, 20);

            var item = new Item(
              id: Guid.NewGuid().ToString(),
              name: Guid.NewGuid().ToString(),
              description: Guid.NewGuid().ToString(),
              image: null,
              maxStack: stackAmount
           );

            var slot = new Slot();
            slot.Add(item, stackAmount);

            var resultItem = slot.GetAll();

            Assert.AreEqual(stackAmount, resultItem.Length);
            Assert.IsTrue(slot.isEmpty);
            Assert.IsNull(slot.CurrentItem);
        }

        [Test]
        public void ShouldReturnAnAmountFromSlot()
        {
            var slot = new Slot();
        }

        [Test]
        public void ShouldReturnTheMaxItemsFromInventory()
        {

        }
    }
}
