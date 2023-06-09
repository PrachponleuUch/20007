using Swin_Adventure;
using NUnit.Framework;
namespace BagUnitTests
{
    public class Tests
    {
        private Bag bag;
        private Bag b1;
        private Bag b2;
        private Item item;
        private Item item1;

        [SetUp]
        public void Setup()
        {
            bag = new Bag(new string[]{"b0","B0"}, "bag0", "This is a bag.");
            b1 = new Bag(new string[] { "b1", "B1" }, "bag1", "This is a bag.");
            b2 = new Bag(new string[] { "b2", "B2" }, "bag2", "This is a bag.");
            item = new Item(new string[]{ "shovel", "spade" }, "a shovel", "This is a might fine");
            item1 = new Item(new string[] { "spear", "weapon" }, "a spear", "This is a might fine");

        }

        [Test]
        public void BagLocatesItemsTest()
        {
            bag.Inventory.Put(item);
            Assert.True(bag.Locate("shovel") == item);
        }

        [Test]
        public void BagLocatesItselfTest()
        {
            Assert.True(bag.Locate("b0") == bag);
        }

        [Test]
        public void BagLocatesNothingTest()
        {
            Assert.True(bag.Locate("b1") == null);
        }

        [Test]
        public void BagFullDescriptionTest()
        {
            Assert.True(bag.FullDescription == $"In the {bag.Name} you can see:{bag.Inventory.ItemList}");
        }

        [Test]
        public void BagInBagTest()
        {
            b1.Inventory.Put(b2);
            b1.Inventory.Put(item);
            b2.Inventory.Put(item1);
            Assert.True(b1.Locate("b2") == b2);
            Assert.True(b1.Locate("shovel") == item);
            Assert.False(b1.Locate("spear") == b2.Locate("spear"));
        }
    }
}