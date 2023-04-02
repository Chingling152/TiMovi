using UnityEngine;
using UnityEngine.EventSystems;
using TheChest.UI.Components.Tooltips;
using TheChest.UI.Extensions;

namespace TheChest.UI.Components.Slots.Tooltips
{
    [DisallowMultipleComponent]
    public class UISlotTooltipHandler : UISlotComponent, IPointerEnterHandler, IPointerExitHandler
    {
        private static UITooltip tooltip;

        [SerializeField]private UITooltip tooltipPrefab;

        new void Start()
        {
            base.Start();
            if (tooltip == null)
            {
                tooltip = Instantiate(tooltipPrefab, slot.transform.parent.parent);
                tooltip.gameObject.SetActive(false);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!this.slot.Slot.isEmpty && Camera.current != null)
            {
                var tooltipRect = tooltip.GetComponent<RectTransform>();
                tooltipRect.localPosition = slot.GetComponent<RectTransform>().AdjacentPosition(tooltipRect);

                tooltip.gameObject.SetActive(true);
                tooltip.ShowItem(this.slot.Slot.CurrentItem);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tooltip.gameObject.SetActive(false);
        }
    }
}
