using TheChest.Items;
using TheChest.Containers.Generics;

namespace TheChest.Containers
{
    /// <summary>
    /// Slot with stackable items defined by it's own
    /// </summary>
    public class Slot : BaseSlot<Item>
    {
        /// <summary>
        /// Returns the Max amount of <see cref="Item"/> this slot can carry
        /// </summary>
        public override int MaxStackAmount => this.CurrentItem?.MaxStack??1;

        /// <summary>
        /// Creates an Slot with an Item
        /// </summary>
        /// <param name="CurrentItem">Item inside the slot (can be null)</param>
        /// <param name="amount">Amount of <paramref name="CurrentItem"/> (0 if null)</param>
        public Slot(Item CurrentItem = null,int amount = 1) 
        {
            this.CurrentItem = CurrentItem;
            this.StackAmount = CurrentItem != null ? amount : 0;
        }
    }
}
