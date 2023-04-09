using TheChest.Containers.Generics;

namespace TheChest.UI.Interfaces
{
    /// <summary>
    /// Interface with method of an Slot
    /// </summary>
    /// <typeparam name="T">Valid inventory interface</typeparam>
    /// <typeparam name="Y">Any value stored on <see cref="IInventory{Y}"/> </typeparam>
    public interface IInventoryUI<Y>
    {
        #region Properties
        /// <summary>
        /// The current and selected slot index
        /// </summary>
        int SelectedIndex { get ; }
        #endregion

        #region Actions
        /// <summary>
        /// Selects an item on a index of the inventory
        /// </summary>
        /// <param name="index">Index of the slot</param>
        /// <param name="amount">Amount of items</param>
        void SelectItem(int index, int amount = 1);

        /// <summary>
        /// Adds an item to the dictionary
        /// </summary>
        /// <param name="item">Item added</param>
        /// <param name="amount">Amount added</param>
        /// <returns>Returns true if sucessfully added</returns>
        bool Add(Y item, int amount = 1);

        /// <summary>
        /// Drops an Item of the Inventory
        /// </summary>
        void Drop();
        #endregion

        #region UI Changes
        /// <summary>
        /// Generates the inventory slots based on <see cref="Inventory"/>
        /// </summary>
        void Generate();

        /// <summary>
        /// Refreshs the already created data on slots
        /// </summary>
        void Refresh();

        /// <summary>
        /// Clear the inventory UI
        /// </summary>
        void Clear();
        #endregion
    }
}
