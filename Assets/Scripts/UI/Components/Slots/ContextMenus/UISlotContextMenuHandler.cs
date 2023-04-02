using UnityEngine;
using UnityEngine.EventSystems;
using TheChest.UI.Components.ContextMenus;
using TheChest.UI.Extensions;

namespace TheChest.UI.Components.Slots 
{
    public class UISlotContextMenuHandler : UISlotComponent, IPointerClickHandler
    {
        [SerializeField]private UIContextMenu contextMenuPrefab;
        private UIContextMenu contextMenu;

        new void Start()
        {
            base.Start();
            if (contextMenu == null)
            {
                contextMenu = Instantiate(contextMenuPrefab, slot.transform.parent.parent);
                contextMenu.gameObject.SetActive(false);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if(eventData.button == PointerEventData.InputButton.Right) 
            {
                if (contextMenu.gameObject.activeSelf)
                {
                    contextMenu.gameObject.SetActive(false);
                    return;
                }

                if (!this.slot.IsSelected)
                {
                    this.slot.Select();
                }

                var contextMenuRect = contextMenu.GetComponent<RectTransform>();
                contextMenuRect.localPosition = this.slot.GetComponent<RectTransform>().AdjacentPosition(contextMenuRect);

                contextMenu.gameObject.SetActive(true);
            }
        }
    }
}