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
        [Test]
        public void AddItems__Empty_Inventory_should_add_to_first_Slot()
        {
            var slots = Enumerable.Repeat(this.DefaultSlotGenerator(), high_size).ToArray();

            //TODO: generate slot using empty constructor
            var inventory = new Inventory(slots);

            var items = Enumerable.Repeat(this.DefaultItemGenerator(),1).ToArray();

            var result = inventory.AddItem(items);
            var slot = inventory[0];

            Assert.IsEmpty(result);
            Assert.IsFalse(slot.isEmpty);
            Assert.AreEqual(items[0], slot.CurrentItem);
        }

        [Test]
        public void AddItems__Bigger_amount_should_distribute_Items()
        {
            var maxStack = random.Next(low_amount, high_amount);
            var inventory = this.DefaultInventoryGenerator(isEmpty: true, slotAmount: high_size);

            var items = Enumerable.Repeat(this.DefaultItemGenerator(maxStack: maxStack / 2), maxStack).ToArray();

            var result = inventory.AddItem(items);

            Assert.IsEmpty(result);

            Assert.IsFalse(inventory[0].isEmpty);
            Assert.AreEqual(items[0], inventory[0].CurrentItem);

            Assert.IsFalse(inventory[1].isEmpty);
            Assert.AreEqual(items[1], inventory[1].CurrentItem);
        }

        [Test]
        public void AddItems__Existing_item_should_stack()
        {
            var slots = Enumerable.Repeat(this.DefaultSlotGenerator(false, 2), high_size).ToArray();

            var randomIndex = random.Next(1, high_size);
            var items = Enumerable.Repeat(this.DefaultItemGenerator(maxStack: 2), 1).ToArray();
            slots[randomIndex] = new Slot(items);

            var inventory = new Inventory(slots);

            var result = inventory.AddItem(items);
            var slot = inventory[randomIndex];

            Assert.IsEmpty(result);
            Assert.IsTrue(slot.isFull);
            Assert.AreEqual(items[0], slot.CurrentItem);
        }

        [Test]
        public void AddItems__Null_item_should_not_add()
        {
            var slots = Enumerable.Repeat(this.DefaultSlotGenerator(), high_size).ToArray();

            //TODO: generate slot using empty constructor
            var inventory = new Inventory(slots);

            var result = inventory.AddItem(null);
            var slot = inventory[0];

            Assert.IsEmpty(result);
            Assert.IsTrue(slot.isEmpty);
            Assert.IsNull(slot.CurrentItem);
        }

        [Test]
        public void AddItems__Full_Inventory_should_not_add()
        {
            var items = Enumerable.Repeat(this.DistinctItemGenerator(),1).ToArray();

            var inventory = this.DefaultInventoryGenerator(false, high_size, 2);
            var result = inventory.AddItem(items);

            Assert.IsNotEmpty(result);
            Assert.AreEqual(1, result.Length);
        }
        #endregion

        #region AddItemAt(item)
        [Test]
        public void AddItemAt__Invalid_index_should_not_add()
        {
            var amount = random.Next(low_amount,high_amount);
            var item = this.DefaultItemGenerator(maxStack: amount);

            var inventory = this.DefaultInventoryGenerator(slotAmount: high_size);

            var result = inventory.AddItemAt(item, -1, amount);

            Assert.IsNotEmpty(result);
            Assert.AreEqual(amount, result.Length);
        }

        [Test]
        public void AddItemAt__Valid_index_should_add()
        {
            var randomIndex = random.Next(1, high_size);
            var item = this.DefaultItemGenerator(maxStack: 2);

            var inventory = this.DefaultInventoryGenerator(slotAmount: high_size);

            var result = inventory.AddItemAt(item, randomIndex, 1);
            var slot = inventory[randomIndex];

            Assert.IsEmpty(result);
            Assert.False(slot.isEmpty);
            Assert.AreEqual(item, slot.CurrentItem);
        }

        [Test]
        public void AddItemAt__Same_existing_item_should_stack()
        {
            var slots = Enumerable.Repeat(this.DefaultSlotGenerator(false, 2), high_size).ToArray();

            var randomIndex = random.Next(1, high_size);
            var item = this.DefaultItemGenerator(maxStack: 2);
            slots[randomIndex] = new Slot(item, 1);

            var inventory = new Inventory(slots);

            var result = inventory.AddItemAt(item,randomIndex,1);
            var slot = inventory[randomIndex];

            Assert.IsEmpty(result);
            Assert.IsTrue(slot.isFull);
            Assert.AreEqual(item, slot.CurrentItem);
        }

        [Test]
        public void AddItemAt__Slot_full_with_same_item_should_stack_and_return()
        {
            var maxStack = random.Next(low_amount,high_amount);
            var slots = Enumerable.Repeat(this.DefaultSlotGenerator(false, maxStack), high_size).ToArray();

            var randomIndex = random.Next(1, high_size);
            var item = this.DefaultItemGenerator(maxStack: maxStack);
            slots[randomIndex] = new Slot(item, maxStack);

            var inventory = new Inventory(slots);

            var result = inventory.AddItemAt(item, randomIndex, maxStack * 2);
            var slot = inventory[randomIndex];

            Assert.IsNotEmpty(result);
            Assert.IsTrue(slot.isFull);
            Assert.AreEqual(item, slot.CurrentItem);
        }

        [Test]
        public void AddItemAt__Slot_full_with_item_should_replace_and_return()
        {
            var maxStack = random.Next(low_amount, high_amount);
            var slots = Enumerable.Repeat(this.DefaultSlotGenerator(false, maxStack), high_size).ToArray();

            var randomIndex = random.Next(1, high_size);
            var item = this.DefaultItemGenerator(maxStack: maxStack);

            var inventory = new Inventory(slots);

            var result = inventory.AddItemAt(item, randomIndex, maxStack * 2,true);
            var slot = inventory[randomIndex];

            Assert.IsNotEmpty(result);
            Assert.IsFalse(slot.isEmpty);
            Assert.AreEqual(item, slot.CurrentItem);
        }

        [Test]
        public void AddItemAt__Slot_full_with_item_should_not_replace_and_return()
        {
            var maxStack = random.Next(low_amount, high_amount);
            var slots = Enumerable.Repeat(this.DefaultSlotGenerator(false, maxStack), high_size).ToArray();

            var randomIndex = random.Next(1, high_size);
            var item = this.DefaultItemGenerator(maxStack: maxStack);

            var inventory = new Inventory(slots);

            var result = inventory.AddItemAt(item, randomIndex, maxStack * 2, false);
            var slot = inventory[randomIndex];

            Assert.IsNotEmpty(result);
            Assert.AreEqual(item,result[0]);
            Assert.IsFalse(slot.isEmpty);
            Assert.AreNotEqual(item, slot.CurrentItem);
        }
        #endregion

        #region AddItemAt(items)
        [Test]
        public void AddItemsAt__Invalid_index_should_not_add()
        {
            var amount = random.Next(low_amount, high_amount);
            var items = Enumerable.Repeat(this.DefaultItemGenerator(maxStack: amount), amount).ToArray();

            var inventory = this.DefaultInventoryGenerator(slotAmount: high_size);

            var result = inventory.AddItemAt(items, -1);

            Assert.IsNotEmpty(result);
            Assert.AreEqual(amount, result.Length);
        }

        [Test]
        public void AddItemsAt__Valid_index_should_add()
        {
            var randomIndex = random.Next(1, high_size);
            var items = Enumerable.Repeat(this.DefaultItemGenerator(maxStack: 2),1).ToArray();

            var inventory = this.DefaultInventoryGenerator(slotAmount: high_size);

            var result = inventory.AddItemAt(items, randomIndex);
            var slot = inventory[randomIndex];

            Assert.IsEmpty(result);
            Assert.False(slot.isEmpty);
            Assert.AreEqual(items[0], slot.CurrentItem);
        }

        [Test]
        public void AddItemsAt__Same_existing_item_should_stack()
        {
            var slots = Enumerable.Repeat(this.DefaultSlotGenerator(false, 2), high_size).ToArray();

            var randomIndex = random.Next(1, high_size);
            var items = Enumerable.Repeat(this.DefaultItemGenerator(maxStack: 2),1).ToArray();
            slots[randomIndex] = new Slot(items);

            var inventory = new Inventory(slots);

            var result = inventory.AddItemAt(items, randomIndex);
            var slot = inventory[randomIndex];

            Assert.IsEmpty(result);
            Assert.IsTrue(slot.isFull);
            Assert.AreEqual(items[0], slot.CurrentItem);
        }

        [Test]
        public void AddItemsAt__Slot_full_with_same_item_should_stack_and_return()
        {
            var maxStack = random.Next(low_amount, high_amount);
            var slots = Enumerable.Repeat(this.DefaultSlotGenerator(false, maxStack), high_size).ToArray();

            var randomIndex = random.Next(1, high_size);
            var items = Enumerable.Repeat(this.DefaultItemGenerator(maxStack: maxStack), maxStack * 2).ToArray();
            slots[randomIndex] = new Slot(items);

            var inventory = new Inventory(slots);

            var result = inventory.AddItemAt(items, randomIndex);
            var slot = inventory[randomIndex];

            Assert.IsNotEmpty(result);
            Assert.IsTrue(slot.isFull);
            Assert.AreEqual(items[0], slot.CurrentItem);
        }

        [Test]
        public void AddItemsAt__Slot_full_with_item_should_replace_and_return()
        {
            var maxStack = random.Next(low_amount, high_amount);
            var slots = Enumerable.Repeat(this.DefaultSlotGenerator(false, maxStack), high_size).ToArray();

            var randomIndex = random.Next(1, high_size);
            var items = Enumerable.Repeat(this.DefaultItemGenerator(maxStack: maxStack), maxStack * 2).ToArray();

            var inventory = new Inventory(slots);

            var result = inventory.AddItemAt(items, randomIndex, true);
            var slot = inventory[randomIndex];

            Assert.IsNotEmpty(result);
            Assert.IsFalse(slot.isEmpty);
            Assert.AreEqual(items[0], slot.CurrentItem);
        }

        [Test]
        public void AddItemsAt__Slot_full_with_item_should_not_replace_and_return()
        {
            var maxStack = random.Next(low_amount, high_amount);
            var slots = Enumerable.Repeat(this.DefaultSlotGenerator(false, maxStack), high_size).ToArray();

            var randomIndex = random.Next(1, high_size);
            var items = Enumerable.Repeat(this.DefaultItemGenerator(maxStack: maxStack), maxStack * 2).ToArray();

            var inventory = new Inventory(slots);

            var result = inventory.AddItemAt(items, randomIndex, false);
            var slot = inventory[randomIndex];

            Assert.IsNotEmpty(result);
            Assert.AreEqual(items[0], result[0]);
            Assert.IsFalse(slot.isEmpty);
            Assert.AreNotEqual(items[0], slot.CurrentItem);
        }
        #endregion
    } 
}