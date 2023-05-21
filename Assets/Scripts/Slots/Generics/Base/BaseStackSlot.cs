using System;
using TheChest.Slots.Generics.Interfaces;

namespace TheChest.Slots.Generics.Base
{
    public abstract class BaseStackSlot<T> : BaseSlot<T>, IStackSlot<T>
    {
        public virtual int StackAmount { get; protected set; }

        public virtual int MaxStackAmount { get; protected set; }

        public override bool IsFull => StackAmount == MaxStackAmount && !this.IsEmpty;

        public override bool IsEmpty => CurrentItem == null || StackAmount == 0;

        public BaseStackSlot(T currentItem = default, int amount = 1, int maxStackAmount = 1) : base(currentItem)
        {
            amount = amount > maxStackAmount ? maxStackAmount : amount;

            this.StackAmount = currentItem != null ? amount : 0;
            this.MaxStackAmount = maxStackAmount < 0 ? 1 : maxStackAmount;
        }

        public BaseStackSlot(T[] items, int maxStack)
        {
            if (items != null && items.Length == 0)
            {
                this.CurrentItem = items[0];

                if (items.Length > maxStack)
                    this.StackAmount = maxStack;
                else
                    this.StackAmount = items.Length;
            }
            this.MaxStackAmount = maxStack;
        }

        public override T GetOne()
        {
            if (this.IsEmpty)
                return default;

            T item = this.CurrentItem;

            this.StackAmount--;

            if (StackAmount == 0)
                this.CurrentItem = default;

            return item;
        }

        public virtual T[] GetAmount(int amount)
        {
            if (amount < 1) return new T[0];
            if (amount > StackAmount) amount = this.StackAmount;

            T[] items = new T[amount];

            for (int i = 0; i < amount; i++)
            {
                this.StackAmount--;
                items[i] = this.CurrentItem;
            }

            if (this.StackAmount == 0) this.CurrentItem = default;

            return items;
        }

        public virtual T[] GetAll()
        {
            return this.GetAmount(this.StackAmount);
        }

        public override bool Add(T item)
        {
            var added = base.Add(item);

            if (added)
            {
                this.StackAmount++;
            }

            return added;
        }

        public virtual int Add(T item, int amount)
        {
            if (amount < 1) 
                return 0;

            var eq = this.CurrentItem?.Equals(item) ?? false;

            if ((!this.IsEmpty && !eq) || this.IsFull)
                return amount;

            int res = 0;

            this.CurrentItem = item;

            if (amount + this.StackAmount > MaxStackAmount)
            {
                res = this.StackAmount + amount - MaxStackAmount;
                this.StackAmount = MaxStackAmount;
            }
            else
            {
                this.StackAmount += amount;
            }

            return Math.Abs(res);
        }

        public virtual int Add(T[] items)
        {
            if (items == null || items.Length == 0) 
                return 0;

            var eq = this.CurrentItem?.Equals(items[0]) ?? false;

            if ((!this.IsEmpty && !eq) || this.IsFull)
                return items.Length;

            int res = 0;

            this.CurrentItem = items[0];

            if (items.Length + this.StackAmount > MaxStackAmount)
            {
                res = this.StackAmount + items.Length - MaxStackAmount;
                this.StackAmount = MaxStackAmount;
            }
            else
            {
                this.StackAmount += items.Length;
            }

            return Math.Abs(res);
        }

        public virtual T[] Replace(T item, int amount = 1)
        {
            T[] items = new T[0];

            if (amount < 1) return items;

            var eq = this.CurrentItem?.Equals(item) ?? false;

            if (eq)
            {
                int resultAmount = this.Add(item, amount);

                items = new T[resultAmount];

                for (int i = 0; i < resultAmount; i++)
                {
                    items[i] = this.CurrentItem;
                }
            }
            else
            {
                items = this.GetAll();

                this.CurrentItem = item;
                this.StackAmount = amount;
            }

            return items;
        }

        public virtual T[] Replace(T[] items)
        {
            if (items == null || items.Length == 0) 
                return this.GetAll();

            T[] retItems;

            var eq = this.CurrentItem?.Equals(items[0]) ?? false;

            if (eq)
            {
                int resultAmount = this.Add(items);

                retItems = new T[resultAmount];

                for (int i = 0; i < resultAmount; i++)
                {
                    retItems[i] = this.CurrentItem;
                }
            }
            else
            {
                retItems = this.GetAll();

                this.CurrentItem = items[0];
                this.StackAmount = items.Length;
            }

            return retItems;
        }
    }
}
