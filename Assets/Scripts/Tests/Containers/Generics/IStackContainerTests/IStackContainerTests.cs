using Bogus;
using NUnit.Framework;
using System;
using TheChest.Examples.Items;
using TheChest.Examples.Slots;
using TheChest.Tests.Slots.Builders;
using TheChest.Tests.Containers.Builders;
using TheChest.Examples.Containers;

namespace TheChest.Tests.Containers.Generics.IStackContainerTests
{
    public partial class IStackContainerTests
    {
        private Random random;
        private StackContainerFaker<StackContainer, StackSlot, Item> containerFaker;
        private Faker<Item> itemFaker;

        [SetUp]
        public void Setup()
        {
            this.random = new Random();
            this.itemFaker = new Faker<Item>();
            var slotFaker = new StackSlotFaker<StackSlot, Item>();
            this.containerFaker = new StackContainerFaker<StackContainer, StackSlot, Item>(slotFaker);
        }
    }
}
