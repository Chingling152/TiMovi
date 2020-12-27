using NUnit.Framework;
using System.Linq;
using TheChest.Containers;

namespace TheWorld.Tests.TheChest
{
    public partial class InventoryTests
    {
        #region Index
        [Test]
        public void Get_from_index__should_return_Item()
        {
            var amount = random.Next(low_amount,high_amount);
            var slots = Enumerable.Repeat(this.DefaultSlotGenerator(false, amount), high_size).ToArray();

            var inventory = new Inventory(slots);
            var slotIndex = random.Next(0, high_size);

            var result = inventory.GetItem(slotIndex);

            Assert.IsNotNull(result);
        }

        [Test]
        public void Get_from_index__wrong_index_should_return_null()
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

        public void Get_Item__should_return_a_item()
        {
            var slots = Enumerable.Repeat(this.DefaultSlotGenerator(false), high_size).ToArray();

            var inventory = new Inventory(slots);
            //inventory.AddItem();

            var result = inventory.GetItem(random.Next(0, high_size));
        }

        #endregion

    }
}
