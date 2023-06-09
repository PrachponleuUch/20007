using NUnit.Framework;
using Swin_Adventure;
using System.Xml;

namespace ItemUnitTests
{
    public class Tests
    {
        private Item item;
        
        [SetUp]
        public void Setup()
        {
            item = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a might fine");
            
        }

        [Test]
        public void ItemIsIdentifiableTest()
        {
            Assert.True(item.AreYou("spade"));
        }

        [Test]
        public void ItemShortDescTest()
        {
            Assert.True(item.ShortDescription == "a shovel (shovel)");
        }

        [Test]
        public void ItemLongDescTest()
        {
            Assert.True(item.FullDescription == "This is a might fine");
        }

    }
}