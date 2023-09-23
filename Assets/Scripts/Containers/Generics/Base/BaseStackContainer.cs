using System.Linq;
using TheChest.Containers.Generics.Interfaces;
using TheChest.Slots.Generics.Interfaces;

namespace TheChest.Containers.Generics.Base
{
    public abstract class BaseStackContainer<T> : BaseContainer<T>, IStackContainer<T>
    {
        protected virtual IStackSlot<T>[] slots => base.Slots as IStackSlot<T>[];

        public override bool IsFull => this.slots?.All(x => x.IsFull) ?? false;

        public override bool IsEmpty => this.slots?.All(x => x.IsEmpty) ?? true;

        protected BaseStackContainer(IStackSlot<T>[] slots) : base(slots)
        {
        }

        protected BaseStackContainer(int size = DEFAULT_SLOT_COUNT) : base(size)
        {
        }
    }
}
