using System;
using TheChest.Items;
using TheChest.Containers;
using NUnit.Framework;

namespace TheWorld.Tests.TheChest
{
    public partial class SlotTests
    {
        [Test]
        public void OnAdd_ShouldAddItemOnEmptySlot()
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
        public void OnAdd_ShouldStackItemOnSlot()
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
        public void OnAdd_ShouldNotAddItemOnFullSlot()
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
        public void OnAdd_ShouldNotAddItemOnSlotWithOtherItem()
        {
            var item = this.DefaultItemGenerator();
            var otherItem = this.DefaultItemGenerator();

            var slot = new Slot(otherItem);

            var result = slot.Add(item);

            Assert.IsFalse(result);//Should be false because cannot replace items
            Assert.AreEqual(otherItem, slot.CurrentItem);//Should keep the currentItem
        }

        [Test]
        public void OnAddAmount_ShouldAddTheAmountOfItemsOnSlot()
        {
            var amountAndStack = random.Next(1, high_amount);

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
        public void OnAddAmount_ShouldReturnTheAmountThatCoudNotBeAdded()
        {
            var amount = random.Next(low_amount, high_amount);
            var maxStack = random.Next(1, low_amount - 1);

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
            Assert.IsTrue(slot.isFull);
        }

        [Test]
        public void OnAddAmount_ShouldStackItemsOnSlot()
        {
            var amount = random.Next(1, low_amount);
            var maxStack = amount * 2 + random.Next(0, low_amount / 2);

            var item = new Item(
               id: Guid.NewGuid().ToString(),
               name: Guid.NewGuid().ToString(),
               description: Guid.NewGuid().ToString(),
               image: null,
               maxStack: maxStack
            );

            var slot = new Slot(item, amount);

            var result = slot.Add(item, amount);

            Assert.Zero(result);
            Assert.AreEqual(slot.StackAmount, amount * 2);
        }
    }
}
