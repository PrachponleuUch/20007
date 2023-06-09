using Swin_Adventure;

namespace PathUnitTests
{
    public class Tests
    {

        private Player player;
        private Location roomA;
        private Location roomB;
        private Swin_Adventure.Path path;

        [SetUp]
        public void Setup()
        {
            player = new Player("JoJo", "Jotaro Kujo");
            roomA = new Location(new string[] { "room" }, "Room A", "Room A");
            roomB = new Location(new string[] { "room" }, "Room B", "Room B");
            path = new Swin_Adventure.Path(new string[] { "north" }, "Door", "A test door", roomB);
        }

        [Test]
        public void PlayerMoveTest()
        {
            player.Location = roomA;
            roomA.AddPath(path);
            path.Move(player);
            Assert.True(player.Location == path.TargetLocation);
        }

        [Test]
        public void LocationLocatePath()
        {
            roomA.AddPath(path);
            Assert.True(roomA.LocatePath("north") == path);
        }

        [Test]
        public void PlayerMoveUsingPathIdentifierTest()
        {
            player.Location = roomA;
            roomA.AddPath(path);
            roomA.LocatePath("north").Move(player);
            Assert.True(player.Location == path.TargetLocation);
        }

        [Test]
        public void InvalidPathIdentifierTest()
        {
            player.Location = roomA;
            roomA.AddPath(path);
            Assert.True((Swin_Adventure.Path)roomA.LocatePath("south") == null);
        }

    }
}
