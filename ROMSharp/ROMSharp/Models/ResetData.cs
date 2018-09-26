using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ROMSharp.Models
{
    public class MobileResetData : ResetData
    {
        #region Properties
        /// <summary>
        /// The mobile the reset is for
        /// </summary>
        public MobPrototypeData Mobile { get { return Program.World.Mobs[this.Arg1]; } }

        /// <summary>
        /// The room in which the mobile should be reset
        /// </summary>
        public RoomIndexData Room { get { return Program.World.Rooms[this.Arg3]; } }

        /// <summary>
        /// The limit of how many of this mob can exist globally; if this number is exceeded, a new mob will not be spawned
        /// </summary>
        public int GlobalLimit { get { return this.Arg2; } }

        /// <summary>
        /// The limit of how many of this mob can exist in the room; if this number is exceeded, a new mob will not be spawned
        /// </summary>
        public int RoomLimit { get { return this.Arg4; } }
        #endregion

        #region Constructors
        public MobileResetData() { this.Inner = new List<ResetData>(); }
        public MobileResetData(ResetData data) 
        {
            this.Arg1 = data.Arg1;
            this.Arg2 = data.Arg2;
            this.Arg3 = data.Arg3;
            this.Arg4 = data.Arg4;
            this.Command = data.Command;
            this.Inner = data.Inner;
        }
        #endregion
    }

    public class EquipResetData : ResetData
    {
        #region Properties
        public MobPrototypeData Mobile { get { return Program.World.Mobs[this.Arg4]; } }

        public ObjectPrototypeData Object { get { return Program.World.Objects[this.Arg1]; } }

        public int Limit { get { return this.Arg2; } }

        public Enums.WearFlag WearLocation { get { return (Enums.WearFlag)this.Arg3; } }
        #endregion

        #region Constructors
        public EquipResetData() { this.Inner = new List<ResetData>(); }
        public EquipResetData(ResetData data)
        {
            this.Arg1 = data.Arg1;
            this.Arg2 = data.Arg2;
            this.Arg3 = data.Arg3;
            this.Arg4 = data.Arg4;
            this.Command = data.Command;
            this.Inner = data.Inner;
        }
        #endregion
    }

    public class ResetData
    {
        #region Properties
        /// <summary>
        /// Determines the command the reset should perform
        /// </summary>
        public ResetCommand Command { get; set; }

        /// <summary>
        /// First argument for the reset - varies by reset type
        /// </summary>
        public int Arg1 { get; set; }

        /// <summary>
        /// Second argument for the reset - varies by reset type
        /// </summary>
        public int Arg2 { get; set; }

        /// <summary>
        /// Third argument for the reset - varies by reset type
        /// </summary>
        public int Arg3 { get; set; }

        /// <summary>
        /// Fourth argument for the reset - varies by reset type
        /// </summary>
        public int Arg4 { get; set; }

        /// <summary>
        /// Collection of resets related to this one
        /// </summary>
        public List<ResetData> Inner { get; set; }
        #endregion

        public ResetData() { Inner = new List<ResetData>();  }

        internal static ResetData ParseResetData(string areaFile, ref int lineNum, string firstLine, ResetData lastMob)
        {
            //if (log)
                //Logging.Log.Debug(String.Format("ParseResetData() called for area {0} starting on line {1}", areaFile, lineNum));

            // Instantiate variables for the method
            ResetData outReset = new ResetData();
            string lineData = firstLine;

            // Regex to parse reset lines
            Regex lineRegex = new Regex(@"^(\w){1}\s+(\d+)\s+(\d+)\s+(-*\d+)\s*(\d+)*\s*(\d+)*(\s*\*(.*))*$");

            // Attempt to parse the line
            Match match = lineRegex.Match(lineData);

            // Ensure we have at least one match so we can check the command
            if (match.Success)
            {
                string value = match.Groups[1].ToString();
                outReset.Arg1 = Convert.ToInt32(match.Groups[3].ToString());
                outReset.Arg2 = Convert.ToInt32(match.Groups[4].ToString());
                outReset.Arg3 = (value.Equals("G") || value.Equals("R")) ? 0 : Convert.ToInt32(match.Groups[5].ToString());
                outReset.Arg4 = (value.Equals("P") || value.Equals("M")) ? 0 : (match.Groups[6].Success) ? Convert.ToInt32(match.Groups[6].ToString()) : 0;

                switch (value)
                {
                    case "M":
                        // Mob reset
                        outReset.Command = ResetCommand.SpawnMobile;

                        // Validate the mob and room VNUMs
                        if (!Program.World.Mobs.Exists(m => m.VNUM == outReset.Arg1))
                        {
                            Logging.Log.Error(String.Format("Encountered unknown mobile VNUM {0} in reset data on line {1} of area {2}", outReset.Arg1, lineNum, areaFile));
                            return null;
                        }
                        else if (!Program.World.Rooms.Exists(r => r.VNUM == outReset.Arg3))
                        {
                            Logging.Log.Error(String.Format("Encountered unknown room VNUM {0} in reset data on line {1} of area {2}", outReset.Arg3, lineNum, areaFile));
                            return null;
                        }
                        else
                        {
                            Logging.Log.Debug(String.Format("Loaded mobile reset for mobile {0} in room {1} with maximum occupancy {2} for area {3}", outReset.Arg1, outReset.Arg3, outReset.Arg2, areaFile));

                            // Return the reset
                            return outReset;
                        }

                    case "E":
                        // Equip reset
                        outReset.Command = ResetCommand.EquipObjectOnMob;

                        // Ensure we have a mob
                        if (lastMob == null || lastMob.Command != ResetCommand.SpawnMobile)
                        {
                            Logging.Log.Error(String.Format("Encountered equip reset command in an invalid location, no previous mob to apply to - line {0} of area {1}", lineNum, areaFile));
                            return null;
                        }

                        // Validate the object VNUM
                        if (!Program.World.Objects.Exists(o => o.VNUM == outReset.Arg1))
                        {
                            Logging.Log.Error(String.Format("Encountered unknown object VNUM {0} in equip reset data on line {1} of area {2}", outReset.Arg1, lineNum, areaFile));
                            return null;
                        }
                        // Validate the wear location
                        else if (!Enum.TryParse<Enums.WearFlag>(outReset.Arg3.ToString(), out _))
                        {
                            Logging.Log.Error(String.Format("Encountered invalid wear location {0} in equip reset data on line {1} of area {2}", outReset.Arg3, lineNum, areaFile));
                            return null;
                        }

                        // Reset Arg2 based on the old limit rules
                        if (outReset.Arg2 > 50) outReset.Arg2 = 6;
                        else if (outReset.Arg2 == -1) outReset.Arg2 = 999;

                        Logging.Log.Debug(String.Format("Loaded equip reset for mobile {0} with item {1} in wear location {2} with limit of {3} on line {4} of area {5}", outReset.Arg4, outReset.Arg1, outReset.Arg3, outReset.Arg2, lineNum, areaFile));

                        return outReset;

                    case "O":
                        // Object reset
                        return null;

                    case "G":
                        // Give reset
                        return null;

                    case "P":
                        // Put reset
                        return null;

                    case "R":
                        // Randomize reset
                        return null;

                    case "D":
                        // Door reset
                        return null;

                    default:
                        Logging.Log.Warn(String.Format("Encountered unknown reset type {0} on line {1} in file {2}", value, lineNum, areaFile));
                        return null;
                }
            }
            else
            {
                Logging.Log.Warn(String.Format("Encountered invalid reset data ({0}) on line {1} of file {2}", lineData, lineNum, areaFile));
                return null;
            }
        }
    }

    public enum ResetCommand {
        SpawnMobile = 'M',
        SpawnObject = 'O',
        PutInObject = 'P',
        GiveObjectToMob = 'G',
        EquipObjectOnMob = 'E',
        SetDoorState = 'D',
        RandomizeExits = 'R'
    }
}
