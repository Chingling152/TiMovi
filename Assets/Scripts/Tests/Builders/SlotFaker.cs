using Bogus;
using TheChest.Slots.Generics.Interfaces;

namespace TheChest.Tests.Builders
{
    public class SlotFaker<Y, T> : Faker<Y>
        where Y: class, ISlot<T>
    {
        public SlotFaker()
        {
            RuleFor(x => x.CurrentItem, default(T));
        }

        public SlotFaker<Y, T> WithItem(T item)
        {
            RuleFor(x => x.CurrentItem, item);
            return this;
        }

        public SlotFaker<Y, T> WithoutItem()
        {
            RuleFor(x => x.CurrentItem, default(T));
            return this;
        }
    }
}
