using NUnit.Framework;
using TheChest.Containers;
using TheChest.Items;

namespace Tests.TheChest
{
    public partial class SlotTests
    {
        public System.Random random;

        public SlotTests()
        {
            random = new System.Random();
        }

        [Test]
        public void SlotConstrutorEmpty()
        {
            var slot = new Slot();
            Assert.IsTrue(slot.isEmpty);
            Assert.IsNull(slot.CurrentItem);
        }

        [Test]
        public void SlotConstrutorWithItem()
        {
            var item = new Item();
            var slot = new Slot(item);

            Assert.IsFalse(slot.isEmpty);
            Assert.IsNotNull(slot.CurrentItem);
            Assert.AreEqual(item, slot.CurrentItem);
        }
    }
}
