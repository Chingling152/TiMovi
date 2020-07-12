namespace TheChest.Containers.Generics
{
    /// <summary>
    /// Generic Inventory Slot with item stack
    /// </summary>
    /// <typeparam name="T">Item the Slot Accept</typeparam>
    public interface ISlot<T>
    {
        #region Properties
        /// <summary>
        /// The current item inside the slot
        /// </summary>
        T CurrentItem { get; }

        /// <summary>
        /// Verify if the slot is full
        /// </summary>
        bool isFull { get;}

        /// <summary>
        /// Verify if the current slot is empty
        /// </summary>
        bool isEmpty { get; }
        #endregion

        #region add
        /// <summary>
        /// Add the item in the current Slot
        /// </summary>
        /// <param name="item">The item to be added</param>
        /// <returns>True if the value is successful added</returns>
        bool Add(T item);

        /// <summary>
        /// Add an amount of items inside the current slot
        /// </summary>
        /// <param name="item">The item to be added </param>
        /// <param name="amount">The amount of items added</param>
        /// <returns>Return 0 if all items are fully added to slot , else will return the amount left</returns>
        int Add(T item, int amount = 1);
        #endregion

        #region replace
        /// <summary>
        /// Remove the current item of Slot and replace by a new one
        /// </summary>
        /// <param name="item">The item wich will replace the old one</param>
        /// <param name="amount">The amount of the New item</param>
        /// <returns>Returns an array of the old item</returns>
        T[] Replace(T item, int amount = 1);
        #endregion

        #region get
        /// <summary>
        /// Returns an item from slot
        /// </summary>
        /// <returns>Returns an item of the slot, if <see cref="isEmpty"/> returns null</returns>
        T GetOne();

        /// <summary>
        /// Returns an array of item from slot
        /// </summary>
        /// <param name="amount">The amount of items to be returned</param>
        /// <returns>Returns an array from slot or an empty array if <see cref="isEmpty"/> </returns>
        T[] GetAmount(int amount = 1);

        /// <summary>
        /// Clear the slot and return all this items
        /// </summary>
        /// <returns>Returns all item from slot</returns>
        T[] GetAll();
        #endregion
    }
}
