using NUnit.Framework;
using System.Linq;
using TheChest.Containers;
using TheChest.Items;

namespace TheWorld.Tests.TheChest
{
    public partial class InventoryTests
    {
        #region AddItem(item)

        [Test]
        public void AddItem__Empty_Inventory_should_add_to_first_Slot()
        {
            var slots = Enumerable.Repeat(this.DefaultSlotGenerator(), high_size).ToArray();

            //TODO: generate slot using empty constructor
            var inventory = new Inventory(slots);

            var item = this.DefaultItemGenerator();

            var result = inventory.AddItem(item);
            var slot = inventory[0];

            Assert.IsEmpty(result);
            Assert.IsFalse(slot.isEmpty);
            Assert.AreEqual(item, slot.CurrentItem);
        }

        [Test]
        public void AddItem__Null_item_should_not_add()
        {
            var slots = Enumerable.Repeat(this.DefaultSlotGenerator(), high_size).ToArray();

            //TODO: generate slot using empty constructor
            var inventory = new Inventory(slots);

            var result = inventory.AddItem(null);
            var slot = inventory[0];

            Assert.IsNull(result);
            Assert.IsTrue(slot.isEmpty);
            Assert.IsNull(slot.CurrentItem);
        }

        [Test]
        public void AddItem__Bigger_amount_should_distribute_Items()
        {
            var maxStack = random.Next(low_amount, high_amount);
            var inventory = this.DefaultInventoryGenerator(isEmpty:true,slotAmount:high_size,itemAmount: maxStack);

            var item = this.DefaultItemGenerator(maxStack : maxStack / 2);

            var result = inventory.AddItem(item, maxStack);

            Assert.IsEmpty(result);

            Assert.IsFalse(inventory[0].isEmpty);
            Assert.AreEqual(item, inventory[0].CurrentItem);

            Assert.IsFalse(inventory[1].isEmpty);
            Assert.AreEqual(item, inventory[1].CurrentItem);
        }

        [Test]
        public void AddItem__Existing_item_should_stack()
        {
            var slots = Enumerable.Repeat(this.DefaultSlotGenerator(false, 2), high_size).ToArray();

            var randomIndex = random.Next(1, high_size);
            var item = this.DefaultItemGenerator(maxStack: 2);
            slots[randomIndex] = new Slot(item, 1);

            var inventory = new Inventory(slots);

            var result = inventory.AddItem(item);
            var slot = inventory[randomIndex];

            Assert.IsEmpty(result);
            Assert.IsTrue(slot.isFull);
            Assert.AreEqual(item, slot.CurrentItem);
        }

        [Test]
        public void AddItem__Full_Inventory_should_not_add()
        {
            var item = this.DistinctItemGenerator();

            var inventory = this.DefaultInventoryGenerator(false, high_size,2);
            var result = inventory.AddItem(item);

            Assert.IsNotEmpty(result);
            Assert.AreEqual(1,result.Length);
        }
        #endregion

        #region AddItem(items)
        #endregion

        #region AddItemAt(item)
        #endregion

        #region AddItemAt(items)
        #endregion
    } 
}