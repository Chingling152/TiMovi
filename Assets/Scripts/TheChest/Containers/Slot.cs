using System;
using TheChest.Items;
using TheChest.Containers.Generics;

namespace TheChest.Containers
{
    /// <summary>
    /// Slot of an <see cref="IInventory{T}"/>
    /// </summary>
    public class Slot : ISlot<Item>
    {
        public Item CurrentItem { get; protected set; }//TODO: get protected?

        public int StackAmount { get; protected set; }

        public bool isFull => StackAmount >= (CurrentItem?.MaxStack ?? 1);

        public bool isEmpty => CurrentItem == null || StackAmount == 0;

        public Slot(Item CurrentItem = null,int amount = 1)
        {
            this.CurrentItem = CurrentItem;
            this.StackAmount = CurrentItem != null ? amount : 0;
        }

        public bool Add(Item item)
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

        public int Add(Item item, int amount = 1)
        {
            if(amount <1) return 0;

            if (!this.isEmpty && this.CurrentItem != item || this.isFull)
                return amount;
            
            int res = amount - (item.MaxStack - this.StackAmount);

            this.CurrentItem = item;
            this.StackAmount = amount - res;

            return Math.Abs(res);
        }

        public Item[] Replace(Item item, int amount = 1)
        {
            Item[] items = new Item[0];

            if(amount < 1) return items;

            if (this.CurrentItem == item && !this.isFull)
            {
                int resultAmount = this.Add(item,amount);

                items = new Item[resultAmount];

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

        public Item GetOne()
        {
            if (StackAmount < 1)
                return null;

            Item item = this.CurrentItem;

            this.StackAmount--;

            if (StackAmount == 0)
                this.CurrentItem = null;

            return item;
        }

        public Item[] GetAmount(int amount = 1)
        {
            if (amount < 1) return new Item[0];
            if (amount > StackAmount) amount = this.StackAmount;

            Item[] items = new Item[amount];

            for (int i = 0; i < amount; i++)
            {
                this.StackAmount--;
                items[i] = this.CurrentItem;
            }

            if (this.StackAmount == 0) this.CurrentItem = null;

            return items;
        }

        public Item[] GetAll()
        {
            return this.GetAmount(this.StackAmount);
        }
    }
}
