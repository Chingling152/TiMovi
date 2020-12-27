using UnityEngine;
using UnityEngine.UI;
using TheChest.Containers;
using TheChest.Items;
using TheChest.World;
using TheChest.UI.Components;

namespace TheChest.UI
{
    [DisallowMultipleComponent]
    //[RequireComponent(typeof(UIInventoryConfig))]
    public partial class UIInventory : MonoBehaviour
    {
        [Header("Inventory stats")]
        [SerializeField]private DropArea dropArea;
        [SerializeField]private Inventory inventory;

        [Header("UI Components")]

        //TODO: https://www.youtube.com/watch?v=wYkzeKghjsI

        [SerializeField]
        private Text containerName;

        [SerializeField]
        private GameObject slotContainer;

        [SerializeField]
        private UISlot slotPrefab;

        public int SelectedIndex { 
            get ;
            protected set ;
        }

        public int SelectedAmount {
            get;
            protected set ;
        }

        private void Awake()
        {
            this.GenerateUI();
            InventoryManager.PlayerInventory = this;
            dropArea.OnDropItem += this.Drop;
        }

        public bool Add(Item item,int amount = 1)
        {
            var res = this.inventory.AddItem(item, amount).Length == 0;
            this.RefreshUI();
            return res;
        }

        private void GenerateUI()
        {
            this.ClearUI();
            if (this.containerName != null)
                this.containerName.text = this.inventory?.ContainerName;

            if (this.slotContainer != null && this.slotPrefab != null)
            {
                for (int i = 0; i < inventory.Size; i++)
                {
                    var slot = this.inventory.Slots[i];
                    UISlot uiSlot = Instantiate(this.slotPrefab, this.slotContainer.transform);
                    uiSlot.SetSlot((Slot)slot, i);
                    uiSlot.OnSelectIndex += this.SelectItem;
                }
            }
        }

        private void Drop() { 

        }
        
        private void Unselect()
        {
            this.SelectedIndex = -1;
            this.SelectedAmount = 0;
            this.RefreshUI();
        }

        private void SelectItem(int index, int amount = 1)
        {
            if (SelectedIndex == index)
            {
                this.SelectedIndex = -1;
                this.SelectedAmount = 0;
            }
            else
            {
                if(SelectedIndex != -1)
                {
                    this.inventory.MoveItem(SelectedIndex, index);
                    this.SelectedIndex = -1;
                    this.SelectedAmount = 0;
                }
                else
                {
                    this.SelectedIndex = index;
                    this.SelectedAmount = amount;
                }
            }

            this.RefreshUI();
        }

        private void RefreshUI()
        {
            for (int i = 0; i < slotContainer.transform.childCount; i++)
            {
                var container = slotContainer.transform.GetChild(i).GetComponent<UISlot>();
                var slot = (Slot)this.inventory.Slots[i];
                container.SetSlot(slot, i,i == SelectedIndex);
            }
        }

        private void ClearUI()
        {
            this.containerName.text = "";
            this.SelectedIndex = -1;
            this.SelectedAmount = 0;

            foreach (var item in this.transform.GetComponentsInChildren<UISlot>())
            {
                Destroy(item);
            }
        }
    }
}
