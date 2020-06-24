using UnityEngine;

namespace TheChest.Containers
{
    /// <summary>
    /// Inventory to store Items
    /// </summary>
    public partial class Inventory 
    {
        [SerializeField]
        private Slot[] slot;

        public int Size => slot.Length;

        public const int DEFAULT_SLOT_COUNT = 20;

        Inventory()
        {
            this.slot = new Slot[DEFAULT_SLOT_COUNT];
        }

        Inventory(int size)
        {
            if(size <= 0) size = 0;
            this.slot = new Slot[size];
        }

        Inventory(Slot[] slots)
        {
            this.slot = slots;
        }
    }
}
