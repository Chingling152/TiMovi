using UnityEngine;
using TheChest.Slots.Generics.Base;
using TheChest.Examples.Items;

namespace TheChest.Examples.Containers
{
    /// <summary>
    /// Slot with stackable items and serializable Fields
    /// </summary>
    [System.Serializable]
    public class StackSlot : BaseStackSlot<Item>
    {
        #region properties
        /// <summary>
        /// Current item inside the slot
        /// </summary>
        [SerializeField]
        private Item item;

        public override Item CurrentItem {
            get {
                return this.item;
            }
            protected set {
                this.item = value;
            }
        }

        [SerializeField]
        private int stackAmount;

        public override int StackAmount {
            get {
                return this.stackAmount;
            }
            protected set {
                this.stackAmount = value;
            }
        }

        public override int MaxStackAmount => this.CurrentItem?.MaxStack??1;
        #endregion

        /// <summary>
        /// Creates an Slot with an Item
        /// </summary>
        /// <param name="CurrentItem">Item inside the slot (can be null)</param>
        /// <param name="amount">Amount of <paramref name="CurrentItem"/> (0 if item is null)</param>
        public StackSlot(Item CurrentItem = null,int amount = 1) 
        {
            this.CurrentItem = CurrentItem;
            this.StackAmount = CurrentItem != null ? amount : 0;
        }

        /// <summary>
        /// Creates an Slot with items
        /// </summary>
        /// <param name="currentItems">Items inside the slot (should be copies of first item)</param>
        public StackSlot(Item[] currentItems)
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
