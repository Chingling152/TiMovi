using Bogus;
using NUnit.Framework;
using System;
using TheChest.Examples.Containers;
using TheChest.Examples.Items;
using TheChest.Examples.Slots;
using TheChest.Tests.Builders;

namespace TheChest.Tests.Containers.Generics.IContainerTests
{
    public partial class IContainerTests
    {
        private Random random;
        private ContainerFaker<Container, Slot, Item> containerFaker;
        private Faker<Item> itemFaker;

        [SetUp]
        public void Setup()
        {
            this.random = new Random();
            this.itemFaker = new Faker<Item>();
            var slotFaker = new SlotFaker<Slot, Item>();
            this.containerFaker = new ContainerFaker<Container, Slot, Item>(slotFaker);
        }
    }
}
