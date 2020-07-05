using System;

namespace TheChest.Containers.Generics
{
    /// <summary>
    /// Generic Slot with defined Stack
    /// </summary>
    /// <typeparam name="T">The item the slot accepts</typeparam>
    public class BaseSlot<T> : ISlot<T>
    {
        #region Properties
        public virtual T CurrentItem { get; protected set; }

        public virtual int StackAmount { get; protected set; }

        public virtual int MaxStackAmount { get; protected set; }

        public virtual bool isFull => StackAmount == MaxStackAmount;

        public virtual bool isEmpty => CurrentItem == null || StackAmount == 0;
        #endregion

        #region Constructor
        public BaseSlot(T CurrentItem = default, int amount = 1, int maxStackAmount = 1)
        {
            amount = amount > maxStackAmount? maxStackAmount :amount;

            this.CurrentItem = CurrentItem;
            this.StackAmount = CurrentItem != null ? amount : 0;
            this.MaxStackAmount = maxStackAmount < 0 ? 1 : maxStackAmount;
        }
        #endregion

        #region Add
        public virtual bool Add(T item)
        {
            if (
                this.isEmpty ||
                (this.CurrentItem.Equals(item) && !this.isFull)
            )
            {
                this.CurrentItem = item;
                this.StackAmount++;
                return true;
            }

            return false;
        }

        public virtual int Add(T item, int amount = 1)
        {
            if (amount < 1) return 0; 
            
            var equals = this.CurrentItem?.Equals(item) ?? false;

            if ((!this.isEmpty && !equals) || this.isFull)
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
        #endregion

        #region Replace
        public virtual T[] Replace(T item, int amount = 1)
        {
            T[] items = new T[0];

            if (amount < 1) return items;
            
            if (this.CurrentItem?.Equals(item)??false)
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
        #endregion

        #region Get
        public virtual T GetOne()
        {
            if (StackAmount < 1)
                return default;

            T item = this.CurrentItem;

            this.StackAmount--;

            if (StackAmount == 0)
                this.CurrentItem = default;

            return item;
        }

        public virtual T[] GetAmount(int amount = 1)
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
        #endregion
    }
}
