using TheChest.Containers.Generics.Base;
using TheChest.Examples.Items;
using TheChest.Examples.Slots;
using TheChest.Slots.Generics.Interfaces;
using UnityEngine;

namespace TheChest.Examples.Containers
{
    public class StackContainer : BaseStackContainer<Item>
    {
        [SerializeField]
        protected StackSlot[] slots;

        public override ISlot<Item>[] Slots
        {
            get => slots;
            protected set => slots = value as StackSlot[];
        }

        public StackContainer(int size) : base(size)
        {

        }

        public StackContainer(StackSlot[] slots)
        {
            Slots = slots;
        }
    }
}
