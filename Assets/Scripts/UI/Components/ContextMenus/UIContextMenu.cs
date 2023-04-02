using UnityEngine;
using UnityEngine.UI;
using TheChest.ContextMenus;
using TheChest.Items;

namespace TheChest.UI.Components.ContextMenus
{
    public class UIContextMenu : MonoBehaviour
    {
        [SerializeField] private Text title;
        [SerializeField] private GameObject optionsContainer;
        [SerializeField] private ContainerContextMenu menu;

        [SerializeField] private UIContextMenuOption optionPrefab;
        private Item item;

        private void Start()
        {
            title.text = menu.Title;

            foreach (var option in menu.Options)
            {
                var menuOption = Instantiate(this.optionPrefab, this.optionsContainer.transform);
                menuOption.SetMenuOption(option);
            }
        }

        public void SetItem(Item item)
        {
            this.title.text = item.Name;
        }
    }
}