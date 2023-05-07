namespace TheChest.Containers.Generics.Interfaces
{
    public interface IContainer<T> //: IEnumerable<T>
    {
        /// <summary>
        /// Slots in the Inventory
        /// </summary>
        ISlot<T>[] Slots { get; }

        /// <summary>
        /// Size of the current Inventory
        /// </summary>
        int Size { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        ISlot<T> this[int index] { get; }
    }
}
