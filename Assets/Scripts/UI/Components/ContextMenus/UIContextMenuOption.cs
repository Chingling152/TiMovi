using TheChest.ContextMenus;
using UnityEngine;
using UnityEngine.UI;

namespace TheChest.UI.Components.ContextMenus
{ 
    public class UIContextMenuOption : MonoBehaviour
    {
        [SerializeField] protected Image image;
        [SerializeField] protected Text title;

        public void SetMenuOption(ContainerContextMenuOption option)
        {
            this.image = option.Image;
            this.title.text = option.Title;
        }
    }
}