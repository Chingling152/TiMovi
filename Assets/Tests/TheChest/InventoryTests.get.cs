using NUnit.Framework;
using System.Linq;
using TheChest.Containers;

namespace TheWorld.Tests.TheChest
{
    public partial class InventoryTests
    {
        [Test]
        public void OnGetOneFromIndex_ShouldReturnTheItem()
        {
            var amount = random.Next(low_amount,high_amount);
            var slots = Enumerable.Repeat(this.DefaultSlotGenerator(false, amount), high_size).ToArray();

            var inventory = new Inventory(slots);
            var slotIndex = random.Next(0, high_size);

            var result = inventory.GetItem(slotIndex);

            Assert.IsNotNull(result);
        }
        [Test]
        public void OnGetFromIndex_WrongValueShouldReturnNull()
        {
            var amount = random.Next(low_amount, high_amount);
            var slots = Enumerable.Repeat(this.DefaultSlotGenerator(false, amount), high_size).ToArray();

            var inventory = new Inventory(slots);

            var slotIndex = -1;

            var result = inventory.GetItem(slotIndex);

            Assert.IsNull(result);
        }
    }
}
