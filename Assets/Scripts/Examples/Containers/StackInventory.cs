using UnityEngine;
using TheChest.Containers.Generics.Base;
using TheChest.Examples.Items;
using TheChest.Slots.Generics.Interfaces;

namespace TheChest.Examples.Containers
{
    public class StackInventory : BaseStackInventory<Item>
    {
        [SerializeField]
        protected InventoryStackSlot[] slots;

        public override ISlot<Item>[] Slots
        {
            get
            {
                return slots;
            }
            protected set
            {
                slots = value as InventoryStackSlot[];
            }
        }

        public StackInventory(int count) : base(count)
        {
        }

        public StackInventory(InventoryStackSlot[] slots) : base(slots)
        {
        }
    }
}
