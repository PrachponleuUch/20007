using Swin_Adventure;
using NUnit.Framework;

namespace LookCommandUnitTests
{
    public class Tests
    {
        private LookCommand lookcommand;
        private Player player;
        private Item item;
        private Item gem;
        private Bag bag;
        
        

        [SetUp]
        public void Setup()
        {
            lookcommand = new LookCommand();
            item = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a might fine");
            gem = new Item(new string[] { "gem", "GEM" }, "a gem", "This is a might fine");
            player = new Player("Fred", "the mighty programmer");
            bag = new Bag(new string[]{"bag","BAG"}, "a bag", "This is a bag.");


        }

        [Test]
        public void LookAtMeTest()
        {
            player.Inventory.Put(item);
            string[] Command = new []{ "look", "at" , "inventory" };
            Assert.True(lookcommand.Execute(player, Command) == player.FullDescription);
        }

        [Test]
        public void LookAtGemTest()
        {
            player.Inventory.Put(gem);
            string[] Command = new[] { "look", "at", "gem" };
            Assert.True(lookcommand.Execute(player, Command) == gem.FullDescription);
        }

        [Test]
        public void LookAtUnknownTest()
        {
            
            string[] Command = new[] { "look", "at", "gem"};
            Assert.True(lookcommand.Execute(player, Command) == "I cannot find the gem");
        }

        [Test]
        public void LookAtGemInMeTest()
        {
            player.Inventory.Put(gem);
            string[] Command = new[] { "look", "at", "gem", "in", "inventory" };
            Assert.True(lookcommand.Execute(player, Command) == gem.FullDescription);
        }

        [Test]
        public void LookAtGemInBagTest()
        {
            bag.Inventory.Put(gem);
            player.Inventory.Put(bag);
            string[] Command = new[] { "look", "at", "gem", "in", "bag" };
            Assert.True(lookcommand.Execute(player, Command) == gem.FullDescription);
        }

        [Test]
        public void LookAtGemNoBagTest()
        {
            bag.Inventory.Put(gem);
            string[] Command = new[] { "look", "at", "gem", "in", "bag" };
            Assert.True(lookcommand.Execute(player, Command) == "I cannot find the bag");
        }

        [Test]
        public void LookNoGemInBagTest()
        {
            player.Inventory.Put(bag);
            string[] Command = new[] { "look", "at", "gem", "in", "bag" };
            Assert.True(lookcommand.Execute(player, Command) == "I cannot find the gem");
        }

        [Test]
        public void InvalidLookTest()
        {
            
            string[] Command = new[] { "look", "gem", "in", "bag" };
            Assert.True(lookcommand.Execute(player, Command) == "I don't know how to look like that");
        }


        [Test]
        public void InvalidLookTest_()
        {

            string[] Command = new[] { "hi" , "at", "gem", "in", "bag" };
            Assert.True(lookcommand.Execute(player, Command) == "Error in look input");
        }


        [Test]
        public void InvalidLookTest__()
        {

            string[] Command = new[] { "look", "hi" ,"at"};
            Assert.True(lookcommand.Execute(player, Command) == "What do you want to look at?");
        }

        [Test]
        public void InvalidLookTest___()
        {

            string[] Command = new[] { "look", "at", "in", "bag", "hi" };
            Assert.True(lookcommand.Execute(player, Command) == "What do you want to look in?");
        }

    }
}