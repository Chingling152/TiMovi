using NUnit.Framework;
using System;
using TheChest.Containers;
using TheChest.Items;
using UnityEngine;

namespace Tests.TheChest
{
    public partial class SlotTests
    {


        // adciona se : 
        // tiver vazio
        // tiver o mesmo item dentro do slot e naõ tiver cheio
        // tiver replace = true

        // não adciona se
        // estiver cheio (sem replace)
        // estiver com outro objeto (sem replace)
        [Test]
        public void ShouldAddItemOnEmptySlot()
        {
            var item = new Item(
                id: Guid.NewGuid().ToString(),
                name: Guid.NewGuid().ToString(),
                description: Guid.NewGuid().ToString(),
                image: null,
                maxStack: 1
            );

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

        /// <summary>
        /// This test is for verify if the slot can
        /// </summary>
        [Test]
        public void ShouldStackItemOnSlotUntilIsFull()
        { 
            var maxStack = random.Next(2, 20);

            var item = new Item(
               id: Guid.NewGuid().ToString(),
               name: Guid.NewGuid().ToString(),
               description: Guid.NewGuid().ToString(),
               image: null,
               maxStack: maxStack
            );

            var slot = new Slot();

            for (int i = 0; i < maxStack; i++)
            {
                var result = slot.Add(item);
                Assert.IsTrue(result);//Should be true
            }

            Assert.IsTrue(slot.isFull);//Verify if the inventory is full
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
            var item = new Item(
               id: Guid.NewGuid().ToString(),
               name: Guid.NewGuid().ToString(),
               description: Guid.NewGuid().ToString(),
               image: null,
               maxStack: random.Next(2, 20)
           );

            var otherItem = new Item(
               id: Guid.NewGuid().ToString(),
               name: Guid.NewGuid().ToString(),
               description: Guid.NewGuid().ToString(),
               image: null,
               maxStack: random.Next(2, 20)
            );

            var slot = new Slot(otherItem);

            var result = slot.Add(item);

            Assert.IsFalse(result);//Should be false because cannot replace items
            Assert.AreEqual(otherItem, slot.CurrentItem);//Should keep the currentItem
        }
    }
}
