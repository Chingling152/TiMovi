using TheChest.Items;

namespace TheChest.Containers
{
    public partial class Inventory
    {
        /// <summary>
        /// Add an item to inventory (if exists, try stacks)
        /// </summary>
        /// <param name="item">the item to be added to inventory</param>
        /// <returns>Returns true if the item was sucessful added</returns>
        public bool AddItem(Item item)
        {
            int empty = -1;
            for (int i = 0; i < slot.Length; i++)
            {
                // If the current item is equal and the slot isn't full
                if (slot[i].CurrentItem == item && !slot[i].isFull)
                    return slot[i].Add(item); 

                // Search a empty slot
                if (slot[i].isEmpty && empty == -1)
                    empty = i;
            }

            if (empty != -1)
            {// Add to a empty slot if the item isn't in some slot
                slot[empty] = new Slot(item);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Add a range of itens in a inventory
        /// </summary>
        /// <param name="item">The item to be added</param>
        /// <param name="amount">The amount of items to be added</param>
        /// <returns>Returns the remain of items if there's no space</returns>
        public int AddRange(Item item, int amount = 1)
        {
            if (amount < 1) return amount;

            int result = amount;

            while (result > 0)
            {
                if (AddItem(item))
                    result--;
                else
                    return result;
            }

            return result;
        }

        [System.Obsolete("Needs upgrade")]
        public bool AddItemAt(Item item, int index)
        {
            if (index < 0 || index >= slot.Length) return false;

            if (
                this.slot[index].isEmpty || //case the slot is empty
                (!this.slot[index].isFull && this.slot[index].CurrentItem == item) //or has space for an item of this time
            )
            {
                this.slot[index].Add(item);
                return true;
            }

            return false;
        }
    }
}
