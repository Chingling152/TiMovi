﻿using TheChest.Slots.Generics.Interfaces;

namespace TheChest.Slots.Generics.Base
{
    /// <summary>
    /// Generic Slot with space for one ietm
    /// </summary>
    /// <typeparam name="T">The item the slot accepts</typeparam>
    public abstract class BaseSlot<T> : ISlot<T>
    {
        public virtual T CurrentItem { get; protected set; }

        public virtual bool IsFull => !this.IsEmpty;

        public virtual bool IsEmpty => CurrentItem == null;

        /// <summary>
        /// Creates a basic slot with an item
        /// </summary>
        /// <param name="currentItem">item that belongs to this slot (null if empty)</param>
        protected BaseSlot(T currentItem = default)
        {
            this.CurrentItem = currentItem;
        }
    }
}
