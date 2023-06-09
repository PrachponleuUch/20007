using Swin_Adventure;

namespace LocationUnitTests
{
    public class Tests
    {
        private Item item;
        private Player player;
        private Location location;
        private LookCommand command;

        [SetUp]
        public void Setup()
        {
            item = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a might fine");
            player = new Player("Fred", "the mighty programmer");
            location = new Location(new string[] { "house" }, "house", "house");
            command = new LookCommand();
        }

        [Test]
        public void LocationAreYouTest()
        {
            Assert.True(location.AreYou("house"));
        }

        [Test]
        public void LocationLocateItemTest()
        {
            location.Inventory.Put(item);
            Assert.True(location.Locate("shovel") == item);
        }

        [Test]
        public void PlayerLocateItemInTheirLocationTest()
        {
            player.Location = location;
            player.Location.Inventory.Put(item);
            Assert.True(player.Location.Locate("shovel") == item);
        }

        [Test]
        public void LookCommandTest()
        {
            player.Location = location;
            Assert.True(command.Execute(player, new string[] { "look" }) == $"You are in {player.Location.Name}\n{player.Location.FullDescription}{player.Location.ShowPath()}");
        }
    }
}