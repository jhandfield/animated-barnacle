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
        public RoomIndexData() { }
        #endregion

        #region Methods
        internal static RoomIndexData ParseRoomData(string record, string areaFile, int startLine, int endLine)
        {
            // Instantiate output variable
            RoomIndexData outRoom = new RoomIndexData();
            int lineNum = startLine - 1;
            string lineData = String.Empty;

            using (StringReader sr = new StringReader(record))
            {
                int vnum = 0;

                #region VNUM
                // First line is the VNUM
                lineData = sr.ReadLine();
                lineNum++;

                // Should parse as an Int32 after removing the leading #
                if (Int32.TryParse(lineData.TrimStart('#'), out vnum))
                    outRoom.VNUM = vnum;
                else
                {
                    // Log an error and return null
                    Logging.Log.Error(String.Format("Error parsing {0} line {1}: Expected room VNUM with leading #, instead got {2}", areaFile, lineNum, lineData));
                    return null;
                }
                #endregion

                #region Room Name
                // Next line is the room name
                lineData = sr.ReadLine().TrimEnd('~').Trim();
                lineNum++;

                outRoom.Name = lineData;
                #endregion

                #region Description
                // Descriptions can span multiple lines - continue reading file until we find a tilde on its own line
                StringBuilder sb = new StringBuilder();

                // Flag to break us out of the loop
                int safetyValve = 0;

                // Loop up to a defined maximum number of times
                while (safetyValve < Consts.Misc.Safety.MaxRoomDescLines)
                {
                    // Increment safetyValve
                    safetyValve++;

                    // Read the next line
                    lineData = sr.ReadLine().Trim();
                    lineNum++;

                    // Watch for a ~ on its own line to mark the end of the field
                    if (lineData.Equals("~"))
                    {
                        // The StringBuilder has the entirety of the Description now; set it
                        outRoom.Description = sb.ToString();

                        // We're done reading the description, break out
                        break;
                    }
                    else
                        // Append to the StringBuilder
                        sb.Append(lineData);
                }

                // Check if we got out due to the safety valve
                if (safetyValve == Consts.Misc.Safety.MaxRoomDescLines)
                {
                    // Log an error and return null
                    Logging.Log.Error(String.Format("Error parsing description of room {0} in area {1}: did not find end marker in expected distance", outRoom.VNUM, areaFile));
                    return null;
                }
                #endregion

                #region Room Flags & Sector Type
                // Read the next line - one line will have both room flags and sector type
                lineData = sr.ReadLine();
                lineNum++;

                // Split the line on space
                string[] splitLine = lineData.Split(' ');

                // Should be three parts; throw an error if not
                if (splitLine.Length != 3)
                {
                    // Log an error and return null
                    Logging.Log.Error(String.Format("Error parsing room flags & sector type of room {0} in area {1}: expected three parts, encountered {2} in data {3}", outRoom.VNUM, areaFile, splitLine.Length, lineData));
                    return null;
                }

                // First part is obsolete - start with part 2, room flags
                // Convert the ROM flags to RoomAttributes
                outRoom.Attributes = Helpers.ConvertROMAlphaToRoomAttributes(splitLine[1]);

                int sectType = 0;
                if (!Int32.TryParse(splitLine[2], out sectType))
                {
                    // Log an error and return null
                    Logging.Log.Error(String.Format("Error parsing sector type of room {0} in area {1}: could not convert value \"{2}\" to integer", outRoom.VNUM, areaFile, splitLine[2]));
                    return null;
                }

                // Validate the value
                if (!Enum.IsDefined(typeof(SectorType), sectType))
                {
                    // Log an error and return null
                    Logging.Log.Error(String.Format("Error parsing sector type of room {0} in area {1}: invalid sector type {2}", outRoom.VNUM, areaFile, sectType));
                    return null;
                }

                // Store the sector type
                outRoom.SectorType = (SectorType)sectType;
                #endregion

                #region Exits
                // Flag to control the exit-reading loop
                bool readingExits = true;

                // Flag to indicate we're currently reading an exit's description
                bool readingExitDescription = false;

                // Read the exit lines
                while (readingExits)
                {
                    // Instantiate a new ExitAttributes object to hold the exit data
                    Exit exit = new Exit();

                    // Read the next line
                    lineData = sr.ReadLine();
                    lineNum++;

                    // Check if the line is an S all by itself; that signals the end of th eexits section
                    if (lineData.Trim().Equals("S"))
                    {
                        Logging.Log.Debug(String.Format("Found end of room {0} at line {1}", outRoom.VNUM, lineNum));
                        readingExits = false;
                        break;
                    }

                    // Looking for an exit definition, which starts with a D
                    if (!lineData[0].Equals('D'))
                    {
                        Logging.Log.Error(String.Format("Error parsing exits of room {0} in area {1}: expected exit definition on line {2}, instead found {3}", outRoom.VNUM, areaFile, lineNum, lineData));
                        return null;
                    }
                    else
                    {
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
                    }

                    // Begin reading the exit description
                    readingExitDescription = true;

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
                    splitLine = lineData.Split(' ');

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
                    #endregion
                }

            }

            // Return the output room
            return outRoom;
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