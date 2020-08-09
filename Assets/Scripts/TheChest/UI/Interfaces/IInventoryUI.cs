using TheChest.Containers.Generics;

namespace TheChest.UI.Interfaces
{
    public interface IInventoryUI<T,Y> 
        where T : IInventory<Y>
        where Y : class
    {
        /// <summary>
        /// UI's data source
        /// </summary>
        T Inventory { get ; }

        /// <summary>
        /// Generates the inventory slots based on <see cref="Inventory"/>
        /// </summary>
        void GenerateUI();

        /// <summary>
        /// Clear the inventory UI
        /// </summary>
        void ClearUI();
    }
}
