using System;
using UnityEngine;
using UnityEngine.UI;
using TheChest.Containers;

namespace TheChest.UI
{
    //TODO: fix UI Layer
    [DisallowMultipleComponent]
    public class UISlot : MonoBehaviour//TODO : BaseUISlot
    {
        //TODO: https://www.youtube.com/watch?v=wYkzeKghjsI maybe (?)
        [Header("Values")]
        [Tooltip("The Image element wich will render the item sprite")]
        [SerializeField]
        private Image itemSprite;

        [Tooltip("The Text element wich will render the item amount")]
        [SerializeField]
        private Text itemAmount;

        public Image ItemSprite => itemSprite;

        public int Index { get; protected set; } 
        public int Amount { get; protected set; }

        public bool IsEmpty => this.Amount == 0;

        public event Action<int,int> OnSelectIndex;

        public void SetSlot(Slot slot, int slotIndex,bool selected = false)
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

            //TODO : Set selected
            if(selected)
                this.GetComponent<Image>().color = Color.yellow;
            else
                this.GetComponent<Image>().color = Color.white;

            this.Index = slotIndex;
            this.Amount = slot.StackAmount;
        }

        public void Selected()
        {
            this.OnSelectIndex?.Invoke(this.Index, this.Amount);
        }

        public void Selected(int index, int amount = 1)
        {
            this.OnSelectIndex?.Invoke(Index, amount);
        }
    }
}
