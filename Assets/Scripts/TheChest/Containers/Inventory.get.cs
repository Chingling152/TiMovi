using System;
using TheChest.Items;

namespace TheChest.Containers
{
    public partial class Inventory
    {
        /// <summary>
        /// Get and item of an indexed slot
        /// </summary>
        /// <param name="index">Index of the slot</param>
        /// <returns>Returns the item inside the indexed slot</returns>
        public Item GetItem(int index)
        {
            if (index < 0 || index >= slot.Length || slot[index].isEmpty)
                return null;

            return slot[index].GetOne();
        }

        /// <summary>
        /// Finds the first item and returns it
        /// </summary>
        /// <param name="item">The item to be searched</param>
        /// <returns>Returns the item if this was founded</returns>
        public Item GetItem(Item item)
        {
            for (int i = 0; i < slot.Length; i++)
            {
                if (!slot[i].isEmpty && slot[i].CurrentItem == item)
                    return slot[i].GetOne();
            }
            return null;
        }

        /// <summary>
        /// Used to return a slot to UI
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Slot GetSlot(int index)
        {
            if (index > slot.Length || index < 0)
                throw new IndexOutOfRangeException("The index is Out of Slot's Range");

            return slot[index];
        }
    }
}
