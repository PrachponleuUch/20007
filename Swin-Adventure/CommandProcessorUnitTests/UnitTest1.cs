using Swin_Adventure;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace CommandProcessorUnitTests
{
    public class Tests
    {
        private Player player0;
        private Item item0;
        private Item item1;
        private Item item2;
        private Bag bag0;
        private Location house;
        private Location garden;
        private CommandProcessor cmd;

        [SetUp]
        public void Setup()
        {
            player0 = new Player("John", "John Doe");
            item0 = new Item(new string[] { "sword", "weapon" }, "An anti-matter sword", "A sword made from anti-matter.");
            item1 = new Item(new string[] { "glasses", "accessory" }, "An all seeing glasses", "Glasses can see through all living creature souls.");
            item2 = new Item(new string[] { "ring", "accessory" }, "A ring", "A non-suspicious ring");
            bag0 = new Bag(new string[] { "bag" }, "A dimensional bag", "A bag that stores items in another dimension.");
            house = new Location(new string[] { "house" }, "a wooden house", "A house made of wood.");
            garden = new Location(new string[] { "garden" }, "a lovely garden", "Garden near a wooden house");
            Swin_Adventure.Path path = new Swin_Adventure.Path(new string[] { "north" }, "Door", "A test door", garden);
            cmd = new CommandProcessor();

            player0.Inventory.Put(item0);
            player0.Inventory.Put(item1);
            player0.Inventory.Put(bag0);
            bag0.Inventory.Put(item2);
            player0.Location = house;
            house.AddPath(path);
        }

        [Test]
        public void LookCommandTest()
        {
            string[] c = new string[] {"look"};
            Assert.True(cmd.Execute(player0, c) == "You are in a wooden house\nA house made of wood.\nThere is exit to the north.");
        }

        [Test]
        public void MoveCommandTest()
        {
            string[] c = new string[] { "move", "north" };
            Assert.True(cmd.Execute(player0, c) == "You head north.\nYou go through a Door\nYou have arrived in a lovely garden\nGarden near a wooden house");
        }

        [Test]
        public void InvalidCommandTest()
        {
            string[] c = new string[] { "fly", "north" };
            Assert.True(cmd.Execute(player0, c) == "FLY command does not exist");
        }


    }
}