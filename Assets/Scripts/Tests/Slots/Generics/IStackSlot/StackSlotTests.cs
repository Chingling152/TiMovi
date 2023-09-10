using System;
using Bogus;
using NUnit.Framework;
using TheChest.Examples.Items;
using TheChest.Examples.Slots;
using TheChest.Tests.Slots.Builders;

namespace TheChest.Tests.Slots.Generics
{
    public partial class StackSlotTests
    {
        private StackSlotFaker<StackSlot, Item> slotFaker;
        private Faker<Item> itemFaker;
        private Random random;

        [SetUp]
        public void Setup()
        {
            random = new Random();
            itemFaker = new Faker<Item>();
            slotFaker = new StackSlotFaker<StackSlot, Item>();
        }
    }
}
