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
        public void OnGetAll_ShouldReturnAllItemsFromSlot()
        {
            var stackAmount = random.Next(2, high_amount);

            var item = new Item(
              id: Guid.NewGuid().ToString(),
              name: Guid.NewGuid().ToString(),
              description: Guid.NewGuid().ToString(),
              image: null,
              maxStack: stackAmount
           );

            var slot = new Slot(item, stackAmount);

            var resultItem = slot.GetAll();

            Assert.AreEqual(stackAmount, resultItem.Length);
            Assert.IsTrue(slot.isEmpty);
            Assert.IsNull(slot.CurrentItem);
        }

        [Test]
        public void OnGetAmount_ShouldReturnAnAmountFromSlot()
        {
            var randomAmount = random.Next(1, low_amount);
            var expectedAmount = random.Next(low_amount, high_amount);

            var item = this.DefaultItemGenerator();
            var slot = new Slot(item, expectedAmount);

            var result = slot.GetAmount(randomAmount);

            var resultAmount = result.Length;
            Assert.IsNotNull(result);
            Assert.AreEqual(randomAmount, resultAmount);
            Assert.AreEqual( (expectedAmount - resultAmount) == 0,slot.isEmpty);
        }

        [Test]
        public void OnGetAmount_BiggestAmountShouldReturnTheMaxCapacity()
        {
            var searchedAmount = random.Next(low_amount, high_amount);
            var itemAmount = random.Next(1, low_amount);

            var item = this.DefaultItemGenerator();
            var slot = new Slot(item, itemAmount);

            var result = slot.GetAmount(searchedAmount);

            Assert.IsTrue(slot.isEmpty);
            Assert.AreEqual(itemAmount,result.Length);
        }

        [Test]
        public void OnGetAll_ShouldReturnTheMaxItemsFromSlot()
        {
            var randomAmount = random.Next(1, high_amount);
            var item = this.DefaultItemGenerator();

            var slot = new Slot(item, randomAmount);

            var result = slot.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(randomAmount, result.Length);
        }

        [Test]
        public void OnReplace_EmptySlotShouldReturnNull()
        {
            //Arrange
            var item = this.DefaultItemGenerator();

            var slot = new Slot();
            
            //Act
            var result = slot.Replace(item,1);

            //Assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void OnReplace_ShouldReturnOldObejct()
        {
            //Item to replace
            var newItem = this.DefaultItemGenerator();
            var newItemAmountRandom = random.Next(1, low_amount);

            //Item to be replaced
            var oldItem = this.DefaultItemGenerator();
            var oldItemAmountRandom = random.Next(1, low_amount);

            //Act
            var slot = new Slot(oldItem, oldItemAmountRandom);

            var results = slot.Replace(newItem, newItemAmountRandom);

            //Assert
            Assert.AreEqual(oldItemAmountRandom,results.Length);

            foreach (var result in results)
            {
                Assert.AreEqual(oldItem,result);
            }

            Assert.AreEqual(newItem,slot.CurrentItem);
            Assert.AreEqual(newItemAmountRandom,slot.StackAmount);
        }
    
        [Test]
        public void OnReplace_SlotWithNegativeAmountShouldNotReplace()
        {
            //Item to replace
            var newItem = this.DefaultItemGenerator();
            var newItemAmountRandom = random.Next(int.MinValue,-1);

            //Item to be replaced
            var oldItem = this.DefaultItemGenerator();
            var oldItemAmountRandom = random.Next(1, low_amount);

            var slot = new Slot(oldItem, oldItemAmountRandom);

            var results = slot.Replace(newItem, newItemAmountRandom);

            //Tests
            Assert.IsEmpty(results);
            Assert.AreEqual(slot.CurrentItem,oldItem);
            Assert.AreEqual(slot.StackAmount,oldItemAmountRandom);
        }

        [Test]
        public void OnReplaceWithNullObject_ShouldReturnTheOldObject()
        {
            Item newItem = null;

            var oldItem = this.DefaultItemGenerator();
            var oldItemAmountRandom = random.Next(1, low_amount);

            //Act
            var slot = new Slot(oldItem, oldItemAmountRandom);

            var results = slot.Replace(newItem);

            Assert.IsTrue(slot.isEmpty);
            Assert.IsNull(slot.CurrentItem);
            Assert.AreEqual(oldItemAmountRandom,results.Length);
        }

        [Test]
        public void OnReplace_SameItemType_ShouldStack()
        {
            var itemAmount = random.Next(1, low_amount);
            var maxStack = itemAmount * 2 + random.Next(0, low_amount / 2);//to be possible to add twice and not get full

            var item = new Item(
              id: Guid.NewGuid().ToString(),
              name: Guid.NewGuid().ToString(),
              description: Guid.NewGuid().ToString(),
              image: null,
              maxStack: maxStack
           );

            var slot = new Slot(item, itemAmount);

            var results = slot.Replace(item, itemAmount);

            Assert.Zero(results.Length);
            Assert.AreEqual(slot.StackAmount, itemAmount * 2);
        }

        [Test]
        public void OnReplace_SameItemTypeWithBiggerAmountShouldStackAndReturnTheItemsNotAdded()
        {
            var maxStack = random.Next(low_amount, high_amount);
            var itemAmount = maxStack / 2 + random.Next(1, low_amount / 2);//to be possible to add twice and overflow

            var item = new Item(
              id: Guid.NewGuid().ToString(),
              name: Guid.NewGuid().ToString(),
              description: Guid.NewGuid().ToString(),
              image: null,
              maxStack: maxStack
           );

            var slot = new Slot(item, itemAmount);

            var results = slot.Replace(item, itemAmount);

            Assert.IsTrue(slot.isFull);
            Assert.AreEqual(itemAmount * 2 - maxStack, results.Length);
        }
    }
}
