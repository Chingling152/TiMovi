using UnityEngine;
using UnityEngine.EventSystems;

namespace TheChest.UI.Components.Slots
{
    [RequireComponent(typeof(UISlot))]
    [DisallowMultipleComponent]
    public sealed class ClickHandler : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler , IPointerExitHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                var slot = this.GetComponent<UISlot>();
                slot.OnSelectIndex?.Invoke(slot.Index,slot.Amount);
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
