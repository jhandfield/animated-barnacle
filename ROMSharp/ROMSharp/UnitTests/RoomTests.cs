using NUnit.Framework;
using ROMSharp.Models;
using System;
using System.IO;
namespace ROMSharp.UnitTests
{
    [TestFixture()]
    public class RoomTests
    {
        [Test(), TestOf(typeof(RoomIndexData))]
        public void TestValidRoomData()
        {
            // Room data to parse, taken from daycare.are
            string roomData = @"#6601
The Dwarven Drop Off~
This is where the dwarven mommies and daddies come to drop off their
annoying little brats.  You have the urge to leave.  There is a sign here.
~
0 CD 0
D0
~
~
0 -1 6500
D2
You see a large room full of noisy brats.
~
~
1 -1 6602
E
sign~
This is an area for newbies, so have fun.  -- Sandman
~
S";
            StringReader sr = new StringReader(roomData);
            int lineNum = 1;
            string firstLine = sr.ReadLine();
            string expectedName = "The Dwarven Drop Off";
            string southExitDesc = "You see a large room full of noisy brats.";
            int southExitVNUM = 6602;

            try
            {
                RoomIndexData room = RoomIndexData.ParseRoomData(ref sr, "testArea", ref lineNum, firstLine);

                // Name of the room should be "The Dwarven Drop Off"
                Assert.AreEqual(expectedName, room.Name, String.Format("Room name mismatch, expected \"{0}\" but found \"{1}\"", expectedName, room.Name));

                // There should be an exit to the south
                Assert.IsNotNull(room.Exits[2], "Expected a south exit, but found none");

                // Check south exit's description
                Assert.AreEqual(southExitDesc, room.Exits[2].Description);

                // There should not be an exit to the east
                Assert.IsNull(room.Exits[1], "Expected no east exit, but found one");

                // Expect the room flags to indicate indoors and no mobs (CD)
                Assert.AreEqual(RoomAttributes.Indoors | RoomAttributes.NoMobs, room.Attributes);

                // Expect the south exit to lead to rom 6602
                Assert.AreEqual(southExitVNUM, room.Exits[2].ToVNUM, String.Format("Expected south exit to lead to room {0}, but actually exits to {1}", southExitVNUM, room.Exits[2].ToVNUM));
            }
            catch (Exception e)
            {
                Assert.Fail(String.Format("Execption thrown loading room: {0} {1}", e.GetType().ToString(), e.Message));
            }
        }
    }
}