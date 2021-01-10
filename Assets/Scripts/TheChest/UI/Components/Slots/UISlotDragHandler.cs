using UnityEngine;
using UnityEngine.EventSystems;

namespace TheChest.UI.Components.Slots
{
    /// <summary>
    /// Class to handle Drag'n drop on Slot
    /// </summary>
    [RequireComponent(typeof(UISlot))]
    [DisallowMultipleComponent]
    public sealed class UISlotDragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
    {
        /// <summary>
        /// Position on screen of the selected item
        /// </summary>
        private Vector2 originalPosition;
        private UISlot component;

        void Start()
        {
            component = this.GetComponent<UISlot>();
        }

        /// <summary>
        /// Event that occour when the slot is clicked
        /// </summary>
        /// <param name="eventData"></param>
        public void OnBeginDrag(PointerEventData eventData)
        {
            if(eventData.button == PointerEventData.InputButton.Left)
            {
                this.originalPosition = component.ItemSprite.rectTransform.position;
                component.Select();
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
                component.ItemSprite.rectTransform.position = Input.mousePosition;
            }
        }

        /// <summary>
        /// Event that occour when the item has stopped to be dragged 
        /// </summary>
        /// <param name="eventData"></param>
        public void OnEndDrag(PointerEventData eventData)
        {
            component.ItemSprite.rectTransform.position = originalPosition;
        }

        public void OnDrop(PointerEventData eventData)
        {
            component.Select();
        }
    }
}
