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

        int SelectedIndex { get ; }

        /// <summary>
        /// Generates the inventory slots based on <see cref="Inventory"/>
        /// </summary>
        void Generate();

        void Refresh();

        void Drop();

        void SelectItem(int index);

        /// <summary>
        /// Clear the inventory UI
        /// </summary>
        void Clear();
    }
}
