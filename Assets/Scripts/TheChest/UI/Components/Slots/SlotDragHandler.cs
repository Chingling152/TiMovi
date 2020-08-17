using UnityEngine;
using UnityEngine.EventSystems;

namespace TheChest.UI.Components.Slots
{
    /// <summary>
    /// Class to handle Drag'n drop on Slot
    /// </summary>
    [RequireComponent(typeof(UISlot))]
    [DisallowMultipleComponent]
    public sealed class SlotDragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
    {
        /// <summary>
        /// Position on screen of the selected item
        /// </summary>
        private Vector2 originalPosition;

        /// <summary>
        /// Event that occour when the slot is clicked
        /// </summary>
        /// <param name="eventData"></param>
        public void OnBeginDrag(PointerEventData eventData)
        {
            if(eventData.button == PointerEventData.InputButton.Left)
            {
                var slot = this.GetComponent<UISlot>();
                this.originalPosition = slot.ItemSprite.rectTransform.position;
                slot.Selected();
            }
        }

        /// <summary>
        /// Event that occour when the item is beeing dragging
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrag(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                var itemSprite = this.GetComponent<UISlot>().ItemSprite;
                itemSprite.rectTransform.position = Input.mousePosition;
            }
        }

        /// <summary>
        /// Event that occour when the item has stopped to be dragged 
        /// </summary>
        /// <param name="eventData"></param>
        public void OnEndDrag(PointerEventData eventData)
        {
            this.GetComponent<UISlot>().ItemSprite.rectTransform.position = originalPosition;
        }

        public void OnDrop(PointerEventData eventData)
        {
            var slot = this.GetComponent<UISlot>();
            slot.Selected();
        }
    }
}
