using Bogus;
using TheChest.Slots.Generics.Interfaces;

namespace TheChest.Tests.Slots.Builders
{
    public class SlotFaker<Y, T> : Faker<Y>
        where Y: class, ISlot<T>
    {
        public SlotFaker()
        {
            RuleFor(x => x.CurrentItem, default(T));
        }

        public virtual SlotFaker<Y, T> WithItem(T item)
        {
            RuleFor(x => x.CurrentItem, item);
            return this;
        }

        public virtual SlotFaker<Y, T> WithoutItem()
        {
            RuleFor(x => x.CurrentItem, default(T));
            return this;
        }
    }
}
