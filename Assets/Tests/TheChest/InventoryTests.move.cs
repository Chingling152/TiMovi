﻿using NUnit.Framework;
using TheChest.Containers;

namespace TheWorld.Tests.TheChest
{
    public partial class InventoryTests
    {
        #region Move

        [Test]
        public void MoveItem__Origin_item_and_null_target_should_move()
        {
            var item1 = this.DistinctItemGenerator();

            var slots = new Slot[2] { new Slot(item1), new Slot(null) };

            var inventory = new Inventory(slots);

            var res = inventory.MoveItem(0, 1);

            Assert.IsTrue(res);
            Assert.IsNull(inventory[0].CurrentItem);
            Assert.AreEqual(item1, inventory[1].CurrentItem);
        }

        [Test]
        public void MoveItem__Null_origin_and_Item_target_should_move()
        {
            var item2 = this.DistinctItemGenerator();

            var slots = new Slot[2] { new Slot(null), new Slot(item2) };

            var inventory = new Inventory(slots);

            var res = inventory.MoveItem(0, 1);

            Assert.IsTrue(res);
            Assert.AreEqual(item2, inventory[0].CurrentItem);
            Assert.IsNull(inventory[1].CurrentItem);
        }

        [Test]
        public void MoveItem__Null_origin_and_null_target_should_move()
        {
            var slots = new Slot[2] { new Slot(null), new Slot(null) };

            var inventory = new Inventory(slots);

            var res = inventory.MoveItem(0, 1);

            Assert.IsTrue(res);
            Assert.IsNull(inventory[0].CurrentItem);
            Assert.IsNull(inventory[1].CurrentItem);
        }

        [Test]
        public void MoveItem__Same_origin_target_item_should_stack()
        {
            var item1 = this.DefaultItemGenerator(maxStack: 2);

            var slots = new Slot[2] { new Slot(item1), new Slot(item1) };

            var inventory = new Inventory(slots);

            var res = inventory.MoveItem(0, 1);

            Assert.IsTrue(res);
            Assert.IsTrue(inventory[0].isEmpty);
            Assert.AreEqual(item1, inventory[1].CurrentItem);
        }

        [Test]
        public void MoveItem__Different_origin_and_target_item_should_change_slots()
        {
            var item1 = this.DistinctItemGenerator();
            var item2 = this.DistinctItemGenerator();

            var slots = new Slot[2]{ new Slot(item1) , new Slot(item2) };

            var inventory = new Inventory(slots);

            var res = inventory.MoveItem(0,1);

            Assert.IsTrue(res);
            Assert.AreEqual(item2, inventory[0].CurrentItem);
            Assert.AreEqual(item1, inventory[1].CurrentItem);
        }
        #endregion
    }
}
