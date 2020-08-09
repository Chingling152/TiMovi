using UnityEngine;
using UnityEngine.UI;
using TheChest.Containers;
using TheChest.Items;
using TheChest.World;
using System.Collections.Generic;
using System;

namespace TheChest.UI
{
    [DisallowMultipleComponent]
    public class UIInventory : MonoBehaviour
    {
        [Header("Inventory stats")]

        [SerializeField]
        private Inventory inventory;

        [Header("UI Components")]

        [SerializeField]
        private Text containerName;

        [SerializeField]
        private GameObject slotContainer;

        [SerializeField]
        private UISlot slotPrefab;

        private int selectedSlot;
        private int selectedAmount;

        //[Header("Slots")]
        //[SerializeField]
        //private List<UISlot> slots;

        /// <summary>
        /// Defines the inventory and trigger the <see cref="GenerateUI"/> method
        /// </summary>
        public Inventory Inventory {
            set {
                inventory = value;
                this.GenerateUI();
            }
        }

        private void Awake()
        {
            this.GenerateUI();
        }

        public bool Add(Item item)
        {
            var added = this.inventory.AddItem(item);
            RefreshUI();
            return added.Length == 0;
        }

        public void GenerateUI()
        {
            this.ClearUI();
            if (this.containerName != null)
                this.containerName.text = this.inventory?.ContainerName;

            if (this.slotContainer != null && this.slotPrefab != null)
            {
                for (int i = 0; i < inventory.Size; i++)
                {
                    UISlot container = Instantiate(slotPrefab, slotContainer.transform);
                    container.SetSlot(this.inventory.Slots[i], i);
                    container.OnSelectIndex += this.AddItem;
                }
            }
        }

        private void AddItem(int index, int amount = 1)
        {
            if (selectedSlot == index)
            {
                selectedSlot = -1;
                selectedAmount = 0;
                return;
            }

            if(selectedSlot != -1)
            {
                this.inventory.MoveItem(selectedSlot,index);
                this.RefreshUI();
            }
            else
            {
                selectedSlot = index;
                selectedAmount = amount;
            }
        }

        public void RefreshUI()
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                var container = this.transform.GetChild(i).GetComponent<UISlot>();
                container.SetSlot(this.inventory.Slots[i], i);
            }
        }

        public void ClearUI()
        {
            this.containerName.text = "";

            foreach (var item in this.transform.GetComponentsInChildren<UISlot>())
            {
                Destroy(item);
            }
        }

        public void SelectItem(Item item)
        {

        }
    }
}
