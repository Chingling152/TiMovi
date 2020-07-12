using TheChest.Items;
using TheChest.Containers.Generics;

namespace TheChest.Containers
{
    /// <summary>
    /// Inventory to store stackable Items and move functionalities
    /// </summary>
    public class Inventory : BaseInventory<Item>
    {
        /// <summary>
        /// Slots of this inventory
        /// </summary>
        public virtual new Slot[] Slots { get; protected set; }

        #region Constructors
        /// <summary>
        /// Default constructor : creates an inventory of size of <see cref="BaseInventory{T}.DEFAULT_SLOT_COUNT"/>
        /// </summary>
        public Inventory() : base() { }

        /// <summary>
        /// Creates a inventory with defined slots
        /// </summary>
        /// <param name="size">Amount of slots</param>
        public Inventory(int size): base(size) { }

        /// <summary>
        /// Creates an inventory and sets it's slots
        /// </summary>
        /// <param name="slots">Preset slot array</param>
        public Inventory(BaseSlot<Item>[] slots) : base(slots) { }
        #endregion

        /// <summary>
        /// Count the amount of items in stackable slots
        /// </summary>
        /// <param name="item">item to be searched</param>
        /// <returns>return how many of this item have in the <see cref="Inventory"/></returns>
        public override int GetItemCount(Item item)
        {
            int amount = 0;
            for (int i = 0; i < this.Slots.Length; i++)
            {
                if (!this.Slots[i].isEmpty && this.Slots[i].CurrentItem == item)
                {
                    amount+= this.Slots[i].StackAmount;
                }
            }
            return amount;
        }
    }
}
