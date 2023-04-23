using UnityEngine;
using UnityEngine.UI;
using TheChest.Containers;
using TheChest.Items;
using TheChest.World;
using TheChest.UI.Components;
using TheChest.UI.Interfaces;

namespace TheChest.UI
{
    [DisallowMultipleComponent]
    public class UIInventory : MonoBehaviour, IInventoryUI<Item>
    {
        [Header("Inventory data")]
        [Tooltip("Inventory class to store items data")]
        [SerializeField]protected Inventory inventory;

        #region UI Components
        [Header("UI Components")]

        [Tooltip("Text to show the Container name")]
        [SerializeField] protected Text containerName;

        [Tooltip("Container where slot Prefabs will be created")]
        [SerializeField] protected GameObject slotContainer;

        [Tooltip("An item slot prefab")]
        [SerializeField] protected UISlot slotPrefab;

        [Tooltip("The are where layer can drop items from inventory")]
        [SerializeField] protected DropArea dropArea;
        #endregion

        [Header("Prefab")]
        [Tooltip("Prefab created when the Player drops an item")]
        [SerializeField] protected WorldItem worldItem;

        #region Properties
        public int SelectedIndex { 
            get ;
            protected set ;
        }

        public int SelectedAmount {
            get;
            protected set ;
        }
        #endregion

        private void Awake()
        {
            this.Generate();
            InventoryManager.PlayerInventory = this;
            dropArea.OnDropItem += this.Drop;
        }

        #region Context Menu
        private void RandomWorldItemSpawn(Item item, int amount = 1)
        {
            var obj = Instantiate(
                original: worldItem,
                position: new Vector2(Random.Range(2, 5), Random.Range(-5, 5)),
                Quaternion.identity
            );

            obj.GetComponent<WorldItem>().Item = item;
            obj.GetComponent<WorldItem>().Amount = amount;
        }

        public void Use(int index)
        {
            _ = this.inventory.GetItem(index);
        }

        public void Split(int index)
        {
            var items = this.inventory.GetAll(index);
            var halfCount = (int)System.Math.Floor(items.Length / 2.0);
            this.inventory.AddItem(items[0..halfCount]);
            this.inventory.AddItem(items[halfCount..-1]);
        }

        public void Drop(int index, int amount)
        {
            var items = this.inventory.GetItemAmount(index, amount);
            RandomWorldItemSpawn(items[0], items.Length);
            this.SelectedIndex = -1;
            this.SelectedAmount = 0;
            this.Refresh();
        }

        #endregion

        #region Interface methods
        public bool Add(Item item,int amount = 1)
        {
            var res = this.inventory.AddItem(item, amount).Length == 0;
            this.Refresh();
            return res;
        }

        public void Generate()
        {
            this.Clear();
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

        public void Drop() 
        { 
            var items = this.inventory.GetAll(this.SelectedIndex);

            if(items.Length == 0) {
                this.SelectedIndex = -1;
                this.SelectedAmount = 0;
                return;
            }

            var item = items[0];

            var screenPoint = Input.mousePosition;
            screenPoint.z = 10.0f;

            var obj = Instantiate(worldItem, Camera.main.ScreenToWorldPoint(screenPoint), Quaternion.identity);

            obj.GetComponent<WorldItem>().Item = item;
            obj.GetComponent<WorldItem>().Amount = items.Length;

            this.SelectedIndex = -1;
            this.SelectedAmount = 0;
            this.Refresh();
        }

        public void SelectItem(int index, int amount = 1)
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

            this.Refresh();
        }

        public void Refresh()
        {
            for (int i = 0; i < slotContainer.transform.childCount; i++)
            {
                var container = slotContainer.transform.GetChild(i).GetComponent<UISlot>();
                var slot = (Slot)this.inventory.Slots[i];
                container.Refresh(slot,i == SelectedIndex);
            }
        }

        public void Clear()
        {
            this.containerName.text = "";
            this.SelectedIndex = -1;
            this.SelectedAmount = 0;

            foreach (var item in this.transform.GetComponentsInChildren<UISlot>())
            {
                Destroy(item);
            }
        }
        #endregion
    }
}
