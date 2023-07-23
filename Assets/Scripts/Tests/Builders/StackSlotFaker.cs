using TheChest.Slots.Generics.Interfaces;

namespace TheChest.Tests.Builders
{
    public class StackSlotFaker<Y, T> : SlotFaker<Y, T>
        where Y : class, IStackSlot<T>
    {
        public StackSlotFaker() : base()
        {
            RuleFor(x => x.MaxStackAmount, x => x.Random.Number(5,10));
            RuleFor(x => x.StackAmount, x => x.Random.Number(1,5));
        }

        public override SlotFaker<Y, T> WithoutItem()
        {
            RuleFor(x => x.StackAmount,0);
            return base.WithoutItem();
        }

        public virtual StackSlotFaker<Y, T> WithMaxAmount(int amount)
        {
            RuleFor(x => x.MaxStackAmount, amount);

            return this;
        }

        public virtual StackSlotFaker<Y, T> WithItem(T item, int amount)
        {
            base.WithItem(item);

            RuleFor(x => x.StackAmount, amount);

            return this;
        }
    }
}
