using System;
using TheChest.Slots.Generics.Interfaces;

namespace TheChest.Slots.Generics.Base
{
    /// <summary>
    /// Generic Slot with space for one ietm
    /// </summary>
    /// <typeparam name="T">The item the slot accepts</typeparam>
    public class BaseSlot<T> : ISlot<T>
    {
        public virtual T CurrentItem { get; protected set; }

        public virtual bool IsFull => !this.IsEmpty;

        public virtual bool IsEmpty => CurrentItem == null;

        /// <summary>
        /// Creates a basic slot with an item
        /// </summary>
        /// <param name="currentItem">item that belongs to this slot (null if empty)</param>
        public BaseSlot(T currentItem = default)
        {
            this.CurrentItem = currentItem;
        }

        public virtual bool Add(T item)
        {
            var eq = this.CurrentItem?.Equals(item)??false;
            if (this.IsEmpty || (eq && !this.IsFull))
            {
                this.CurrentItem = item;
                return true;
            }

            return false;
        }

        public T Replace(T item)
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
