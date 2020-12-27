using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TheChest.UI.Components
{
    public class DropArea : MonoBehaviour, IDropHandler
    {
        public Action OnDropItem;

        public void OnDrop(PointerEventData eventData)
        {
            this.OnDropItem?.Invoke();
        }
    }
}
