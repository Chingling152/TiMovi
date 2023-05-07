using System;
using TheChest.Containers.Generics.Interfaces;

namespace TheChest.Containers.Generics.Base
{
    public abstract class BaseContainer<T> : IContainer<T>
    {
        protected const int DEFAULT_SLOT_COUNT = 20;
        public virtual ISlot<T>[] Slots {
            get ;
            protected set;
        }

        public ISlot<T> this[int index] => this.Slots[index];

        public int Size => Slots.Length;

        public BaseContainer(ISlot<T>[] slots)
        {
            Slots = slots;
        }

        public BaseContainer(int size = DEFAULT_SLOT_COUNT)
        {
            if(size < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), $"Invalid Container Size : {size}");
            }
            Slots = new ISlot<T>[size];
        }
    }
}
