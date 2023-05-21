using System.Collections.Generic;
using System.Linq;
using TheChest.Containers.Generics.Interfaces;
using TheChest.Slots.Generics.Base;

namespace TheChest.Containers.Generics.Base
{
    /// <summary>
    /// Generic Inventory with <see cref="IInventory{T}"/> implementation
    /// </summary>
    /// <typeparam name="T">An item type</typeparam>
    public abstract class BaseInventory<T> : BaseContainer<T>, IInventory<T> //, IStackContainer<T>
    {
        /// <summary>
        /// Creates an Inventory with slots
        /// </summary>
        /// <param name="slots">An array of slots</param>
        public BaseInventory(BaseSlot<T>[] slots) : base(slots)
        {
            this.Slots = slots;
        }

        /// <summary>
        /// Creates an Inventory with a number of slots
        /// </summary>
        /// <param name="count">Sets the amount of slots (20 if not set)</param>
        public BaseInventory(int count) : base(count)
        {
            if (count <= 0)
            {
                count = DEFAULT_SLOT_COUNT;
            }

            this.Slots = new BaseSlot<T>[count];
            this.FillSlots();
        }

        protected virtual void FillSlots()
        {
            for (int i = 0; i < this.Slots.Length; i++)
            {
                this.Slots[i] = new BaseSlot<T>();
            }
        }

        public bool AddItem(T item)
        {
            throw new System.NotImplementedException();
        }

        public T AddItemAt(T item, int index, bool replace = true)
        {
            throw new System.NotImplementedException();
        }

        public virtual bool MoveItem(int origin, int target)
        {
            var oldItem = this.GetItem(origin);
            var res = this.AddItemAt(oldItem, target);
            this.AddItemAt(res, origin);
            return true;
        }

        public virtual T GetItem(int index)
        {
            if (index > Slots.Length || index < 0)
                return default;

            return Slots[index].GetOne();
        }

        public virtual T GetItem(T item)
        {
            for (int i = 0; i < this.Slots.Length; i++)
            {
                if (!this.Slots[i].IsEmpty && this.Slots[i].CurrentItem.Equals(item))
                {
                    return this.Slots[i].GetOne();
                }
            }
            return default;
        }

        public virtual T[] GetItemAmount(T item, int amount = 1)
        {
            if (amount < 0) 
                return new T[0];

            var itemArr = new T[amount];

            var currentAmount = amount;
            var index = 0;

            //TODO: optimize the for loops
            for (int i = 0; i < this.Slots.Length; i++)
            {
                if (currentAmount == 0)
                    break;

                if (!this.Slots[i].IsEmpty && this.Slots[i].CurrentItem.Equals(item))
                {
                    var obj = this.Slots[i].GetOne();
                    itemArr[index] = obj;
                    index++;
                    currentAmount--;
                }
            }
            return itemArr.Take(index).ToArray();
        }

        public virtual int GetItemCount(T item)
        {
            int amount = 0;
            for (int i = 0; i < this.Slots.Length; i++)
            {
                if (!this.Slots[i].IsEmpty && this.Slots[i].CurrentItem.Equals(item))
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
                if (!this.Slots[i].IsEmpty)
                {
                    var res = this.Slots[i].GetOne();
                    list.Add(res);
                }
            }

            return list.ToArray();
        }

        public virtual T[] GetAll(T item)
        {
            var list = new List<T>();

            for (int i = 0; i < this.Slots.Length; i++)
            {
                if (!this.Slots[i].IsEmpty && this.Slots[i].CurrentItem.Equals(item))
                {
                    var res = this.Slots[i].GetOne();
                    list.Add(res);
                }
            }

            return list.ToArray();
        }
    }
}
