using UnityEngine;
using UnityEngine.EventSystems;
using TheChest.UI.Components.Tooltips;

namespace TheChest.UI.Components.Slots.Tooltips
{
    /// <summary>
    /// 
    /// </summary>
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
            var rect = tooltip.GetComponent<RectTransform>();

            if (!this.slot.Slot.isEmpty)
            {
                var slotRect = slot.GetComponent<RectTransform>();

                var viewPos = Camera.current.WorldToViewportPoint(slotRect.position);

                if (viewPos.x > (Screen.currentResolution.width / 2))//TODO: need fixes
                {
                    rect.position = slotRect.position - new Vector3(-slotRect.rect.width, 0);
                }
                else
                {
                    rect.position = slotRect.position + new Vector3(slotRect.rect.width, 0);
                }

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
