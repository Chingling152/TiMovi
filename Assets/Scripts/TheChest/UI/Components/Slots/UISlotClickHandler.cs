using UnityEngine;
using UnityEngine.EventSystems;

namespace TheChest.UI.Components.Slots
{
    /// <summary>
    /// Class to handle Click On Slot
    /// </summary>
    [RequireComponent(typeof(UISlot))]
    [DisallowMultipleComponent]
    public sealed class UISlotClickHandler : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler , IPointerExitHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                this.GetComponent<UISlot>().Selected();
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            //throw new System.NotImplementedException();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            //throw new System.NotImplementedException();
        }
    }
}
