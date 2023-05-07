using UnityEngine;
using TheChest.Items;
using TheChest.Containers.Generics.Base;

namespace TheChest.Examples.Containers
{
    /// <summary>
    /// Slot with stackable items and serializable Fields
    /// </summary>
    [System.Serializable]
    public class Slot : BaseSlot<Item>
    {
        #region properties
        /// <summary>
        /// Current item inside the slot
        /// </summary>
        [SerializeField]
        private Item item;

        /// <summary>
        /// Current item inside the slot
        /// </summary>
        public override Item CurrentItem {
            get {
                return this.item;
            }
            protected set {
                this.item = value;
            }
        }

        /// <summary>
        /// The amount of the item inside this slot
        /// </summary>
        [SerializeField]
        private int stackAmount;

        /// <summary>
        /// The amount of the item inside this slot
        /// </summary>
        public override int StackAmount {
            get {
                return this.stackAmount;
            }
            protected set {
                this.stackAmount = value;
            }
        }

        /// <summary>
        /// Returns the Max amount of <see cref="Item"/> this slot can carry
        /// </summary>
        public override int MaxStackAmount => this.CurrentItem?.MaxStack??1;
        #endregion

        /// <summary>
        /// Creates an Slot with an Item
        /// </summary>
        /// <param name="CurrentItem">Item inside the slot (can be null)</param>
        /// <param name="amount">Amount of <paramref name="CurrentItem"/> (0 if item is null)</param>
        public Slot(Item CurrentItem = null,int amount = 1) 
        {
            this.CurrentItem = CurrentItem;
            this.StackAmount = CurrentItem != null ? amount : 0;
        }

        /// <summary>
        /// Creates an Slot with items
        /// </summary>
        /// <param name="currentItems">Items inside the slot (should be copies of first item)</param>
        public Slot(Item[] currentItems)
        {
            if(currentItems == null)
            {
                this.CurrentItem = null;
                this.StackAmount = 0;
            }
            else
            {
                this.CurrentItem = currentItems[0];
                this.StackAmount = currentItems.Length;
            }
        }
    }
}
