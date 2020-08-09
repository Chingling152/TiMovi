namespace TheChest.Containers.Generics
{
    /// <summary>
    /// Default interface to Inventory
    /// </summary>
    /// <typeparam name="T">The item this inventory accepts</typeparam>
    public interface IInventory<T>
    {
        #region Properties
        /// <summary>
        /// Slots in the Inventory
        /// </summary>
        ISlot<T>[] Slots { get; }

        /// <summary>
        /// Size of the current Inventory
        /// </summary>
        int Size { get; }
        #endregion

        #region get

        /// <summary>
        /// Gets an <see cref="item"/> inside a slot
        /// </summary>
        /// <param name="index">Slot's inventory to be searched</param>
        /// <returns>Returns the item inside <paramref name="index"/> Slot</returns>
        T GetItem(int index);

        /// <summary>
        /// Returns an amount of items inside the Inventory Slot
        /// </summary>
        /// <param name="index">Index of the slot</param>
        /// <param name="amount">Amount of the item to be returned</param>
        /// <returns>Returns the amount of items inside the slot (or the max it can)</returns>
        T[] GetItemAmount(int index,int amount = 1);
        
        /// <summary>
        /// Returns all the items from the selected slot 
        /// </summary>
        /// <param name="index">Index of the slot</param>
        /// <returns>An array with of items</returns>
        T[] GetAll(int index);

        /// <summary>
        /// Search an Item from inventory
        /// </summary>
        /// <param name="item">The item to be searched</param>
        /// <returns>Returns the first item founded</returns>
        T GetItem(T item);

        /// <summary>
        /// Search an amount of items in the inventory
        /// </summary>
        /// <param name="item">Item to be founded</param>
        /// <param name="amount">Amount to be returned</param>
        /// <returns>Returns the amount of items searched (or the max it can)</returns>
        T[] GetItemAmount(T item, int amount = 1);

        T[] GetAll(T item);

        /// <summary>
        /// Returns the amount of an item inside the inventory
        /// </summary>
        /// <param name="item">The item to de counted</param>
        /// <returns>Returns the current amount of the item in the Inventory</returns>
        int GetItemCount(T item);
        #endregion

        #region add

        /// <summary>
        /// Adds an amount of item in a avaliable <see cref="ISlot{T}"/> 
        /// </summary>
        /// <param name="item">item to be added</param>
        /// <param name="amount">amount of the item added</param>
        /// <returns>returns the items that could'nt be added</returns>
        T[] AddItem(T item,int amount = 1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        T[] AddItem(T[] items); 

        /// <summary>
        /// Adds an amount of item in a specific slot
        /// </summary>
        /// <param name="item">item to be added</param>
        /// <param name="index">slot where the item will be added</param>
        /// <param name="amount">amount of the item</param>
        /// <param name="replace"></param>
        /// <returns>Returns the item that couldn't be added or the replaced items</returns>
        T[] AddItemAt(T item, int index, int amount = 1, bool replace = true);

        /// <summary>
        /// Adds an array of item inside the inventory
        /// </summary>
        /// <param name="items">Array of item of the same type wich will be added to inventory</param>
        /// <param name="index">Wich slot the items will be added</param>
        /// <param name="replace">Defines if the current Slot item will be replaced by the <see cref="items"/> param</param>
        /// <returns>Returns a array of items replaced or could'nt be added</returns>
        T[] AddItemAt(T[] items, int index, bool replace = true);
        #endregion

        #region misc

        /// <summary>
        /// Move a item between two slots
        /// </summary>
        /// <param name="origin">Selected item</param>
        /// <param name="target">Where the item will be placed</param>
        /// <returns>Returns true if the object can be changed</returns>
        bool MoveItem(int origin,int target);

        /// <summary>
        /// Returns every item from inventory
        /// </summary>
        /// <returns>Returns an Array of <see cref="{T}"/></returns>
        T[] Clear();
        #endregion
    }
}
