using TheChest.UI;

namespace TheChest.World
{
    public static class InventoryManager
    {
        private static UIInventory playerInventory;

        public static UIInventory PlayerInventory { 
            get => playerInventory;
            set {
                if(playerInventory == null)
                {
                    playerInventory = value;
                }
            }
        }
        //public static List<Inventory> Inventories { get ; private set;}

        //static InventoryManager()
        //{
        //    Inventories = new List<Inventory>();
        //}
        //public static event Action<Inventory,Item> OnInventoryGetItem;

        //public static event Action<Inventory,Item,Inventory> OnInventoryTransfeerItem;
    }
}
