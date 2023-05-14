using System;
using UnityEngine;
using TheChest.Items;
using TheChest.Containers.Generics.Base;
using TheChest.Slots.Generics.Interfaces;

namespace TheChest.Examples.Containers
{
    [Serializable]
    public class Inventory : BaseInventory<Item>
    {
        protected const string DEFAULT_CONTAINER_NAME = "CONTAINER_NAME";

        [SerializeField]
        private string containerName;
        public string ContainerName => this.containerName;

        [SerializeField]
        protected Slot[] slots;

        public override ISlot<Item>[] Slots
        {
            get
            {
                return slots;
            }
            protected set
            {
                slots = value as Slot[];
            }
        }

        public Inventory(int count = DEFAULT_SLOT_COUNT,string containerName = DEFAULT_CONTAINER_NAME) : base(count)
        {
            this.containerName = containerName;
        }

        public Inventory(Slot[] slots, string containerName = DEFAULT_CONTAINER_NAME) : base(slots) 
        {
            this.containerName = containerName;
        }
    }
}
