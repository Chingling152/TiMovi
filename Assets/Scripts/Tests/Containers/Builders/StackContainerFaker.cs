using TheChest.Containers.Generics.Interfaces;
using TheChest.Slots.Generics.Interfaces;
using TheChest.Tests.Slots.Builders;

namespace TheChest.Tests.Containers.Builders
{
    public class StackContainerFaker<C, S, T> : ContainerFaker<C, S, T>
        where C : class, IStackContainer<T>
        where S : class, IStackSlot<T>
    {
        public StackContainerFaker(StackSlotFaker<S, T> faker) : base(faker)
        {
        }
    }
}
