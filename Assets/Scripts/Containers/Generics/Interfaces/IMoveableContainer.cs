namespace TheChest.Containers.Generics.Interfaces
{
    public interface IMoveableContainer<T> : IContainer<T>
    {
        /// <summary>
        /// Move a item between two slots
        /// </summary>
        /// <param name="origin">Selected item</param>
        /// <param name="target">Where the item will be placed</param>
        /// <returns>Returns true if the object can be changed</returns>
        bool MoveItem(int origin, int target);

        /// <summary>
        /// Returns every item from inventory
        /// </summary>
        /// <returns>Returns an Array of <see cref="{T}"/></returns>
        T[] Clear();
    }
}
