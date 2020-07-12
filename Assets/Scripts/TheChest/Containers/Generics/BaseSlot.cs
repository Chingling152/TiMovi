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
        public virtual T CurrentItem { get; protected set; }

        /// <summary>
        /// Defines the amount of items this slot is holding
        /// </summary>
        public virtual int StackAmount { get; protected set; }

        /// <summary>
        /// Defines the max amount of item that this slot can contain
        /// </summary>
        public virtual int MaxStackAmount { get; protected set ;}

        public virtual bool isFull => StackAmount == MaxStackAmount;

        public virtual bool isEmpty => CurrentItem == null || StackAmount == 0;
        #endregion

        #region Constructor
        public BaseSlot(T CurrentItem = null, int amount = 1, int maxStackAmount = 1)
        {
            amount = amount > maxStackAmount? maxStackAmount :amount;

            this.CurrentItem = CurrentItem;
            this.StackAmount = CurrentItem != null ? amount : 0;
            this.MaxStackAmount = maxStackAmount < 0 ? 1 : maxStackAmount;
        }
        #endregion

        #region Add
        /// <summary>
        /// Adds a item in the slot (try stack)
        /// </summary>
        /// <param name="item">Item to be added</param>
        /// <returns>returns true if successfully added</returns>
        public virtual bool Add(T item)
        {
            if (
                this.isEmpty ||
                (this.CurrentItem == item && !this.isFull)
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
            
            if ((!this.isEmpty && this.CurrentItem != item) || this.isFull)
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
            
            if (this.CurrentItem == item)
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
