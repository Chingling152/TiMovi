using TheChest.Items;
using TheChest.Containers.Generics.Base;
using UnityEngine;

namespace TheChest.Examples.Containers
{
    public class Inventory : BaseInventory<Item>
    {
        protected const string DEFAULT_CONTAINER_NAME = "CONTAINER_NAME";

        [SerializeField]
        private string containerName;
        public string ContainerName => this.containerName;

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
