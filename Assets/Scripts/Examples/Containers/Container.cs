using UnityEngine;
using TheChest.Containers.Generics.Base;
using TheChest.Slots.Generics.Interfaces;
using TheChest.Examples.Items;

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
