using Swin_Adventure;
using System.IO;
using System.Numerics;

namespace MoveCommandUnitTests
{
    public class Tests
    {
        private MoveCommand move;
        private Player player;
        private Location roomA;
        private Location roomB;
        private Swin_Adventure.Path path;
        [SetUp]
        public void Setup()
        {
            move = new MoveCommand();
            player = new Player("JoJo", "Jotaro Kujo");
            roomA = new Location(new string[] { "room" }, "Room A", "Room A");
            roomB = new Location(new string[] { "room" }, "Room B", "Room B");
            path = new Swin_Adventure.Path(new string[] { "north" }, "Door", "A test door", roomB);
        }

        [Test]
        public void MoveTest()
        {
            player.Location = roomA;
            roomA.AddPath(path);
            string[] command = new string[] { "move", "north" };
            move.Execute(player, command);
            Assert.True(player.Location == path.TargetLocation);
        }

        [Test]
        public void InvalidMoveTest0()
        {
            player.Location = roomA;
            roomA.AddPath(path);
            string[] command = new string[] { "move", "south" };
            move.Execute(player, command);
            Assert.True(player.Location == roomA);
        }
    }
}