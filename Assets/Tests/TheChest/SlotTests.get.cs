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

            var slot = new Slot(item, stackAmount);

            var resultItem = slot.GetAll();

            Assert.AreEqual(stackAmount, resultItem.Length);
            Assert.IsTrue(slot.isEmpty);
            Assert.IsNull(slot.CurrentItem);
        }

        [Test]
        public void ShouldReturnAnAmountFromSlot()
        {
            var randomAmount = random.Next(1, 10);
            var expectedAmount = random.Next(10, 20);

            var item = this.DefaultItemGenerator();
            var slot = new Slot(item, expectedAmount);

            var result = slot.GetAmount(randomAmount);

            var resultAmount = result.Length;
            Assert.IsNotNull(result);
            Assert.AreEqual(randomAmount, resultAmount);
            Assert.AreEqual( (expectedAmount - resultAmount) == 0,slot.isEmpty);
        }

        [Test]
        public void ShouldReturnTheMaxItemsFromSlot()
        {
            var randomAmount = random.Next(1, 20);
            var item = this.DefaultItemGenerator();

            var slot = new Slot(item, randomAmount);

            var result = slot.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(randomAmount, result.Length);
        }

        [Test]
        public void OnReplaceEmptySlot_ShouldReturnNull()
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
        public void OnReplaceSlot_ShouldReturnOldObejct()
        {
            //Arrange
            var newItem = this.DefaultItemGenerator();
            var newItemAmountRandom = random.Next(1, 10);

            var oldItem = this.DefaultItemGenerator();
            var oldItemAmountRandom = random.Next(1,10);

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
        public void OnReplaceSlotWithNegativeAmount_ShouldNotReplace()
        {
            var newItem = this.DefaultItemGenerator();
            var newItemAmountRandom = random.Next(int.MinValue,-1);

            var oldItem = this.DefaultItemGenerator();
            var oldItemAmountRandom = random.Next(1, 10);

            //Act
            var slot = new Slot(oldItem, oldItemAmountRandom);

            var results = slot.Replace(newItem, newItemAmountRandom);

            // Assert
            Assert.IsEmpty(results);
            Assert.AreEqual(slot.CurrentItem,oldItem);
            Assert.AreEqual(slot.StackAmount,oldItemAmountRandom);
        }

        [Test]
        public void OnReplaceWithNullObject_ShouldReturnTheOldObject()
        {
            Item newItem = null;

            var oldItem = this.DefaultItemGenerator();
            var oldItemAmountRandom = random.Next(1, 10);

            //Act
            var slot = new Slot(oldItem, oldItemAmountRandom);

            var results = slot.Replace(newItem);

            Assert.IsTrue(slot.isEmpty);
            Assert.IsNull(slot.CurrentItem);
            Assert.AreEqual(oldItemAmountRandom,results.Length);
        }

    }
}
