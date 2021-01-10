using System;
using TheChest.Containers.Generics;

namespace TheChest.UI.Interfaces
{
    /// <summary>
    /// Interface slot to UISlot
    /// </summary>
    /// <typeparam name="T">Any ISlot implementation</typeparam>
    /// <typeparam name="Y">Any data stored on <see cref="ISlot{Y}"/> </typeparam>
    public interface ISlotUI<T,Y> where T : ISlot<Y>
    {
        #region Properties
        /// <summary>
        /// Index of the current Index
        /// </summary>
        int Index { get; }

        /// <summary>
        /// Slot data
        /// </summary>
        T Slot { get ; }

        /// <summary>
        /// Amount of item inside the Slot
        /// </summary>
        int Amount { get; }

        /// <summary>
        /// Defines if the current slot is empty
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Event dispatch when the current slot is selected 
        /// first int : index of the slot 
        /// second int : amount on the slot
        /// </summary>
        event Action<int, int> OnSelectIndex;
        #endregion

        #region Methods
        /// <summary>
        /// Set basic info about the slot
        /// </summary>
        /// <param name="slot">slot data</param>
        /// <param name="slotIndex">slot index on inventory</param>
        void SetSlot(T slot, int slotIndex);

        /// <summary>
        /// Refresh slot data based on the slot
        /// </summary>
        /// <param name="slot">New slot data</param>
        /// <param name="selected">Defines if the current slot is selected</param>
        void Refresh(T slot, bool selected = false);

        /// <summary>
        /// Selects the current slot
        /// </summary>
        void Select();
        #endregion
    }
}
