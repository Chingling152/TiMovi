﻿using System;
using UnityEngine;
using UnityEngine.UI;
using TheChest.Containers;
using TheChest.UI.Interfaces;
using TheChest.Items;

namespace TheChest.UI
{
    /// <summary>
    /// UI Slot with name, amount and icon
    /// </summary>
    [DisallowMultipleComponent]
    public class UISlot : MonoBehaviour , ISlotUI<Slot,Item>
    {
        #region UI
        [Header("Values")]
        [Tooltip("The Image element wich will render the item sprite")]
        [SerializeField] private Image itemSprite;

        [SerializeField] private Slot slot;

        [Tooltip("The Text element wich will render the item amount")]
        [SerializeField] private Text itemAmount;
        #endregion

        #region Properties
        public Image ItemSprite => itemSprite;

        public int Index { get; protected set; } 
        public int Amount { get; protected set; }

        public bool IsEmpty => this.Amount == 0;

        public event Action<int,int> OnSelectIndex;
        #endregion

        #region Interface Implementations
        public Slot Slot => this.slot;

        public void Select()
        {
            this.OnSelectIndex?.Invoke(this.Index, this.Amount);
        }

        public void SetSlot(Slot slot, int slotIndex)
        {
            this.Index = slotIndex;
            this.Amount = slot.StackAmount;
            this.slot = slot;

            this.SetItem(slot.CurrentItem);
        }

        public void Refresh(Slot slot, bool selected = false)
        {
            this.Amount = slot.StackAmount;
            this.slot = slot;

            this.SetItem(slot.CurrentItem);
            this.ChangeSelected(selected);
        }
        #endregion

        #region Private methods
        private void ChangeSelected(bool selected)
        {
            if (selected)
            {
                this.GetComponent<Image>().color = Color.yellow;
            }
            else
            {
                this.GetComponent<Image>().color = Color.white;
            }
        }

        private void SetItem(Item item)
        {
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
        }
        #endregion
    }
}
