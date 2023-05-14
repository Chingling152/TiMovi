using UnityEngine;
using TheChest.Items;
using TheChest.Containers.Generics.Base;
using TheChest.Slots.Generics.Interfaces;

namespace TheChest.Examples.Containers
{
    public class Container : BaseContainer<Item>
    {
        [SerializeField]
        protected Slot[] slots;

        public override ISlot<Item>[] Slots 
        { 
            get => slots; 
            protected set => slots = value as Slot[]; 
        }
    }
}
