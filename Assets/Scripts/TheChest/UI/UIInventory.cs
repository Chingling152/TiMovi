using UnityEngine;
using UnityEngine.UI;
using TheChest.Containers;

namespace TheChest.UI
{
    [DisallowMultipleComponent]
    public partial class UIInventory : MonoBehaviour
    {
        [Header("Inventory stats")]
        [SerializeField]
        private Inventory inventory;

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
                    var slot = (Slot)this.inventory.Slots[i];
                    container.SetSlot(slot, i);
                    container.OnSelectIndex += this.AddItem;
                }
            }
        }

        private void AddItem(int index, int amount = 1)
        {
            if (SelectedIndex == index)
            {
                this.SelectedIndex = -1;
                this.SelectedAmount = 0;
                return;
            }

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

            this.RefreshUI();
        }

        public void RefreshUI()
        {
            for (int i = 0; i < slotContainer.transform.childCount; i++)
            {
                var container = slotContainer.transform.GetChild(i).GetComponent<UISlot>();
                var slot = (Slot)this.inventory.Slots[i];
                container.SetSlot(slot, i,i == SelectedIndex);
            }
        }

        public void ClearUI()
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
