using System;

namespace TheChest.Containers.Generics
{
    /// <summary>
    /// Generic Slot with defined Stack
    /// </summary>
    /// <typeparam name="T">The item the slot accepts</typeparam>
    public class BaseSlot<T> : ISlot<T> where T : class
    {
        #region Properties
        /// <summary>
        /// The current item inside the slot
        /// </summary>
        public virtual T CurrentItem { get; protected set; }

        /// <summary>
        /// Defines the amount of items this slot is holding
        /// </summary>
        public virtual int StackAmount { get; protected set; }

        /// <summary>
        /// Defines the max amount of item that this slot can contain
        /// </summary>
        public virtual int MaxStackAmount { get; protected set ;}

        /// <summary>
        /// Verify if the slot is full
        /// </summary>
        public virtual bool IsFull => StackAmount == MaxStackAmount && !this.IsEmpty;

        /// <summary>
        /// Verify if the slot is empty
        /// </summary>
        public virtual bool IsEmpty => CurrentItem == null || StackAmount == 0;
        #endregion

        #region Constructor
        public BaseSlot(T CurrentItem = null, int amount = 1, int maxStackAmount = 1)
        {
            amount = amount > maxStackAmount? maxStackAmount :amount;

            this.CurrentItem = CurrentItem;
            this.StackAmount = CurrentItem != null ? amount : 0;
            this.MaxStackAmount = maxStackAmount < 0 ? 1 : maxStackAmount;
        }

        public BaseSlot(T[] items,int maxStack = 1)
        {
            if(items != null && items.Length == 0)
            {
                this.CurrentItem = items[0];

                if(items.Length > maxStack)
                    this.StackAmount = maxStack;
                else
                    this.StackAmount = items.Length;
            }
            this.MaxStackAmount = maxStack;
        }
        #endregion

        #region Add
        /// <summary>
        /// Adds an item in the slot (try stack)
        /// </summary>
        /// <param name="item">Item to be added</param>
        /// <returns>returns true if successfully added</returns>
        public virtual bool Add(T item)
        {
            var eq = this.CurrentItem?.Equals(item)??false;
            if (this.IsEmpty || (eq && !this.IsFull))
            {
                this.CurrentItem = item;
                this.StackAmount++;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Adds an item in the slot
        /// </summary>
        /// <param name="item">Item to be added</param>
        /// <param name="amount">amount to be added</param>
        /// <returns>Returns the amount that could be not be added</returns>
        public virtual int Add(T item, int amount = 1)
        {
            if (amount < 1) return 0;

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

        /// <summary>
        /// Adds an array of items in the slot
        /// </summary>
        /// <param name="items">array of items to be added</param>
        /// <returns>Returns the amount that could be not be added</returns>
        public int Add(T[] items)
        {
            if(items == null || items.Length == 0) return 0;

            var eq = this.CurrentItem?.Equals(items[0])??false;

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
        #endregion

        #region Replace
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

        public T[] Replace(T[] items)
        {
            T[] retItems = new T[0];

            if (items == null || items.Length == 0) return this.GetAll();

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
        #endregion

        #region Get
        public virtual T GetOne()
        {
            if (StackAmount < 1)
                return null;

            T item = this.CurrentItem;

            this.StackAmount--;

            if (StackAmount == 0)
                this.CurrentItem = null;

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

            if (this.StackAmount == 0) this.CurrentItem = null;

            return items;
        }

        public virtual T[] GetAll()
        {
            return this.GetAmount(this.StackAmount);
        }
        #endregion
    }
}
