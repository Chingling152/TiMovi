using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TheChest.Containers.Generics.Interfaces;
using TheChest.Slots.Generics.Interfaces;
using TheChest.Slots.Generics.Base;

namespace TheChest.Containers.Generics.Base
{
    public class BaseStackInventory<T> : BaseInventory<T>, IStackInventory<T>, IInteractiveContainer<T>
    {
        [SerializeField]
        protected IStackSlot<T>[] slots;

        public override ISlot<T>[] Slots
        {
            get
            {
                return slots;
            }
            protected set
            {
                slots = value as IStackSlot<T>[]; 
            } 
        }

        public BaseStackInventory(int count) : base(count)
        {
        }

        public BaseStackInventory(IStackSlot<T>[] slots) : base(slots as BaseSlot<T>[])
        {
            this.slots = slots;
        }

        public virtual T[] AddItem(T item, int amount = 1)
        {
            if (amount < 1) 
                return new T[0];

            var itemArr = Enumerable.Repeat(item, amount).ToArray();

            for (int i = 0; i < Slots.Length; i++)
            {
                if (this.Slots[i].IsEmpty || (!this.Slots[i].IsFull && this.Slots[i].CurrentItem.Equals(item)))
                {
                    var result = this.slots[i].Add(item, amount);
                    amount = result;
                    itemArr = Enumerable.Repeat(item, result).ToArray();
                }

                if (itemArr.Length == 0)
                    break;
            }

            return itemArr;
        }

        public virtual T[] AddItem(T[] items)
        {
            if (items == null)
                return new T[0];

            var itemArr = items.Clone() as T[];
            var item = items[0];

            for (int i = 0; i < Slots.Length; i++)
            {
                if (this.Slots[i].IsEmpty || (!this.Slots[i].IsFull && this.Slots[i].CurrentItem.Equals(item)))
                {
                    var result = this.slots[i].Add(itemArr);
                    itemArr = Enumerable.Repeat(item, result).ToArray();
                }

                if (itemArr.Length == 0)
                    break;
            }

            return itemArr;
        }

        public virtual T[] AddItemAt(T item, int index, int amount = 1, bool replace = true)
        {
            if (amount < 1)
                return new T[0];

            if (index < 0 || index >= Slots.Length)
                return Enumerable.Repeat(item, amount).ToArray();

            if (this.Slots[index].IsEmpty || (!this.Slots[index].IsFull && this.Slots[index].CurrentItem.Equals(item)))
            {
                var result = this.slots[index].Add(item, amount);
                return Enumerable.Repeat(item, result).ToArray();
            }
            else if (replace)
            {
                return this.slots[index].Replace(item, amount);
            }

            return Enumerable.Repeat(item, amount).ToArray();
        }

        public virtual T[] AddItemAt(T[] items, int index, bool replace = true)
        {
            if (index < 0 || index >= Slots.Length)
                return items;

            if (items == null)
                return new T[0];

            var item = items.FirstOrDefault();
            var eq = this.Slots[index].CurrentItem?.Equals(item) ?? false;

            if (this.Slots[index].IsEmpty || (!this.Slots[index].IsFull && eq))
            {
                var res = this.slots[index].Add(items);
                return Enumerable.Repeat(item, res).ToArray();
            }
            else if (replace)
            {
                return this.slots[index].Replace(items);
            }
            return items;
        }

        public virtual T[] GetAll(int index)
        {
            if (index < 0 || index >= Slots.Length) 
                return new T[0];

            return this.slots[index].GetAll();
        }

        public virtual T[] GetItemAmount(int index, int amount = 1)
        {
            if (index < 0 || index >= Slots.Length) 
                return new T[0];

            return this.slots[index].GetAmount(amount);
        }
    }
}
