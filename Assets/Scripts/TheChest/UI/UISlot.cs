using System;
using TheChest.Containers;
using TheChest.Items;
using UnityEngine;
using UnityEngine.UI;

namespace TheChest.UI
{
    [DisallowMultipleComponent]
    public class UISlot : MonoBehaviour
    {
        [SerializeField]
        private Image itemSprite;

        [SerializeField]
        private Text itemAmount;

        public Image ItemSprite => itemSprite;

        public Slot Slot { get; protected set; }

        //https://www.youtube.com/playlist?list=PLm7W8dbdfloj4CWX8RS5_cnDWVn1Q6u9Q
        public int Index { get; private set; }
        public int Amount { get; private set; }

        public Action<Item,int> OnSelectItem;
        public Action<int,int> OnSelectIndex;

        public void SetSlot(Slot slot, int slotIndex)
        {
            var item = slot.CurrentItem;

            if (item != null)
            {
                this.itemAmount.text = slot.StackAmount == 0 ? string.Empty : slot.StackAmount.ToString();
                this.itemSprite.sprite = item.Image;
            }
            else
            {
                this.itemAmount.text = string.Empty;
                this.itemSprite.sprite = null;
            }
            this.Index = slotIndex;
            this.Amount = slot.StackAmount;
        }
    }
}
