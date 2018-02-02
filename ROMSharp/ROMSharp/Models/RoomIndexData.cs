using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ROMSharp.Models
{
    /// <summary>
    /// Represents a room contained within an area
    /// </summary>
    public class RoomIndexData
    {
        #region Properties
        /// <summary>
        /// Contains the next room in the sequence of loading
        /// </summary>
        /// <remarks>Not sure this is still needed</remarks>
        public RoomIndexData NextRoom { get; set; }

        /// <summary>
        /// Contains references to all characters currently in the room
        /// </summary>
        /// <value>The people.</value>
        public List<CharacterData> People { get; set; }

        /// <summary>
        /// Contains references to all objects currently in the room
        /// </summary>
        public List<ObjectData> Objects { get; set; }

        /// <summary>
        /// Contains references to all extra descriptions available in the room
        /// </summary>
        public List<ExtraDescription> ExtraDescriptions { get; set; }

        /// <summary>
        /// Information regarding the exits of the room
        /// </summary>
        public Exits Exits { get; set; }

        /// <summary>
        /// Name of the room
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the room
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// VNUM of the room
        /// </summary>
        public int VNUM { get; set; }

        /// <summary>
        /// Attributes of the room (e.g. that it is dark, indoors, and private)
        /// </summary>
        /// <value>The attributes.</value>
        public RoomAttributes Attributes { get; set; }

        /// <summary>
        /// Level of light in the room - anything greater than 0 is lit
        /// </summary>
        public int LightLevel { get; set; }

        /// <summary>
        /// Defines the type of terrain the room represents
        /// </summary>
        public SectorType SectorType { get; set; }

        /// <summary>
        /// The rate at which health regenerates while in this room (percent
        /// bonus, 100 is default)
        /// </summary>
        public int HealRate { get; set; }

        /// <summary>
        /// The rate at which mana regenerates while in this room (percent
        /// bonus, 100 is default)
        /// </summary>
        public int ManaRate { get; set; }

        /// <summary>
        /// Indicates the clan that owns the room; influences who can see and
        /// enter the room.
        /// </summary>
        public int OwningClan { get; set; }
        #endregion

        #region Constructors
        public RoomIndexData() {
            this.HealRate = 100;
            this.ManaRate = 100;
            this.People = new List<CharacterData>();
            this.Objects = new List<ObjectData>();
            this.Exits = new Exits();
            this.ExtraDescriptions = new List<ExtraDescription>();
        }
        #endregion

        #region Methods

        internal static RoomIndexData ParseRoomData(ref StringReader sr, string areaFile, ref int lineNum, string firstLine)
        {
            Logging.Log.Debug(String.Format("ParseRoomData() called for area {0} starting on line {1}", areaFile, lineNum));

            // Instantiate variables for the method
            RoomIndexData outRoom = new RoomIndexData();
            string lineData = firstLine;

            bool readingRooms = true;

            //// Read line
            //lineData = sr.ReadLine();
            //lineNum++;

            // First, pull the vnum; then set it, if it's valid
            int vnum = ParseVNUM(lineData);

            if (!vnum.Equals(0))
            {
                outRoom.VNUM = vnum;

                // Rooms with VNUMs 3000-3399 are hard-coded to be law...ed? WTF is the right term for this?
                if (3000 <= outRoom.VNUM && outRoom.VNUM < 3400)
                    outRoom.Attributes |= RoomAttributes.Law;
            }
            else
                return null;

            Logging.Log.Debug(String.Format("Found room definition for vnum {0} beginning on line {1}", outRoom.VNUM, lineNum));

            // Read the room name - one line, terminated with a tilde at the end
            outRoom.Name = sr.ReadLine().TrimEnd('~');
            lineNum++;

            // Next, read the description
            outRoom.Description = ParseRoomDescription(sr, ref lineNum, areaFile, outRoom.VNUM);

            // Then, read the next line and parse as room flags and sector type
            lineData = sr.ReadLine();
            lineNum++;

            ParseRoomFlagsAndSectorType(outRoom, lineData, lineNum, areaFile);

            // Finally, read remaining possible line definitions
            while (readingRooms)
            {
                // Read the next line
                lineData = sr.ReadLine();
                lineNum++;

                //Logging.Log.Debug(String.Format("Reading line {0}, begins with {1}", lineNum, lineData[0]));

                // Flow control based on the first letter of the line
                if (lineData.Length > 0)    // Temporary - once we handle everything, this shouldn't happen any more.
                {
                    switch (lineData[0])
                    {
                        case 'C':
                            // TODO: Implement setting rooms as belonging to a clan
                            break;
                        case 'D':
                            // Room exit
                            Exit roomExit = ParseExit(sr, outRoom, lineData, ref lineNum, areaFile);

                            // If the exit is not null, set it
                            if (roomExit != null)
                                outRoom.Exits[(int)roomExit.Direction] = roomExit;
                            break;
                        case 'E':
                            // Room extra descriptions
                            ExtraDescription desc = new ExtraDescription();

                            // Read the next line
                            lineData = sr.ReadLine();
                            lineNum++;

                            // Store the value as the description's keyowrds
                            desc.Keywords = lineData.TrimEnd('~');

                            bool readingDescription = true;
                            StringBuilder sb = new StringBuilder();

                            while (readingDescription)
                            {
                                // Read the line
                                lineData = sr.ReadLine();
                                lineNum++;

                                if (lineData.Trim().Equals("~"))
                                    readingDescription = false;
                                else
                                    sb.AppendLine(lineData);
                            }

                            // Store the description
                            desc.Description = sb.ToString();

                            // Append the ExtraDescription to the room
                            outRoom.ExtraDescriptions.Add(desc);
                            break;
                        case 'H':
                            // Heal rate definition
                            outRoom.HealRate = ParseHealRateDef(lineData, outRoom.VNUM, ref lineNum, areaFile);
                            break;
                        case 'M':
                            // Mana rate definition
                            outRoom.ManaRate = ParseManaRateDef(lineData, outRoom.VNUM, ref lineNum, areaFile);
                            break;
                        case 'O':
                            // TODO: Implement room ownership
                            break;
                        case 'S':
                            // We're finished reading the area
                            readingRooms = false;
                            Logging.Log.Debug(String.Format("Finished reading room {0} of area {1} on line {2}", outRoom.VNUM, areaFile, lineNum));
                            break;
                        default:
                            Logging.Log.Warn(String.Format("Encounted unexpected identifier {0} in room {1} of area {2} on line {3}", lineData[0], outRoom.VNUM, areaFile, lineNum));
                            break;
                    }
                }
            }

            return outRoom;
        }

        private static Exit ParseExit(StringReader sr, RoomIndexData outRoom, string lineData, ref int lineNum, string areaFile)
        {
            // Instantiate a new ExitAttributes object to hold the exit data
            Exit exit = new Exit();

            // The second character should be an integer
            int exitDirection = -1;

            if (!Int32.TryParse(lineData[1].ToString(), out exitDirection))
            {
                Logging.Log.Error(String.Format("Error parsing exits of room {0} in area {1}: expected a numeric exit number on line {2} character 2 but instead found {3}", outRoom.VNUM, areaFile, lineNum, lineData[1]));
                return null;
            }
            else
            {
                // Test that the exitNum is valid
                if (exitDirection > Enum.GetValues(typeof(Enums.Direction)).Length - 1)
                {
                    Logging.Log.Error(String.Format("Error parsing exits of room {0} in area {1}: invalid exit direction {2} found on line {3}", outRoom.VNUM, areaFile, exitDirection, lineNum));
                    return null;
                }
                else
                {
                    // Valid exit direction, store it
                    exit.Direction = (Enums.Direction)exitDirection;
                }
            }
        
            // Begin reading the exit description
            bool readingExitDescription = true;

            while (readingExitDescription)
            {
                // Read the next line
                lineData = sr.ReadLine();
                lineNum++;

                // Is the line a sole tilde? If so, we're done.
                if (lineData.Equals("~"))
                    readingExitDescription = false;
                else
                    // Append to the exit's description
                    exit.Description += lineData;
            }

            // Pull the next line and store as the keywords
            lineData = sr.ReadLine();
            lineNum++;

            exit.Keywords = lineData.Replace("~", "");

            // Pull the final line of the exit definition, [lock #] [key #] [toRoom #]
            lineData = sr.ReadLine();
            lineNum++;

            // Split the line on spaces
            string[] splitLine = lineData.Split(' ');

            // Expecting three segments
            if (splitLine.Length != 3)
            {
                Logging.Log.Error(String.Format("Error parsing exits of room {0} in area {1}: invalid lock-key-room line, expected 3 segments but got {2} - value {3} on line {4}", outRoom.VNUM, areaFile, splitLine.Length, lineData, lineNum));
                return null;
            }

            // First segment - value should be 0-2 according to the
            // ROM2.4b6 area.txt documentation, but the code accepts
            // values from 0-4, so we'll use those. Interestingly,
            // these map to the EX_* macros in merc.h, but at least for
            // rooms, there are some values (e.g. EX_HARD and
            // EX_INFURIATING) that go unused; perhaps object suse them?
            int door = 0;
            if (!Int32.TryParse(splitLine[0], out door))
            {
                Logging.Log.Error(String.Format("Error parsing exits of room {0} in area {1}: door type is invalid, expected an integer but got {2} on line {3}", outRoom.VNUM, areaFile, splitLine[0], lineNum));
                return null;
            }

            if (door < 0 || door > 4)
            {
                Logging.Log.Error(String.Format("Error parsing exits of room {0} in area {1}: door type is invalid, expected value from 0-4, got {2} on line {3}", outRoom.VNUM, areaFile, splitLine[0], lineNum));
                return null;
            }

            switch (door)
            {
                case 0:
                    // Not a door, do nothing
                    break;
                case 1:
                    // Is door.
                    exit.Attributes = ExitAttributes.Door;
                    break;
                case 2:
                    // Pickproof door
                    exit.Attributes = ExitAttributes.Door | ExitAttributes.PickProof;
                    break;
                case 3:
                    // Gandalf door
                    exit.Attributes = ExitAttributes.Door | ExitAttributes.NoPass;
                    break;
                case 4:
                    // A door that's sort of not a door
                    exit.Attributes = ExitAttributes.Door | ExitAttributes.NoPass | ExitAttributes.PickProof;
                    break;
            }

            // Second segment - value should be positive integer, the VNUM of the key object
            int key = 0;
            if (!Int32.TryParse(splitLine[1], out key))
            {
                Logging.Log.Error(String.Format("Error parsing exits of room {0} in area {1}: key VNUM is invalid, expected integer value but got {2} on line {3}", outRoom.VNUM, areaFile, splitLine[1], lineNum));
                return null;
            }

            // Key VNUM is -1 and up
            if (key < -1)
            {
                Logging.Log.Info(String.Format("Error parsing exits of room {0} in area {1}: key VNUM is invalid, must be greater than zero - got value {2} on line {3}", outRoom.VNUM, areaFile, splitLine[1], lineNum));
                return null;
            }

            // Set the exit's key's VNUM
            exit.KeyVNUM = key;

            // Third argument - value should be positive integer, the VNUM of the room the door leads to
            int exitRoomVNUM = 0;
            if (!Int32.TryParse(splitLine[2], out exitRoomVNUM))
            {
                Logging.Log.Error(String.Format("Error parsing exits of room {0} in area {1}: exit room VNUM is invalid, expected integer value but got {2} on line {3}", outRoom.VNUM, areaFile, splitLine[2], lineNum));
                return null;
            }

            // Exit room VNUMs are zero or greater
            if (exitRoomVNUM < 0)
            {
                Logging.Log.Error(String.Format("Error parsing exits of room {0} in area {1}: exit room VNUM is invalid, must be greater than zero - got value {2} on line {3}", outRoom.VNUM, areaFile, exitRoomVNUM, lineNum));
                return null;
            }

            // Set the exit roomTo
            exit.ToVNUM = exitRoomVNUM;

            // Return the exit data
            return exit;
        }

        /// <summary>
        /// Parses room flags and sector type definition for a room
        /// </summary>
        /// <returns><c>true</c>, if room flags and sector type were parsed, <c>false</c> otherwise.</returns>
        /// <param name="outRoom">Room to set the flags in</param>
        /// <param name="lineData">Line data to parse</param>
        /// <param name="lineNum">Current line number, used for error messages</param>
        /// <param name="areaFile">Filename of the area being parsed, used for error messages.</param>
        private static bool ParseRoomFlagsAndSectorType(RoomIndexData outRoom, string lineData, int lineNum, string areaFile)
        {
            // Split the line on space
            string[] splitLine = lineData.Split(' ');

            // Should be three parts; throw an error if not
            if (splitLine.Length != 3)
            {
                // Log an error and return null
                Logging.Log.Error(String.Format("Error parsing room flags & sector type of room {0} in area {1} on line {2}: expected three parts, encountered {3} in data {4}", outRoom.VNUM, areaFile, lineNum, splitLine.Length, lineData));
                return false;
            }

            // First part is obsolete - start with part 2, room flags
            // Convert the ROM flags to RoomAttributes
            outRoom.Attributes = Helpers.ConvertROMAlphaToRoomAttributes(splitLine[1]);

            int sectType = 0;
            if (!Int32.TryParse(splitLine[2], out sectType))
            {
                // Log an error and return null
                Logging.Log.Error(String.Format("Error parsing sector type of room {0} in area {1} on line {2}: could not convert value \"{3}\" to integer", outRoom.VNUM, areaFile, lineNum, splitLine[2]));
                return false;
            }

            // Validate the value
            if (!Enum.IsDefined(typeof(SectorType), sectType))
            {
                // Log an error and return null
                Logging.Log.Error(String.Format("Error parsing sector type of room {0} in area {1} on line {2}: invalid sector type {3}", outRoom.VNUM, areaFile, lineNum, sectType));
                return false;
            }

            // Store the sector type
            outRoom.SectorType = (SectorType)sectType;

            // All done
            return true;
        }

        /// <summary>
        /// Reads the room description from StringReader <paramref name="sr"/>, which should be on the line preceding the start of the description
        /// </summary>
        /// <returns>The room description</returns>
        /// <param name="sr">StringReader from which to read the description</param>
        /// <param name="lineNum">The starting line number, by reference</param>
        /// <param name="areaFile">Filename of the current area</param>
        /// <param name="vNUM">VNUM of the room</param>
        private static string ParseRoomDescription(StringReader sr, ref int lineNum, string areaFile, int vNUM)
        {
            StringBuilder sb = new StringBuilder();
            string lineData = String.Empty;
            bool foundEnd = false;

            // Flag to break us out of the loop
            int safetyValve = 0;

            // Loop up to a defined maximum number of times
            while (safetyValve < Consts.Misc.Safety.MaxRoomDescLines)
            {
                // Increment safetyValve
                safetyValve++;

                // Read a line
                lineData = sr.ReadLine();
                lineNum++;

                // If the line is a sole tilde, we're done reading
                if (lineData.Trim().Equals("~"))
                {
                    foundEnd = true;
                    break;
                }

                // Append to the output string
                sb.AppendLine(lineData);
            }

            // Check if we exited the loop due to the safety valve
            if (!foundEnd)
                Logging.Log.Warn(String.Format("When reading description of room {0} in area {1}, did not find the description's end in the expected {2} lines", vNUM, areaFile, Consts.Misc.Safety.MaxRoomDescLines));
            
            return sb.ToString();
        }

        /// <summary>
        /// Parses a mana rate definition (line beginning with M)
        /// </summary>
        /// <returns>The mana restoration rate of the room.</returns>
        /// <param name="lineData">Mana rate definition line to parse.</param>
        /// <param name="roomVNUM">VNUM of the room, used in error messages.</param>
        /// <param name="lineNum">Current line number in the file, used in error messages..</param>
        /// <param name="areaFile">Filename of the area, used in error messages.</param>
        private static int ParseManaRateDef(string lineData, int roomVNUM, ref int lineNum, string areaFile)
        {
            int manaRate = 100;

            if (!Int32.TryParse(lineData.Substring(0, lineData.Length - 1), out manaRate))
            {
                Logging.Log.Error(String.Format("Error parsing mana rate in room {0} of area {1}: Expected integer, found {2} on line {3}", roomVNUM, areaFile, lineData, lineNum));
                return 100;     // Default value
            }
            else
                return manaRate;
        }

        /// <summary>
        /// Parses a heal rate definition (line beginning with H)
        /// </summary>
        /// <returns>The health restoration rate of the room..</returns>
        /// <param name="lineData">Heal rate definition line to parse.</param>
        /// <param name="roomVNUM">VNUM of the room, used in error messages.</param>
        /// <param name="lineNum">Current line number in the file, used in error messages..</param>
        /// <param name="areaFile">Filename of the area, used in error messages.</param>
        private static int ParseHealRateDef(string lineData, int roomVNUM, ref int lineNum, string areaFile)
        {
            int healRate = 100;

            if (!Int32.TryParse(lineData.Substring(0, lineData.Length - 1), out healRate))
            {
                Logging.Log.Error(String.Format("Error parsing heal rate in room {0} of area {1}: Expected integer, found {2} on line {3}", roomVNUM, areaFile, lineData, lineNum));
                return 100;     // Default value
            }
            else
                return healRate;
        }

        /// <summary>
        /// Reads and parses the room's VNUM from the first line of a room declaration
        /// </summary>
        /// <returns>The room's vnum if valid, 0 otherwise</returns>
        /// <param name="lineData">Line from an area file containing a VNUM definition</param>
        private static int ParseVNUM(string lineData)
        {
            // First character of first line should be #
            if (lineData[0].Equals("#"))
            {
                Logging.Log.Error(String.Format("Error parsing VNUM: Expected # in character 1, found {2}", lineData[0]));
                return 0;
            }
            else
            {
                int vnum = 0;

                if (!Int32.TryParse(lineData.TrimStart('#'), out vnum))
                {
                    Logging.Log.Error(String.Format("Error parsing VNUM: Expected integer, got {2}", lineData.TrimStart('#')));
                    return 0;
                }
                else
                    return vnum;
            }
        }
        #endregion

        public static class Helpers
        {
            /// <summary>
            /// Converts legacy ROM macro-based room flags to a RoomAttributes object
            /// </summary>
            /// <returns>A RoomAttributes object representation of the input flags</returns>
            /// <param name="inputFlags">Legacy ROM room flags to convert; must contain no characters other than A-ee</param>
            public static RoomAttributes ConvertROMAlphaToRoomAttributes(string inputFlags)
            {
                // Will hold the sum of the flags for conversion
                int inFlagsSum = 0;

                // Buffer to hold multi-character flags
                string charFlagBuffer = String.Empty;

                // Loop over each character
                foreach (char c in inputFlags)
                {
                    // Set or append the current character
                    if (String.IsNullOrEmpty((charFlagBuffer)))
                        charFlagBuffer = c.ToString();
                    else
                        charFlagBuffer += c.ToString();

                    // If the character is lower case, move to the next iteration
                    if (Char.IsLower(c))
                        continue;

                    // Declare an AlphaMacros object to hold the (potentially) parsed value below
                    Enums.AlphaMacros parsed;

                    // Attempt to parse each character as an AlphaMacro and add to the running sum
                    if (Enum.TryParse<Enums.AlphaMacros>(charFlagBuffer, out parsed))
                        inFlagsSum += (int)parsed;
                    else
                        throw new ArgumentException(String.Format("Invalid character found in inFlags: {0}", c));

                    // Empty the buffer
                    charFlagBuffer = String.Empty;
                }

                // Convert the sum to a RoomAttributes value and return it
                return (RoomAttributes)inFlagsSum;
            }
        }
    }

    /// <summary>
    /// Attributes that describe a room (e.g. that it is Dark (Dark), 
    /// Indoors (Indoors), and only allows 1 person at a time (Solitary)
    /// </summary>
    /// <remarks>
    /// To maintain compatibility with stock ROM area files, the flags are
    /// arranged in the same order as in the ROM 2.4b6 code. This makes the
    /// flags a little disorganized, but it is what it is.
    /// </remarks>
    [Flags]
    public enum RoomAttributes
    {
        None = 0,
        Dark = 1 << 0,
        NoMobs = 1 << 1,
        Indoors = 1 << 2,
        Private = 1 << 3,
        Safe = 1 << 4,
        Solitary = 1 << 5,
        PetShop = 1 << 6,
        NoRecall = 1 << 7,
        ImpOnly = 1 << 8,
        GodsOnly = 1 << 9,
        HeroesOnly = 1 << 10,
        NewbiesOnly = 1 << 11,
        Law = 1 << 12,
        Nowhere = 1 << 13
    }

    /// <summary>
    /// Represents the terrain of a room
    /// </summary>
    public enum SectorType
    {
        Unknown = -1,
        Inside = 0,
        City = 1,
        Field = 2,
        Forest = 3,
        Hills = 4,
        Mountain = 5,
        /// <summary>
        /// Fun fact, the *only* thing this influences is the chance of being
        /// able to blind something by kicking dirt while fighting!
        /// </summary>
        WaterSwimming = 6,
        WaterNotSwimming = 7,
        /// <summary>
        /// Kept around for compatibility with old area files. I guess?
        /// </summary>
        Unused = 8,
        Air = 9,
        Desert = 10,
        Max = 11
    }
}