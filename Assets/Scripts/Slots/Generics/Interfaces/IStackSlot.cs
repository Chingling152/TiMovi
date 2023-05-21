﻿namespace TheChest.Slots.Generics.Interfaces
{
    public interface IStackSlot<T> : ISlot<T>
    {
        /// <summary>
        /// Defines the amount of items this slot is holding
        /// </summary>
        int StackAmount { get ; }

        /// <summary>
        /// Defines the max amount of item that this slot can contain
        /// </summary>
        int MaxStackAmount { get; }

        /// <summary>
        /// Add an amount of items inside the current slot
        /// </summary>
        /// <param name="item">The item to be added </param>
        /// <param name="amount">The amount of items added</param>
        /// <returns>Return 0 if all items are fully added to slot , else will return the amount left</returns>
        int Add(T item, int amount);

        /// <summary>
        /// Try adds an array of items inside the current slot
        /// </summary>
        /// <param name="items">array of items to be added</param>
        /// <returns>returns the amount of items that couldn't be added</returns>
        int Add(T[] items);

        /// <summary>
        /// Remove the current item of Slot and replace by a new one
        /// </summary>
        /// <param name="item">The item wich will replace the old one</param>
        /// <param name="amount">The amount of the New item</param>
        /// <returns>Returns an array of the old item</returns>
        T[] Replace(T item, int amount);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        T[] Replace(T[] items);

        /// <summary>
        /// Returns an array of item from slot
        /// </summary>
        /// <param name="amount">The amount of items to be returned</param>
        /// <returns>Returns an array from slot or an empty array if <see cref="IsEmpty"/> </returns>
        T[] GetAmount(int amount);

        /// <summary>
        /// Clear the slot and return all this items
        /// </summary>
        /// <returns>Returns all item from slot</returns>
        T[] GetAll();
    }
}
