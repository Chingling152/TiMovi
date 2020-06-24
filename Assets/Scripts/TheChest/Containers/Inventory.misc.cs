using System;

namespace TheChest.Containers
{
    public partial class Inventory
    {
        /// <summary>
        /// Removes all items from inventory
        /// </summary>
        public void Clear()
        {
            Array.Clear(slot, 0, slot.Length);
        }

        [Obsolete("Use AddItemAt w/ GetItem")]
        public bool MoveItem(int from, int to)
        {
            if (from < 0 || from >= slot.Length || slot[from].isEmpty || to < 0 || to >= slot.Length)
                return false;

            //TODO: Logic

            return false;
        }
    }
}
