using System.Collections.Generic;
using System.Linq;

namespace TheChest.Containers.Generics
{
    /// <summary>
    /// Base inventory With IInventory Implemented
    /// </summary>
    /// <typeparam name="T">Any kind of item</typeparam>
    public class BaseInventory<T> : IInventory<T> where T : class
    {
        #region Properties

        /// <summary>
        /// The null size of every Inventory (just used in null constructor)
        /// </summary>
        public const int DEFAULT_SLOT_COUNT = 20;

        public virtual ISlot<T>[] Slots { get; protected set; }

        public virtual int Size => Slots.Length;
        #endregion

        #region Constructors

        /// <summary>
        /// Creates an inventory with 20 Slots
        /// </summary>
        public BaseInventory()
        {
            this.Slots = new ISlot<T>[DEFAULT_SLOT_COUNT];
        }

        /// <summary>
        /// Creates a inventory with a defined size
        /// </summary>
        /// <param name="size">The amount of Slots that will have (or 0 if lower than 0 )</param>
        public BaseInventory(int size)
        {
            if (size < 0) size = 0;
            this.Slots = new ISlot<T>[size];
        }

        /// <summary>
        /// Creates an inventory with defined slots
        /// </summary>
        /// <param name="slots">Slots of the inventory</param>
        public BaseInventory(ISlot<T>[] slots)
        {
            this.Slots = slots;
        }
        #endregion

        #region Add

        public virtual T[] AddItem(T item, int amount = 1)
        {
            if(amount < 1) return new T[0];

            var itemArr = Enumerable.Repeat(item,amount).ToArray();

            for (int i = 0; i < Slots.Length; i++)
            {
                if (this.Slots[i].isEmpty || (!this.Slots[i].isFull && this.Slots[i].CurrentItem == item))
                {
                    var result = this.Slots[i].Add(item, amount);
                    itemArr = Enumerable.Repeat(item, result).ToArray();
                }

                if (itemArr.Length == 0)
                    break;
            }
            
            return itemArr;
        }

        public virtual T[] AddItemAt(T item, int index, int amount = 1, bool replace = true)
        {
            if (index < 0 || index >= Slots.Length || amount < 1) return new T[0];

            if (this.Slots[index].isEmpty || (!this.Slots[index].isFull && this.Slots[index].CurrentItem == item))
            {
                var result = this.Slots[index].Add(item,amount);
                return Enumerable.Repeat(item, result).ToArray();
            }
            else if (replace)
            {
                return this.Slots[index].Replace(item,amount);
            }

            return Enumerable.Repeat(item, amount).ToArray();
        }

        #endregion

        public virtual bool MoveItem(int origin, int target)
        {
            throw new System.NotImplementedException();
        }

        #region Get

        #region index
        public virtual T GetItem(int index)
        {
            if (index > Slots.Length || index < 0)
                return null;

            return Slots[index].GetOne();
        }

        public virtual T[] GetItemAmount(int index, int amount = 1)
        {
            if (index < 0 || index >= Slots.Length) return new T[0];
            return this.Slots[index].GetAmount(amount);
        }

        public T[] GetAll(int index)
        {
            if (index < 0 || index >= Slots.Length) return new T[0];
            return this.Slots[index].GetAll();
        }
        #endregion

        #region item
        public virtual T GetItem(T item)
        {
            for (int i = 0; i < this.Slots.Length; i++)
            {
                if (!this.Slots[i].isEmpty && this.Slots[i].CurrentItem == item)
                {
                    return this.Slots[i].GetOne();
                }
            }
            return null;
        }
        public virtual T[] GetItemAmount(T item, int amount = 1)
        {
            if(amount < 0) return new T[0];

            var currentAmount = amount;
            var itemArr = new T[amount];
            
            for (int i = 0; i < this.Slots.Length; i++)
            {
                if (!this.Slots[i].isEmpty && this.Slots[i].CurrentItem == item)
                {
                    var result = this.Slots[i].GetAmount(currentAmount);
                    result.CopyTo(itemArr, amount-currentAmount);
                    currentAmount -= result.Length;
                }

                if(currentAmount == 0)
                    break;
            }
            return itemArr;
        }

        /// <summary>
        /// Returns the amount of an item (one per slot)
        /// </summary>
        /// <param name="item">item to be searched</param>
        /// <returns></returns>
        public virtual int GetItemCount(T item)
        {
            int amount = 0;
            for (int i = 0; i < this.Slots.Length; i++)
            {
                if (!this.Slots[i].isEmpty && this.Slots[i].CurrentItem == item)
                { 
                    amount++;
                }
            }
            return amount;
        }

        public virtual T[] Clear()
        {
            var list = new List<T>();
            for (int i = 0; i < this.Slots.Length; i++)
            {
                var res = this.Slots[i].GetAll();
                list.AddRange(res);
            }

            return list.ToArray();
        }

        public T[] GetAll(T item)
        {
            var list = new List<T>();

            for (int i = 0; i < this.Slots.Length; i++)
            {
                if (!this.Slots[i].isEmpty && this.Slots[i].CurrentItem == item)
                {
                    var res = this.Slots[i].GetAll();
                    list.AddRange(res);
                }
            }

            return list.ToArray();
        }
        #endregion

        #endregion
    }
}
