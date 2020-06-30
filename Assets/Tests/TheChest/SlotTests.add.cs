using NUnit.Framework;
using System;
using TheChest.Containers;
using TheChest.Items;

namespace TheWorld.Tests.TheChest
{
    public partial class SlotTests
    {
        [Test]
        public void ShouldAddItemOnEmptySlot()
        {
            var item = this.DefaultItemGenerator();

            var slot = new Slot();

            var result = slot.Add(item);

            Assert.IsTrue(result);//should IsTrue
            Assert.IsFalse(slot.isEmpty);//Should not be empty
            Assert.IsNotNull(slot.CurrentItem);//Should not be null
            Assert.AreSame(item, slot.CurrentItem);//Should be the item created
        }

        [Test]
        public void ShouldStackItemOnSlot()
        {
            var item = new Item(
               id: Guid.NewGuid().ToString(),
               name: Guid.NewGuid().ToString(),
               description: Guid.NewGuid().ToString(),
               image: null,
               maxStack: 2
            );

            var slot = new Slot(item);

            var result = slot.Add(item);

            Assert.IsTrue(result);//Should be true
            Assert.IsTrue(slot.isFull);//The inventory needs to be full

            Assert.AreEqual(item, slot.CurrentItem);//Should keep the currentItem
        }

        [Test]
        public void ShouldNotAddItemOnFullSlot()
        {
            var item = new Item(
               id: Guid.NewGuid().ToString(),
               name: Guid.NewGuid().ToString(),
               description: Guid.NewGuid().ToString(),
               image: null,
               maxStack: 1
           );

            var slot = new Slot(item);

            var result = slot.Add(item);

            Assert.IsFalse(result);//Should be false because the inventory is full
            Assert.IsTrue(slot.isFull);//The inventory needs to be full
        }

        [Test]
        public void ShouldNotAddItemOnSlotWithOtherItem()
        {
            var item = this.DefaultItemGenerator();
            var otherItem = this.DefaultItemGenerator();

            var slot = new Slot(otherItem);

            var result = slot.Add(item);

            Assert.IsFalse(result);//Should be false because cannot replace items
            Assert.AreEqual(otherItem, slot.CurrentItem);//Should keep the currentItem
        }

        [Test]
        public void ShouldAddAnAmountOfItemsOnSlot()
        {
            var amountAndStack = random.Next(1, 20);

            var item = new Item(
               id: Guid.NewGuid().ToString(),
               name: Guid.NewGuid().ToString(),
               description: Guid.NewGuid().ToString(),
               image: null,
               maxStack: amountAndStack
            );

            var slot = new Slot();

            var result = slot.Add(item, amountAndStack);

            Assert.AreEqual(0, result);//Should be true
           
            Assert.IsTrue(slot.isFull);//Verify if the inventory is full
        }

        [Test]
        public void ShouldReturnTheAmountThatCoudNotBeAdded_IfAmountIsBiggerThanSlotMaxStack()
        {
            var amount = random.Next(10, 20);
            var maxStack = random.Next(1, 9);

            var item = new Item(
               id: Guid.NewGuid().ToString(),
               name: Guid.NewGuid().ToString(),
               description: Guid.NewGuid().ToString(),
               image: null,
               maxStack: maxStack
            );

            var slot = new Slot();

            var result = slot.Add(item, amount);

            Assert.AreEqual(Math.Abs(maxStack-amount), result);//Should be true
        }
    }
}
