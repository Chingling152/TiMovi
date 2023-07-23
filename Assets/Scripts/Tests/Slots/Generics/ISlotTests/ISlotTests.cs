using Bogus;
using NUnit.Framework;
using TheChest.Examples.Items;
using TheChest.Examples.Slots;
using TheChest.Tests.Builders;

namespace TheChest.Tests.Slots.Generics
{
    public partial class ISlotTests
    {
        private SlotFaker<Slot,Item> slotFaker;
        private Faker<Item> itemFaker;

        [SetUp]
        public void Setup()
        {
            itemFaker = new Faker<Item>();
            slotFaker = new SlotFaker<Slot, Item>();
        }
    }
}
