using Swin_Adventure;
using NUnit.Framework;
namespace InventoryUnitTests
{
    public class Tests
    {
        private Item item;
        private Inventory inventory;
        [SetUp]
        public void Setup()
        {
            item = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a might fine");
            inventory = new Inventory();
        }

        [Test]
        public void ItemFindTest()
        {
            inventory.Put(item);
            Assert.True(inventory.HasItem("shovel"));
        }

        [Test]
        public void ItemNoFindTest()
        {
            Assert.False(inventory.HasItem("shovel"));

        }

        [Test]
        public void FetchItemTest()
        {
            inventory.Put(item);
            Assert.True(inventory.Fetch("shovel") == item);
            Assert.True(inventory.HasItem("shovel"));

        }

        [Test]
        public void TakeItemTest()
        {
            inventory.Put(item);
            Assert.True(inventory.HasItem("shovel"));
            inventory.Take("shovel");
            Assert.False(inventory.HasItem("shovel"));
        }

        [Test]
        public void ItemListTest()
        {
            inventory.Put(item);
            Assert.True(inventory.ItemList == "\n\ta shovel (shovel)");
        }

    }
}