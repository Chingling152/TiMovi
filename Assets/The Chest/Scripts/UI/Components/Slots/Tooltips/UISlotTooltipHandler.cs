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
            var tooltipRect = tooltip.GetComponent<RectTransform>();

            if (!this.slot.Slot.isEmpty && Camera.current != null)
            {
                var slotRect = slot.GetComponent<RectTransform>();

                if (slotRect.transform.position.x > Camera.current.pixelWidth / 2)
                {
                    //TODO : use Vector3.left
                    //TODO : avoid using tooltipRect.rect (instead use someting releated to the pivot)
                    Debug.Log("LEFT");
                    tooltipRect.position = slotRect.position - new Vector3(tooltipRect.rect.width + slotRect.rect.width , 0);
                }
                else
                {
                    Debug.Log("RIGHT");
                    tooltipRect.position = slotRect.position + new Vector3(slotRect.rect.width / 2, 0);
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
