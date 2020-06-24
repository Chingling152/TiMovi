using TheChest.Items;

namespace TheChest.Containers
{
    public class Slot
    {
        public Item CurrentItem { get; private set; }

        protected int StackAmount;

        /// <summary>
        /// Verify if the slot is full of capacity
        /// </summary>
        public bool isFull => StackAmount >= (CurrentItem?.MaxStack ?? 1);

        /// <summary>
        /// Verify if the current slot is empty
        /// </summary>
        public bool isEmpty => CurrentItem == null || StackAmount == 0;

        public Slot(Item CurrentItem = null)
        {
            this.CurrentItem = CurrentItem;
            this.StackAmount = CurrentItem == null ? 0 : 1;
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

        public Item GetOne()
        {
            if (StackAmount < 1)
                return null;

            var item = this.CurrentItem;

            this.StackAmount--;

            if (StackAmount == 0)
                this.CurrentItem = null;

            return item;
        }

        public Item[] GetAmount(int amount = 1)
        {
            if (amount < 1) return new Item[0];//return nothing if amount not equal to 0
            if (amount > StackAmount) amount = this.StackAmount;//amount cannot pass Stack amount

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
