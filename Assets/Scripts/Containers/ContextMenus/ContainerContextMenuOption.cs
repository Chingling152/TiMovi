using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TheChest.ContextMenus
{
    [Serializable]
    public class ContainerContextMenuOption
    {
        [SerializeField] protected string title;
        [SerializeField] protected Image image;
        [SerializeField] protected UnityEvent action;
    
        public string Title => this.title;
        public Image Image => this.image;
    }          
}              
