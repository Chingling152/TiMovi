using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheChest.ContextMenus
{
    [Serializable]
    public class ContainerContextMenu
    {
        [SerializeField]private string title;
        [SerializeField]private ContainerContextMenuOption[] options;

        public string Title => this.title;
        public IEnumerable<ContainerContextMenuOption> Options => this.options;
    }
}
