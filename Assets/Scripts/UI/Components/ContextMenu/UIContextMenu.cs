using UnityEngine;
using UnityEngine.UI;
using TheChest.ContextMenus;

namespace TheChest.UI.Components.ContextMenus
{
    public class UIContextMenu : MonoBehaviour
    {
        [SerializeField] private Text title;
        [SerializeField] private GameObject optionsContainer;
        [SerializeField] private ContainerContextMenu menu;

        [SerializeField] private UIContextMenuOption optionPrefab;

        public string Title
        {
            set
            {
                title.text = value;
            }
            get { 
                return title.text; 
            }
        }

        private void Start()
        {
            title.text = menu.Title;

            foreach (var option in menu.Options)
            {
                var menuOption = Instantiate(this.optionPrefab, this.optionsContainer.transform);
                menuOption.SetMenuOption(option);
            }
        }
    }
}