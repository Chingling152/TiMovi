using Bogus;
using TheChest.Containers.Generics.Interfaces;
using TheChest.Slots.Generics.Interfaces;
using TheChest.Tests.Slots.Builders;

namespace TheChest.Tests.Containers.Builders
{
    public class ContainerFaker<C, S, T> : Faker<C>
        where C: class, IContainer<T> 
        where S: class, ISlot<T>
    {
        protected int slotAmount;

        protected readonly SlotFaker<S, T> faker;

        public ContainerFaker(SlotFaker<S, T> faker)
        {
            this.slotAmount = new Faker().Random.Int(10,20);
            this.faker = faker;
            RuleFor(x => x.Slots, this.faker.WithoutItem().Generate(slotAmount).ToArray());
        }

        public ContainerFaker<C, S, T> WithSizeOf(int size)
        {
            this.slotAmount = size;
            RuleFor(
                x => x.Slots, 
                this.faker
                    .WithoutItem()
                    .Generate(size)
                    .ToArray()
            );

            return this;
        }

        public ContainerFaker<C, S, T> WithItemAt(int index, T item)
        {
            var slot =  this.faker.WithItem(item).Generate();
            RuleFor(x => x.Slots, 
                (_, c) => {
                    c.Slots[index] = slot;
                    return c.Slots;
                }
            );

            return this;
        }

        public ContainerFaker<C, S, T> WithNoItemAt(int index)
        {
            var slot = this.faker
                .WithoutItem()
                .Generate();

            RuleFor(x => x.Slots, 
                (_, c) => {
                    c.Slots[index] = slot;
                    return c.Slots;
                }
            );

            return this;
        }

        public ContainerFaker<C, S, T> FullOfItems(params T[] items)
        {
            var arr = new S[slotAmount];
            if(items.Length == slotAmount)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    arr[i] = this.faker.WithItem(items[i]).Generate();
                }
            }
            else
            {
                arr = this.faker.WithItem(items[0]).Generate(slotAmount).ToArray();
            }

            RuleFor(x => x.Slots, arr);

            return this;
        }
    }
}
