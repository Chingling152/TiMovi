using NUnit.Framework;
using System;
using TheChest.Containers;
using TheChest.Items;

namespace TheWorld.Tests.TheChest
{
    public partial class InventoryTests
    {
        public Random random;

        const int low_amount = 10;
        const int high_amount = 20;


        const int low_size = 10;
        const int high_size = 20;

        public InventoryTests()
        {
            random = new Random();

            Assert.IsTrue(low_amount < high_amount);
        }

        private Item DefaultItemGenerator()
        {
            return new Item(
              id: Guid.NewGuid().ToString(),
              name: Guid.NewGuid().ToString(),
              description: Guid.NewGuid().ToString(),
              image: null,
              maxStack: random.Next(1, high_amount)
           );
        }

        private Slot DefaultSlotGenerator(bool isEmpty = true,int amount = high_amount)
        {
            if(isEmpty)
                return new Slot();
            else
                return new Slot(this.DefaultItemGenerator(), amount);
        }

        [Test]
        public void InventoryConstructorAmount()
        {
            var amount = random.Next(low_amount,high_amount);
            var inventory = new Inventory(amount);
            Assert.AreEqual(amount, inventory.Slots.Length);
        }

        [Test]
        public void InventoryConstructorNegativeAmount()
        {
            var amount = random.Next(-high_amount,-low_amount);
            var inventory = new Inventory(amount);
            Assert.Zero(inventory.Slots.Length);
        }
    }
}
