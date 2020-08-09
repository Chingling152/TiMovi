using UnityEngine;
using TheChest.Items;
using TheChest.Containers.Generics;

namespace TheChest.Containers
{
    /// <summary>
    /// Inventory to store stackable Items and serializable variables
    /// </summary>
    [System.Serializable]
    public class Inventory : BaseInventory<Item>
    {
        /// <summary>
        /// Displayed name of inventory
        /// </summary>
        [SerializeField]
        protected string containerName;

        /// <summary>
        /// Displayed name of inventory
        /// </summary>
        public virtual string ContainerName {
            get {
                return this.containerName;
            }
            protected set {
                this.containerName = value;
            }
        }

        [SerializeField]
        protected Slot[] slots;

        public override ISlot<Item>[] Slots { 
            get{
                return slots;
            } 
            protected set {
                slots = (Slot[])value;
            }
        }

        public override int Size => this.Slots.Length;

        #region Constructors
        /// <summary>
        /// Default constructor : creates an inventory of size of <see cref="BaseInventory{T}.DEFAULT_SLOT_COUNT"/>
        /// </summary>
        public Inventory(string name = "Container") : base() { 
            this.ContainerName = name;
        }

        /// <summary>
        /// Creates a inventory with defined slots
        /// </summary>
        /// <param name="size">Amount of slots</param>
        public Inventory(int size, string name = "Container") : base(size)
        {
            this.ContainerName = name;
        }

        /// <summary>
        /// Creates an inventory and sets it's slots
        /// </summary>
        /// <param name="slots">Preset slot array</param>
        public Inventory(Slot[] slots, string name = "Container") : base(slots)
        {
            this.ContainerName = name;
        }
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
                    amount+= this.slots[i].StackAmount;
                }
            }
            return amount;
        }
    }
}
