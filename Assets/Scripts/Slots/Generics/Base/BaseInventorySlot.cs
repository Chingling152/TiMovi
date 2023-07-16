using System;
using TheChest.Slots.Generics.Interfaces;

namespace TheChest.Slots.Generics.Base
{
    public abstract class BaseInventorySlot<T> : BaseSlot<T>, IInventorySlot<T>
    {
        public virtual bool Add(T item)
        {
            var eq = this.CurrentItem?.Equals(item) ?? false;
            if (this.IsEmpty || (eq && !this.IsFull))
            {
                this.CurrentItem = item;
                return true;
            }

            return false;
        }

        public virtual T Replace(T item)
        {
            throw new NotImplementedException();
        }

        public virtual T GetOne()
        {
            if (IsEmpty)
                return default;

            T item = this.CurrentItem;
            this.CurrentItem = default;

            return item;
        }
    }
}
