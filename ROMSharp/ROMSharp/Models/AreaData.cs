using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace ROMSharp.Models
{
    /// <summary>
    /// Represents an area within the world
    /// </summary>
    public class AreaData
    {
        #region Properties
        /// <summary>
        /// Contains the next area in the sequence of loading
        /// </summary>
        /// <remarks>Is this needed in this code? I'm not so sure.</remarks>
        public AreaData NextArea
        {
            get { throw new NotImplementedException(); }
            set { throw new NotSupportedException(); }
        }

        /// <summary>
        /// Collection of all rooms contained within this area
        /// </summary>
        public List<RoomIndexData> Rooms {
            get
            {
                return Program.World.Rooms.Where(r => r.VNUM >= this.MinVNum && r.VNUM <= this.MaxVNum).ToList();
            }
        }

        /// <summary>
        /// Used when resetting area, identifies the first object to be reset
        /// </summary>
        /// <value>The reset first.</value>
        public ResetData ResetFirst { get; set; }

        /// <summary>
        /// Used when resetting area, identifies the last object to be reset
        /// </summary>
        /// <value>The reset last.</value>
        public ResetData ResetLast { get; set; }

        /// <summary>
        /// Filename the area was loaded from
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Name of the area
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Credits data for the information (author, license, etc.)
        /// </summary>
        /// <value>The credits.</value>
        public string Credits { get; set; }

        /// <summary>
        /// Age of the area - used to determine when the area should be reset
        /// </summary>
        /// <value>The age.</value>
        public int Age { get; set; }

        /// <summary>
        /// Number of players currently in the area
        /// </summary>
        public int NumPlayers { get; set; }

        /// <summary>
        /// Minimum VNum in the area's range
        /// </summary>
        public int MinVNum { get; set; }

        /// <summary>
        /// Maximum VNum in the area's range
        /// </summary>
        /// <value>The max VN um.</value>
        public int MaxVNum { get; set; }

        /// <summary>
        /// Indicates whether the area is empty (has no PC's within it)
        /// </summary>
        public bool IsEmpty { get { return (this.NumPlayers == 0); } }
        #endregion

        #region Constructors
        public AreaData()
        {
            this.ResetFirst = new ResetData();
            this.ResetFirst = new ResetData();
        }
        #endregion

        #region Methods
        public static AreaData LoadFromFile(string areaPath)
        {
            // Check that the file exists
            //try
            //{
                int lineNum = 0;
                string lineData;
                string areaFile = Path.GetFileName(areaPath);
                AreaReadingState state = AreaReadingState.WaitingForSection;
                AreaData areaOut = new AreaData();
            int errors = 0;
            int loaded = 0;
            bool backFromError = false;

                if (!File.Exists(areaPath))
                {
                    // Log an error and return null
                    Logging.Log.Error(String.Format("Unable to load requested area file {0}", areaPath));
                    return null;
                }

                // Instantiate a StreamReader and read the entire file
                StreamReader sr = new StreamReader(areaPath);
                string fileData = sr.ReadToEnd();
                sr.Dispose();

                // Instantiate a StreamReader for the file
                StringReader strRdr = new StringReader(fileData);

                // Parse the file, one line at a time.
                while ((lineData = strRdr.ReadLine()) != null)
                {
                    // Increment lineNum
                    lineNum++;

                    switch (state)
                    {
                        case AreaReadingState.WaitingForSection:
                            // Skip blank lines while in this state
                            if (lineData.Trim().Equals(String.Empty))
                            {
                                Logging.Log.Debug(String.Format("Skipping empty line at {0}:{1}", areaFile, lineNum));
                                continue;
                            }

                            // Expect the first data line we come across to start with #
                            if (!lineData.StartsWith("#", StringComparison.InvariantCulture))
                            {
                                // Log an error and return null
                                Logging.Log.Error(String.Format("Error parsing {0} line {1}: Expected a section identifier, instead got {2}", areaFile, lineNum, lineData));
                                return null;
                            }

                            // We've encountered a section heading; which one?
                            switch (lineData.Trim().ToUpper())
                            {
                                #region #$
                                // End-of-File Heading
                                case "#$":
                                    // Log
                                    Logging.Log.Debug(String.Format("Found #$ EOF marker in file {0} on line {1}, finishing up", areaFile, lineNum));

                                    // Set state to finished
                                    state = AreaReadingState.Finished;

                                    break;
                            #endregion

                            #region #OBJECTS
                            case "#OBJECTS":
                                Logging.Log.Debug(String.Format("Found #OBJECTS heading in file {0} on line {1}", areaFile, lineNum));

                                // Continue reading until we hit a #0
                                bool readingObjects = true;
                                backFromError = false;
                                errors = 0;
                                loaded = 0;

                                while (readingObjects)
                                {
                                    // Read a line
                                    lineData = strRdr.ReadLine();
                                    lineNum++;

                                    // If we've recently come back from failing to load a mob, we need to ignore some lines
                                    // until we get to the start of the next mob definition
                                    if (backFromError)
                                        // If the line is not the section terminator but it does begin with #, it is
                                        // (should be) a new mob definition, so un-set the backFromError flag
                                        if (!lineData.Trim().Equals("#0") && lineData.Trim().Length > 0 && lineData.Trim()[0].Equals('#'))
                                        {
                                            // Un-set the backFromError flag; it's time to resume loading
                                            backFromError = false;

                                            Logging.Log.Debug(String.Format("Resuming loading of #OBJECTS section in area {0} on line {1} with mob {2}", areaFile, lineNum, lineData.Trim()));
                                        }
                                        // Otherwise, just move on to the next iteration of the loop
                                        else
                                            continue;

                                    if (lineData == null)
                                        readingObjects = false;
                                    else if (lineData.Trim().Equals("#0"))
                                        readingObjects = false;
                                    else if (!lineData.Trim().Equals("#0") && !lineData.Trim().Equals("#$") && !lineData.Trim().Equals(""))
                                    {
                                        try
                                        {
                                            ObjectIndexData newObj = ObjectIndexData.ParseObjectData(ref strRdr, areaFile, ref lineNum, lineData);

                                            // If we have a loaded room, add it to the world
                                            if (newObj != null)
                                            {
                                                Program.World.Objects.Add(newObj);
                                                loaded++;
                                            }
                                            else
                                            {
                                                // Record a failed mob load, and set the indicator that we're back because of an error and should keep reading
                                                // but do nothing until we find a new mob
                                                errors++;
                                                backFromError = true;
                                            }
                                        }
                                        catch (ObjectParsingException ex)
                                        {
                                            Logging.Log.Error(String.Format("Error parsing object: {0}", ex.Message));
                                        }
                                    }
                                }

                                Logging.Log.Debug(String.Format("Finished reading #OBJECTS section of file {0} on line {1} - loaded {2} objects, failed loading {3} mobs", areaFile, lineNum, loaded, errors));

                                break;
                            #endregion

                            #region #RESETS
                            case "#RESETS":
                                Logging.Log.Debug(String.Format("Found #RESETS heading in file {0} on line {1}", areaFile, lineNum));

                                // Continue reading until we hit a #0
                                bool readingResets = true;
                                backFromError = false;
                                errors = 0;
                                loaded = 0;

                                while (readingResets)
                                {
                                    // Read a line
                                    lineData = strRdr.ReadLine();
                                    lineNum++;

                                    // If we've recently come back from failing to load a mob, we need to ignore some lines
                                    // until we get to the start of the next mob definition
                                    if (backFromError)
                                        // If the line is not the section terminator but it does begin with #, it is
                                        // (should be) a new mob definition, so un-set the backFromError flag
                                        if (!lineData.Trim().Equals("#0") && lineData.Trim().Length > 0 && lineData.Trim()[0].Equals('#'))
                                        {
                                            // Un-set the backFromError flag; it's time to resume loading
                                            backFromError = false;

                                            Logging.Log.Debug(String.Format("Resuming loading of #RESETS section in area {0} on line {1} with mob {2}", areaFile, lineNum, lineData.Trim()));
                                        }
                                        // Otherwise, just move on to the next iteration of the loop
                                        else
                                            continue;
                                    
                                    if (lineData == null)
                                        readingResets= false;
                                    else if (lineData.Trim().Equals("#0"))
                                        readingResets = false;
                                    else if (!lineData.Trim().Equals("#0") && !lineData.Trim().Equals("#$") && !lineData.Trim().Equals(""))
                                    {
                                        // TODO: Implement #RESETS parsing
                                    }
                                }

                                break;
                            #endregion

                            #region #SHOPS
                            case "#SHOPS":
                                Logging.Log.Debug(String.Format("Found #SHOPS heading in file {0} on line {1}", areaFile, lineNum));

                                // Continue reading until we hit a #0
                                bool readingShops = true;
                                backFromError = false;
                                errors = 0;
                                loaded = 0;

                                while (readingShops)
                                {
                                    // Read a line
                                    lineData = strRdr.ReadLine();
                                    lineNum++;

                                    // If we've recently come back from failing to load a mob, we need to ignore some lines
                                    // until we get to the start of the next mob definition
                                    if (backFromError)
                                        // If the line is not the section terminator but it does begin with #, it is
                                        // (should be) a new mob definition, so un-set the backFromError flag
                                        if (!lineData.Trim().Equals("#0") && lineData.Trim().Length > 0 && lineData.Trim()[0].Equals('#'))
                                        {
                                            // Un-set the backFromError flag; it's time to resume loading
                                            backFromError = false;

                                            Logging.Log.Debug(String.Format("Resuming loading of #SHOPS section in area {0} on line {1} with mob {2}", areaFile, lineNum, lineData.Trim()));
                                        }
                                        // Otherwise, just move on to the next iteration of the loop
                                        else
                                            continue;
                                    
                                    if (lineData == null)
                                        readingShops = false;
                                    else if (lineData.Trim().Equals("#0"))
                                        readingShops = false;
                                    else if (!lineData.Trim().Equals("#0") && !lineData.Trim().Equals("#$") && !lineData.Trim().Equals(""))
                                    {
                                        // TODO: Implement #SHOPS parsing
                                    }
                                }

                                break;
                            #endregion

                            #region #SPECIALS
                            case "#SPECIALS":
                                Logging.Log.Debug(String.Format("Found #SPECIALS heading in file {0} on line {1}", areaFile, lineNum));

                                // Continue reading until we hit a #0
                                bool readingSpecials = true;
                                backFromError = false;
                                errors = 0;
                                loaded = 0;

                                while (readingSpecials)
                                {
                                    // Read a line
                                    lineData = strRdr.ReadLine();
                                    lineNum++;

                                    // If we've recently come back from failing to load a mob, we need to ignore some lines
                                    // until we get to the start of the next mob definition
                                    if (backFromError)
                                        // If the line is not the section terminator but it does begin with #, it is
                                        // (should be) a new mob definition, so un-set the backFromError flag
                                        if (!lineData.Trim().Equals("#0") && lineData.Trim().Length > 0 && lineData.Trim()[0].Equals('#'))
                                        {
                                            // Un-set the backFromError flag; it's time to resume loading
                                            backFromError = false;

                                            Logging.Log.Debug(String.Format("Resuming loading of #SPECIALS section in area {0} on line {1} with mob {2}", areaFile, lineNum, lineData.Trim()));
                                        }
                                        // Otherwise, just move on to the next iteration of the loop
                                        else
                                            continue;
                                    
                                    if (lineData == null)
                                        readingSpecials = false;
                                    else if (lineData.Trim().Equals("#0"))
                                        readingSpecials = false;
                                    else if (!lineData.Trim().Equals("#0") && !lineData.Trim().Equals("#$") && !lineData.Trim().Equals(""))
                                    {
                                        // TODO: Implement #SPECIALS parsing
                                    }
                                }

                                break;
                            #endregion

                            #region #MOBILES
                            case "#MOBILES":
                                Logging.Log.Debug(String.Format("Found #MOBILES heading in file {0} on line {1}", areaFile, lineNum));

                                errors = 0;
                                loaded = 0;
                                backFromError = false;

                                // Continue reading until we hit a #0
                                bool readingMobs = true;
                                while (readingMobs)
                                {
                                    // Read a line
                                    lineData = strRdr.ReadLine();
                                    lineNum++;

                                    // If we've recently come back from failing to load a mob, we need to ignore some lines
                                    // until we get to the start of the next mob definition
                                    if (backFromError)
                                        // If the line is not the section terminator but it does begin with #, it is
                                        // (should be) a new mob definition, so un-set the backFromError flag
                                    if (!lineData.Trim().Equals("#0") && lineData.Trim().Length > 0 && lineData.Trim()[0].Equals('#'))
                                        {
                                            // Un-set the backFromError flag; it's time to resume loading
                                            backFromError = false;

                                            Logging.Log.Debug(String.Format("Resuming loading of #MOBILES section in area {0} on line {1} with mob {2}", areaFile, lineNum, lineData.Trim()));
                                        }
                                        // Otherwise, just move on to the next iteration of the loop
                                        else
                                            continue;

                                    if (lineData == null)
                                        readingMobs = false;
                                    else if (lineData.Trim().Equals("#0"))
                                        readingMobs = false;
                                    else if (!lineData.Trim().Equals("#0") && !lineData.Trim().Equals("#$") && !lineData.Trim().Equals(""))
                                    {
                                        MobData newMob = MobData.ParseMobData(ref strRdr, areaFile, ref lineNum, lineData);

                                        // If we have a loaded room, add it to the world
                                        if (newMob != null)
                                        {
                                            Program.World.Mobs.Add(newMob);
                                            loaded++;
                                        }
                                        else
                                        {
                                            // Record a failed mob load, and set the indicator that we're back because of an error and should keep reading
                                            // but do nothing until we find a new mob
                                            errors++;
                                            backFromError = true;
                                        }
                                    }
                                }
                                
                                Logging.Log.Debug(String.Format("Finished reading #MOBILES section of file {0} on line {1} - loaded {2} mobs, failed loading {3} mobs", areaFile, lineNum, loaded, errors));

                                break;
                            #endregion

                            #region #ROOMS
                            case "#ROOMS":
                                Logging.Log.Debug(String.Format("Found #ROOMS heading in file {0} on line {1}", areaFile, lineNum));

                                // Continue reading until we hit a #0
                                bool readingRooms = true;
                                backFromError = false;
                                errors = 0;
                                loaded = 0;

                                while (readingRooms)
                                {
                                    // Read a line
                                    lineData = strRdr.ReadLine();
                                    lineNum++;

                                    // If we've recently come back from failing to load a mob, we need to ignore some lines
                                    // until we get to the start of the next mob definition
                                    if (backFromError)
                                        // If the line is not the section terminator but it does begin with #, it is
                                        // (should be) a new mob definition, so un-set the backFromError flag
                                        if (!lineData.Trim().Equals("#0") && lineData.Trim().Length > 0 && lineData.Trim()[0].Equals('#'))
                                        {
                                            // Un-set the backFromError flag; it's time to resume loading
                                            backFromError = false;

                                            Logging.Log.Debug(String.Format("Resuming loading of #ROOMS section in area {0} on line {1} with mob {2}", areaFile, lineNum, lineData.Trim()));
                                        }
                                        // Otherwise, just move on to the next iteration of the loop
                                        else
                                            continue;

                                    if (lineData == null)
                                        readingRooms = false;
                                    else if (lineData.Trim().Equals("#0"))
                                        readingRooms = false;
                                    else if (!lineData.Trim().Equals("#0") && !lineData.Trim().Equals("#$") && !lineData.Trim().Equals(""))
                                    {
                                        RoomIndexData newRoom = RoomIndexData.ParseRoomData(ref strRdr, areaFile, ref lineNum, lineData);

                                        // If we have a loaded room, add it to the world
                                        if (newRoom != null)
                                        {
                                            loaded++;
                                            Program.World.Rooms.Add(newRoom);
                                        }
                                        else
                                        {
                                            errors++;
                                            backFromError = true;
                                        }
                                    }
                                }

                                Logging.Log.Debug(String.Format("Finished reading #ROOMS section of file {0} on line {1} - loaded {2} rooms, failed loading {3} rooms", areaFile, lineNum, loaded, errors));

                                    break;

                                default:
                                    break;
                                #endregion

                                #region #AREA
                                // AREA Heading
                                case "#AREA":
                                    Logging.Log.Debug(String.Format("Found #AREA heading in file {0} on line {1}", areaFile, lineNum));

                                    #region Filename
                                    // Read the next line - will be the area filename
                                    lineData = strRdr.ReadLine();
                                    lineNum++;

                                    // Trim the trailing tilde
                                    lineData = lineData.Substring(0, lineData.Trim().Length - 1);

                                    // Set filename
                                    areaOut.Filename = lineData;

                                    Logging.Log.Debug(String.Format("Read area filename in file {0} on line {1}", areaFile, lineNum));
                                    #endregion

                                    #region Name
                                    // Read the next line - will be the area name
                                    lineData = strRdr.ReadLine();
                                    lineNum++;

                                    // Trim the trailing tilde
                                    lineData = lineData.Substring(0, lineData.Trim().Length - 1);

                                    // Set name
                                    areaOut.Name = lineData;

                                    Logging.Log.Debug(String.Format("Read area name in file {0} on line {1}", areaFile, lineNum));
                                    #endregion

                                    #region Credits
                                    // Read the next line - will be the credits
                                    lineData = strRdr.ReadLine();
                                    lineNum++;

                                    // Trim the trailing tilde
                                    lineData = lineData.Substring(0, lineData.Trim().Length - 1);

                                    // Set credits
                                    areaOut.Credits = lineData;

                                    Logging.Log.Debug(String.Format("Read credits information in file {0} on line {1}", areaFile, lineNum));
                                    #endregion

                                    #region MinVNUM and MaxVNUM
                                    // Read the next line - will be the VNUM values
                                    lineData = strRdr.ReadLine();
                                    lineNum++;

                                    // Split the line on space
                                    string[] vnumData = lineData.Trim().Split(' ');

                                    // Should be two values
                                    if (!vnumData.Length.Equals(2))
                                    {
                                        // Log an error and return null
                                        Logging.Log.Error(String.Format("Error parsing {0} line {1}: Expected two numbers separated by space for VNUM limits, instead found {2}", areaFile, lineNum, lineData));
                                        return null;
                                    }

                                    // Tracks which of the two numbers we're on
                                    bool firstNum = true;

                                    // Loop over the two values, each should convert to an integer
                                    foreach (string vnum in vnumData)
                                    {
                                        int intVal;

                                        // Try to parse the value as a 32-bit integer
                                        if (!Int32.TryParse(vnum, out intVal))
                                        {
                                            // Log an error and return null
                                            Logging.Log.Error(String.Format("Error parsing {0} line {1}: Error converting VNUM value {2} to an integer", areaFile, lineNum, vnum));
                                            return null;
                                        }
                                        else
                                        {
                                            if (firstNum)
                                            {
                                                areaOut.MinVNum = intVal;
                                                firstNum = false;
                                            }
                                            else
                                                areaOut.MaxVNum = intVal;
                                        }
                                    }

                                    Logging.Log.Debug(String.Format("Finished processing #AREA section of file {0} at line {1}", areaFile, lineNum));
                                    #endregion

                                    break;
                                    #endregion
                            }
                            break;

                        default:
                            break;
                    }
                }

                strRdr.Dispose();

                // Return the output area
                return areaOut;
            //}
            //catch (Exception e)
            //{
            //    // Log the exception and rethrow
            //    Logging.Log.Fatal(String.Format("Unhandled exception caught: {0}: {1}\n{2}", e.GetType(), e.Message, e.StackTrace));
            //    throw (e);
            //}
        }
        #endregion

        #region Enums
        private enum AreaReadingState {
            WaitingForSection,
            AreaSection,
            Finished
        }
        #endregion
    }
}