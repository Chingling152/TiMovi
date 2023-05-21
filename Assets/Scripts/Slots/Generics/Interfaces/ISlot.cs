namespace TheChest.Slots.Generics.Interfaces
{
    /// <summary>
    /// Generic Inventory Slot with item stack
    /// </summary>
    /// <typeparam name="T">Item the Slot Accept</typeparam>
    public interface ISlot<T>
    {
        /// <summary>
        /// The current item inside the slot
        /// </summary>
        T CurrentItem { get; }

        /// <summary>
        /// Verify if the slot is full
        /// </summary>
        bool IsFull { get;}

        /// <summary>
        /// Verify if the current slot is empty
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Add the item in the current Slot
        /// </summary>
        /// <param name="item">The item to be added</param>
        /// <returns>True if the value is successful added</returns>
        bool Add(T item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        T Replace(T item);

        /// <summary>
        /// Returns an item from slot
        /// </summary>
        /// <returns>Returns an item of the slot, if <see cref="IsEmpty"/> returns null</returns>
        T GetOne();
    }
}
