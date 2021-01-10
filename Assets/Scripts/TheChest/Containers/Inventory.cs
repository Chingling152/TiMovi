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

        /// <summary>
        /// Slots of the <see cref="Inventory"/>
        /// </summary>
        public override ISlot<Item>[] Slots { 
            get{
                return slots;
            } 
            protected set {
                slots = value as Slot[];
            }
        }

        /// <summary>
        /// Amount of slots of the inventory
        /// </summary>
        public override int Size => this.Slots.Length;

        /// <summary>
        /// Gets an Inventyory Slot
        /// </summary>
        /// <param name="index">index of the index</param>
        /// <returns>Returns an Slot from Inventory</returns>
        public ISlot<Item> this[int index] {
            get {
                if (index > slots.Length || index < 0)
                    return null;

                return this.slots[index];
            }
        }

        #region Constructors
        /// <summary>
        /// Default constructor : creates an inventory of size of <see cref="BaseInventory{T}.DEFAULT_SLOT_COUNT"/>
        /// </summary>
        public Inventory(string name = "Container") : base() { 
            this.ContainerName = name;
            this.slots = new Slot[DEFAULT_SLOT_COUNT];
            this.FillSlots();
        }

        /// <summary>
        /// Creates a inventory with defined slots
        /// </summary>
        /// <param name="size">Amount of slots</param>
        public Inventory(int size, string name = "Container") : base(size)
        {
            if(size <= 0)
            {
                size = DEFAULT_SLOT_COUNT;
            }

            this.ContainerName = name;
            this.slots = new Slot[size];
            this.FillSlots();
        }

        /// <summary>
        /// Creates an inventory and sets it's slots
        /// </summary>
        /// <param name="slots">Preset slot array</param>
        public Inventory(Slot[] slots, string name = "Container") : base(slots)
        {
            this.ContainerName = name;
            this.slots = slots;
        }
        /// <summary>
        /// Fills the null slot with empty ones
        /// </summary>
        protected override void FillSlots()
        {
            for (int i = 0; i < this.Slots.Length; i++)
            {
                this.Slots[i] = new Slot();
            }
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
