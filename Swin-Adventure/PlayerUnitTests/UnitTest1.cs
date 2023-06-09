using Swin_Adventure;
using NUnit.Framework;
namespace PlayerUnitTests
{
    public class Tests
    {
        private Item item;
        private Player player;
        [SetUp]
        public void Setup()
        {
            item = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a might fine");
            player = new Player("Fred", "the mighty programmer");

        }

        [Test]
        public void PlayerIsIdentifiableTest()
        {
            Assert.True(player.AreYou("me"));
        }

        [Test]
        public void PlayerLocateItemTest()
        {
            player.Inventory.Put(item);
            Assert.True(player.Locate("shovel") == item);
        }

        [Test]
        public void PlayerLocateItselfTest()
        {
            Assert.True(player.Locate("me") == player);
        }

        [Test]
        public void PlayerLocateNothingTest()
        {
            Assert.True(player.Locate("notme") == null);
        }

        [Test]
        public void PlayerFullDescTest()
        {
            player.Inventory.Put(item);
            Assert.True(player.FullDescription == "You are Fred\nthe mighty programmer\nYou are carrying:\n\ta shovel (shovel)");
        }
    }
}