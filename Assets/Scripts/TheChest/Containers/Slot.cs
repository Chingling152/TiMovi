using TheChest.Items;
using TheChest.Containers.Generics;
using UnityEngine;

namespace TheChest.Containers
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

        public override Item CurrentItem {
            get {
                return this.item;
            }
            protected set {
                this.item = value;
            }
        }

        /// <summary>
        /// The maount of the item
        /// </summary>
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

        /// <summary>
        /// Returns the Max amount of <see cref="Item"/> this slot can carry
        /// </summary>
        public override int MaxStackAmount => this.CurrentItem?.MaxStack??1;
        #endregion

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
