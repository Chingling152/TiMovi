using NUnit.Framework;
using System;
using System.Linq;
using TheChest.Containers;
using TheChest.Items;

namespace TheWorld.Tests.TheChest
{
    public partial class InventoryTests
    {
        #region Index
        [Test]
        public void Get_from_index__Should_return_Item()
        {
            var amount = random.Next(low_amount,high_amount);
            var slots = Enumerable.Repeat(this.DefaultSlotGenerator(false, amount), high_size).ToArray();

            var inventory = new Inventory(slots);
            var slotIndex = random.Next(0, high_size);

            var result = inventory.GetItem(slotIndex);

            Assert.IsNotNull(result);
        }

        [Test]
        public void Get_from_index__Wrong_index_should_return_null()
        {
            var amount = random.Next(low_amount, high_amount);
            var slots = Enumerable.Repeat(this.DefaultSlotGenerator(false, amount), high_size).ToArray();

            var inventory = new Inventory(slots);

            var slotIndex = -1;

            var result = inventory.GetItem(slotIndex);

            Assert.IsNull(result);
        }

        [Test]
        public void Get_from_empty_index__Should_return_null()
        {
            var slots = Enumerable.Repeat(this.DefaultSlotGenerator(), high_size).ToArray();

            var inventory = new Inventory(slots);

            var result = inventory.GetItem(random.Next(0,high_size));

            Assert.IsNull(result);
        }
        #endregion

        #region item

        [Test]
        public void Get_Item__should_return_Item()
        {
            var slots = Enumerable.Repeat(this.DefaultSlotGenerator(false), high_size).ToArray();

            var item = new Item(
              id: Guid.NewGuid().ToString(),
              name: Guid.NewGuid().ToString(),
              description: Guid.NewGuid().ToString(),
              image: null,
              maxStack: random.Next(1, high_amount)
           );

            slots[random.Next(0, slots.Length)] = new Slot(item);

            var inventory = new Inventory(slots);

            var result = inventory.GetItem(item);

            Assert.AreEqual(item,result);
        }

        [Test]
        public void Get_Item__Wrong_item_should_return_null()
        {
            var slots = Enumerable.Repeat(this.DefaultSlotGenerator(true), high_size).ToArray();

            var item = new Item(
              id: Guid.NewGuid().ToString() + "2",
              name: Guid.NewGuid().ToString(),
              description: Guid.NewGuid().ToString(),
              image: null,
              maxStack: random.Next(1, high_amount)
           );

            var inventory = new Inventory(slots);

            var result = inventory.GetItem(item);

            Assert.IsNull(result);
            Assert.AreNotEqual(item, result);
        }

        [Test]
        public void Get_Item__null_should_return_null()
        {
            var slots = Enumerable.Repeat(this.DefaultSlotGenerator(true), high_size).ToArray();

            var inventory = new Inventory(slots);

            var result = inventory.GetItem(null);

            Assert.IsNull(result);
        }
        #endregion

    }
}
