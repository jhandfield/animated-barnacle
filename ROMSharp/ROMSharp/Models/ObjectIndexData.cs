using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using ROMSharp.Enums;
using ROMSharp.Helpers;

namespace ROMSharp.Models
{
    /// <summary>
    /// Object prototype data - represents a potential object, but not an actual materialized object
    /// </summary>
    public class ObjectIndexData
    {
        #region Properties
        /// <summary>
        /// Extra descriptions for the object
        /// </summary>
        public List<ExtraDescription> ExtraDescriptions { get; set; }

        /// <summary>
        /// Effects provided by the object
        /// </summary>
        public List<AffectData> Affected { get; set; }

        /// <summary>
        /// Whether the object definition is in the new format?
        /// </summary>
        /// <remarks>Is this needed still?</remarks>
        /// <value><c>true</c> if new format; otherwise, <c>false</c>.</value>
        public bool NewFormat { get; set; }

        /// <summary>
        /// Name of the object
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Short description of the object
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Long description of the object
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// VNUM of the object
        /// </summary>
        public int VNUM { get; set; }

        /// <summary>
        /// Reset number of the object
        /// </summary>
        public int ResetNum { get; set; }

        /// <summary>
        /// Material of the object
        /// </summary>
        public string Material { get; set; }

        /// <summary>
        /// Type of the object
        /// </summary>
        public ItemClass ObjectType { get; set; }

        /// <summary>
        /// Extra flags to describe the object
        /// </summary>
        public ItemExtraFlag ExtraFlags { get; set; }

        /// <summary>
        /// Wear flags of the object, describing how it is worn
        /// </summary>
        public WearFlag WearFlags { get; set; }

        /// <summary>
        /// Level of the object
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Condition of the object
        /// </summary>
        public int Condition { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Weight of the object
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Cost/value of the object
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// Additional values for the object, dependent on the <seealso cref="ObjectType"/>
        /// </summary>
        /// <remarks>
        /// This is probably the first place I'm diverging from the stock ROM
        /// 2.4 source code in a significant way. In the original source, there
        /// are cases where this array will contain integer representations of
        /// things like weapon types (sword, dagger, etc.) which are stored as
        /// the array index of the matching row. This is 2018, there's simpler
        /// ways to handle this now, so Values is an array of objects and we'll
        /// just know what to convert them to inherently based on other factors
        /// when the time to read them comes. Deal with it.
        /// </remarks>
        public object[] Values { get; set; }
        #endregion

        #region Constructors
        public ObjectIndexData()
        {
            Affected = new List<AffectData>();
            ExtraDescriptions = new List<ExtraDescription>();
            ExtraFlags = new ItemExtraFlag();
            WearFlags = new WearFlag();
            Values = new object[5];
        }

        internal static ObjectIndexData ParseObjectData(ref StringReader sr, string areaFile, ref int lineNum, string firstLine)
        {
            Logging.Log.Debug(String.Format("ParseObjectData() called for area {0} starting on line {1}", areaFile, lineNum));

            // Instantiate variables for the method
            ObjectIndexData outObj = new ObjectIndexData();
            string lineData = firstLine;

            // First, pull the VNUM, then set it if it's valid
            int vnum = Data.ParseVNUM(lineData);

            if (!vnum.Equals(0))
                outObj.VNUM = vnum;
            else
                return null;

            Logging.Log.Debug(String.Format("Found object definition for vnum {0} beginning on line {1}", outObj.VNUM, lineNum));

            // Set NewFormat to true - old format objects will be parsed from another method
            outObj.NewFormat = true;

            // Set reset number to zero
            outObj.ResetNum = 0;

            // Read the name
            outObj.Name = sr.ReadLine().TrimEnd('~');
            lineNum++;

            // Read the short description
            outObj.ShortDescription = sr.ReadLine().TrimEnd('~');
            lineNum++;

            // Read the long description
            outObj.Description = sr.ReadLine().TrimEnd('~');
            lineNum++;

            // Read the material - it may be oldstyle, but the original ROM code doesn't do anything with that either
            outObj.Material = sr.ReadLine().TrimEnd('~');
            lineNum++;

            // Read the next line and split, expect 3 segments
            lineData = sr.ReadLine();
            lineNum++;
            string[] splitLine = lineData.Split(' ');

            if (splitLine.Length != 3)
            {
                Logging.Log.Error(String.Format("Error parsing object {0} in area {1}: invalid type/extra flag/wear flag line, expected 3 segments but got {2} - value {3} on line {4}", outObj.VNUM, areaFile, splitLine.Length, lineData, lineNum));
                return null;
            }

            // Segment 1, item type - attempt to pull a match from the ItemTypeTable
            ItemType objType = Consts.ItemTypes.ItemTypeTable.SingleOrDefault(it => it.Name.ToLower().Equals(splitLine[0].ToLower()));

            if (objType == null)
            {
                // Invalid item type
                Logging.Log.Error(String.Format("Error parsing item type for object {0} in area {1}: unknown item type \"{2}\" found on line {3}", outObj.VNUM, areaFile, splitLine[0], lineNum));
                return null;
            }
            else
                outObj.ObjectType = objType.Type;

            // Segment 2, extra flag
            try {
                ItemExtraFlag extraFlags = AlphaConversions.ConvertROMAlphaToItemExtraFlag(splitLine[1]);
                outObj.ExtraFlags = extraFlags;
            }
            catch (ArgumentException e)
            {
                // Invalid extra flags
                Logging.Log.Error(String.Format("Error parsing extra flags for object {0} in area {1}: invalid extra flag value \"{2}\" found on line {3}", outObj.VNUM, areaFile, splitLine[1], lineNum));
                return null;
            }

            // Segment 3, wear flag
            try
            {
                WearFlag wearFlags = AlphaConversions.ConvertROMAlphaToWearFlag(splitLine[2]);
                outObj.WearFlags = wearFlags;
            }
            catch (ArgumentException e)
            {
                // Invalid extra flags
                Logging.Log.Error(String.Format("Error parsing wear flags for object {0} in area {1}: invalid extra flag value \"{2}\" found on line {3}", outObj.VNUM, areaFile, splitLine[2], lineNum));
                return null;
            }

            // Read the next line and split, expect 5 segments
            lineData = sr.ReadLine();
            lineNum++;

            string[] splitValues = ParseValuesLine(lineData, outObj, areaFile, lineNum);

            if (splitValues.Length != 5)
            {
                Logging.Log.Error(String.Format("Error parsing object {0} in area {1}: invalid values line, expected 5 segments but got {2} - value {3} on line {4}", outObj.VNUM, areaFile, splitLine.Length, lineData, lineNum));
                return null;
            }
            /*
            Regex valuesLineRegex = new Regex(@"('?.+'?)\s('?.+'?)\s('?.+'?)\s('?.+'?)\s?('?.+'?)?");
            Match matches = valuesLineRegex.Match(lineData);

            if (matches.Captures.Count != 5)
            {
                Logging.Log.Error(String.Format("Error parsing object {0} in area {1}: invalid values line, expected 5 segments but got {2} - value {3} on line {4}", outObj.VNUM, areaFile, splitLine.Length, lineData, lineNum));
                return null;
            }
            */

            // The meaning and data type of each of the 5 values changes depending on the item type
            // TODO: Finish implementing with Regex
            switch (outObj.ObjectType)
            {
                case ItemClass.Weapon:
                    // Parse and set values
                    if (!SetWeaponValues(splitValues, outObj, areaFile, lineNum))
                        // An error was encountered, return a null object
                        return null;
                    
                    break;

                case ItemClass.Container:
                    // Parse and set values
                    if (!SetContainerValues(splitValues, outObj, areaFile, lineNum))
                        // An error was encountered, return a null object
                        return null;

                    break;

                case ItemClass.DrinkContainer:
                case ItemClass.Fountain:
                    // Parse and set values
                    if (!SetFountainAndDrinkContainerValues(splitValues, outObj, areaFile, lineNum))
                        // An error was encountered, return a null object
                        return null;

                    break;

                case ItemClass.Wand:
                case ItemClass.Staff:
                    // Parse and set values
                    if (!SetWandAndStaffValues(splitValues, outObj, areaFile, lineNum))
                        // An error was encountered, return a null object
                        return null;

                    break;
                case ItemClass.Potion:
                case ItemClass.Pill:
                case ItemClass.Scroll:
                    // Parse and set values
                    if (!SetPotionPillScrollValues(splitValues, outObj, areaFile, lineNum))
                        // An error was encountered, return a null object
                        return null;

                    break;
                default:
                    // Parse and set values
                    if (!SetOtherItemTypeValues(splitValues, outObj, areaFile, lineNum))
                        // An error was encountered, return a null object
                        return null;
                    
                    break;
            }

            // Read the next line and split, expect 4 segments
            lineData = sr.ReadLine();
            lineNum++;
            splitLine = lineData.Split(' ');

            if (splitLine.Length != 4)
            {
                Logging.Log.Error(String.Format("Error parsing object {0} in area {1}: invalid level/weight/cost/condition line, expected 4 segments but got {2} - value {3} on line {4}", outObj.VNUM, areaFile, splitLine.Length, lineData, lineNum));
                return null;
            }

            // Segment 1 - Level
            int lvl = 0;
            if (!Int32.TryParse(splitLine[0], out lvl))
            {
                Logging.Log.Error(String.Format("Error parsing level for object {0} in area {1}: expected an integer but found \"{2}\" on line {3}", outObj.VNUM, areaFile, splitLine[0], lineNum));
                return null;
            }
            else
                outObj.Level = lvl;
            
            // Segment 2 - Weight
            int weight = 0;
            if (!Int32.TryParse(splitLine[1], out lvl))
            {
                Logging.Log.Error(String.Format("Error parsing weight for object {0} in area {1}: expected an integer but found \"{2}\" on line {3}", outObj.VNUM, areaFile, splitLine[1], lineNum));
                return null;
            }
            else
                outObj.Weight = weight;
            
            // Segment 3 - Cost
            int cost = 0;
            if (!Int32.TryParse(splitLine[2], out lvl))
            {
                Logging.Log.Error(String.Format("Error parsing cost for object {0} in area {1}: expected an integer but found \"{2}\" on line {3}", outObj.VNUM, areaFile, splitLine[2], lineNum));
                return null;
            }
            else
                outObj.Cost = cost;

            // Segment 4 - Condition
            switch (splitLine[3].ToLower())
            {
                case "P":
                    outObj.Condition = 100;
                    break;
                case "G":
                    outObj.Condition = 90;
                    break;
                case "A":
                    outObj.Condition = 75;
                    break;
                case "W":
                    outObj.Condition = 50;
                    break;
                case "D":
                    outObj.Condition = 25;
                    break;
                case "B":
                    outObj.Condition = 10;
                    break;
                case "R":
                    outObj.Condition = 0;
                    break;
                default:
                    outObj.Condition = 100;
                    break;
            }

            bool readingAffects = true;

            while (readingAffects)
            {
                // Peek at the start of the next line
                char nextLineStart = (char)sr.Peek();

                // If the next line does not start with a #, we have more to do
                if (!nextLineStart.Equals('#'))
                {
                    AffectData aff = new AffectData();

                    // Read the full line (more just to advance the cursor than anything; we've already read all the data)
                    lineData = sr.ReadLine();
                    lineNum++;

                    // Different behavior for different characters
                    switch (lineData.Trim().ToLower())
                    {
                        // Permanent affect
                        case "a":
                            // Read and split the next line for location and modifier
                            lineData = sr.ReadLine();
                            lineNum++;
                            splitLine = lineData.Split(' ');

                            // Should be two elements
                            if (splitLine.Length != 2)
                            {
                                Logging.Log.Error(String.Format("Error parsing object {0} in area {1}: invalid affect line, expected 2 segments but got {2} - value {3} on line {4}", outObj.VNUM, areaFile, splitLine.Length, lineData, lineNum));
                                return null;
                            }

                            // Set up properties of the affect
                            aff.Where = ToWhere.Object;
                            aff.Type = -1;
                            aff.Level = outObj.Level;
                            aff.Duration = -1;
                            aff.BitVector = 0;

                            // Segment 1 - Location
                            int location = 0;
                            if (!Int32.TryParse(splitLine[0], out location))
                            {
                                Logging.Log.Error(String.Format("Error parsing location for object {0} affect in area {1}: expected an integer but found \"{2}\" on line {3}", outObj.VNUM, areaFile, splitLine[0], lineNum));
                                return null;
                            }
                            else
                                aff.Location = (ApplyType)location;

                            // Segment 2 - Modifier
                            int modifier = 0;
                            if (!Int32.TryParse(splitLine[1], out modifier))
                            {
                                Logging.Log.Error(String.Format("Error parsing modifier for object {0} affect in area {1}: expected an integer but found \"{2}\" on line {3}", outObj.VNUM, areaFile, splitLine[1], lineNum));
                                return null;
                            }
                            else
                                aff.Modifier = modifier;

                            Logging.Log.Info(String.Format("Object affect to {0} with modifier {1} added to object {2}", aff.Location.ToString(), aff.Modifier, outObj.VNUM));

                            // Add the affect to the object
                            outObj.Affected.Add(aff);

                            break;

                        case "f":
                            // Read and split the next line for location and modifier
                            lineData = sr.ReadLine();
                            lineNum++;
                            splitLine = lineData.Split(' ');

                            // Should be two elements
                            if (splitLine.Length != 4)
                            {
                                Logging.Log.Error(String.Format("Error parsing object {0} in area {1}: invalid affect line, expected 4 segments but got {2} - value {3} on line {4}", outObj.VNUM, areaFile, splitLine.Length, lineData, lineNum));
                                return null;
                            }

                            // Set up properties of the affect
                            aff.Type = -1;
                            aff.Level = outObj.Level;
                            aff.Duration = -1;

                            // Segment 1 - Flag type (A, I, R, or V)
                            switch (splitLine[0].ToLower())
                            {
                                case "a":
                                    aff.Where = ToWhere.Affects;
                                    break;
                                case "i":
                                    aff.Where = ToWhere.Immune;
                                    break;
                                case "r":
                                    aff.Where = ToWhere.Resist;
                                    break;
                                case "v":
                                    aff.Where = ToWhere.Vuln;
                                    break;
                                default:
                                    Logging.Log.Error(String.Format("Error parsing affect flags for object {0} in area {1}: invalid flag location type \"{2}\" encountered, expected A, I, R, or V on line {3}", outObj.VNUM, areaFile, splitLine[1], lineNum));
                                    return null;
                                    break;
                            }

                            // Segment 2 - Location
                            int flagLocation = 0;
                            if (!Int32.TryParse(splitLine[1], out flagLocation))
                            {
                                Logging.Log.Error(String.Format("Error parsing affect flags location for object {0} in area {1}: expected an integer but found \"{2}\" on line {3}", outObj.VNUM, areaFile, splitLine[1], lineNum));
                                return null;
                            }
                            else
                                aff.Location = (ApplyType)flagLocation;

                            // Segment 3 - Modifier
                            int flagMod = 0;
                            if (!Int32.TryParse(splitLine[2], out flagMod))
                            {
                                Logging.Log.Error(String.Format("Error parsing affect flags modifier for object {0} affect in area {1}: expected an integer but found \"{2}\" on line {3}", outObj.VNUM, areaFile, splitLine[2], lineNum));
                                return null;
                            }
                            else
                                aff.Modifier = flagMod;

                            // Segment 4 - Bitvector (value of the flag to apply)
                            try
                            {
                                int bitvector = AlphaConversions.ConvertROMAlphaToInt32(splitLine[3]);
                                aff.BitVector = bitvector;
                            }
                            catch (ArgumentException e)
                            {
                                // Invalid extra flags
                                Logging.Log.Error(String.Format("Error parsing affect flags bitvector for object {0} in area {1}: invalid flag value \"{2}\" found on line {3}", outObj.VNUM, areaFile, splitLine[3], lineNum));
                                return null;
                            }

                            Logging.Log.Info(String.Format("Object affect flag loaded to {0} modifying {1} with modifier {2} and bitvector {3} on object {4} in area {5}", aff.Where.ToString(), aff.Location.ToString(), aff.Modifier, aff.BitVector, outObj.VNUM, areaFile));

                            // Add the affect
                            outObj.Affected.Add(aff);
                            break;
                        case "e":
                            // Object extra descriptions
                            // TODO: This is an almost straight copy of extra description loading in rooms, should be made its own method
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

                            Logging.Log.Info(String.Format("Extra description loaded for object {0} in area {1} with keywords {2}", outObj.VNUM, areaFile, desc.Keywords));

                            // Append the ExtraDescription to the object
                            outObj.ExtraDescriptions.Add(desc);
                            break;
                        default:
                            Logging.Log.Warn(String.Format("Invalid object modifier \"{0}\" found in object {1} in area {2} on line {3}", lineData.Trim(), outObj.VNUM, areaFile, lineNum));
                            break;
                    }
                }
                else
                    // We're done with this object
                    readingAffects = false;
            }


            return outObj;
        }

        private static string[] ParseValuesLine(string lineData, ObjectIndexData outObj, string areaFile, int lineNum)
        {
            string[] splitInput = lineData.Split(' ');
            string[] output = new string[5];
            bool inQuoted = false;
            int count = 0;
            string buf = String.Empty;

            foreach (string val in splitInput)
            {
                if (!inQuoted && (!val.StartsWith("'") || (val.StartsWith("'") && val.EndsWith("'"))))
                {
                    output[count] = val.Trim('\'');
                    count++;
                }
                else if (inQuoted && val.EndsWith("'"))
                {
                    output[count] = buf + " " + val.Trim('\'');
                    Logging.Log.Info(String.Format("VALUES LINE: Added value {0} to output", output[count]));
                    count++;
                    inQuoted = false;
                }
                else if (inQuoted && !val.EndsWith("'"))
                {
                    buf += " " + val.Trim('\'');
                }
                else if (val.StartsWith("'") && !val.EndsWith("'"))
                {
                    buf = val.Trim('\'');
                    inQuoted = true;
                }
            }

            return output;
        }

        private static bool SetValue_Int(string value, ref object objValue, string description, string areaFile, int lineNum, int vnum)
        {
            int parsedValue = 0;
            if (!Int32.TryParse(value, out parsedValue))
            {
                // Invalid damage dice number
                Logging.Log.Error(String.Format("Error parsing integer value for {0} object {1} in area {2}: expected an integer but found \"{3}\" on line {4}", description, vnum, areaFile, value, lineNum));
                return false;
            }
            else
                // Store the damage dice number
                objValue = parsedValue;

            return true;
        }

        private static bool SetValue_Skill(string value, ref object objValue, string description, string areaFile, int lineNum, int vnum)
        {
            // Check that there's actually something to look for
            if (!String.IsNullOrEmpty(value))
            {
                SkillType skill = Consts.Skills.SkillTable.SingleOrDefault(s => s.Name.ToLower().Equals(value.ToLower()));

                if (skill == null)
                {
                    // Unknown skill
                    Logging.Log.Error(String.Format("Error parsing skill \"{0}\" for {1} object {2} in area {3} on line {4}", value, description, vnum, areaFile, lineNum));
                    return false;
                }
                else
                    // Store the skill
                    objValue = skill;
            }

            return true;
        }

        /// <summary>
        /// Sets the Values array of <paramref name="outObj"/> based on input values from <paramref name="splitLine"/> appropriate where object type is Wand or Staff
        /// </summary>
        /// <returns><c>true</c> if values were set without errors, <c>false</c> otherwise. Errors are logged within this method.</returns>
        /// <param name="splitLine">Array of values to parse</param>
        /// <param name="outObj">Object whose Values property should be set</param>
        /// <param name="areaFile">Filename of the area file being parsed, used for error messages</param>
        /// <param name="lineNum">Line number the values came from, used for error messages</param>
        private static bool SetOtherItemTypeValues(string[] splitLine, ObjectIndexData outObj, string areaFile, int lineNum)
        {
            // All segments should be parsed as ints
            outObj.Values[0] = SetValue_Int(splitLine[0], ref outObj.Values[0], "other type", areaFile, lineNum, outObj.VNUM);
            outObj.Values[1] = SetValue_Int(splitLine[1], ref outObj.Values[1], "other type", areaFile, lineNum, outObj.VNUM);
            outObj.Values[2] = SetValue_Int(splitLine[2], ref outObj.Values[2], "other type", areaFile, lineNum, outObj.VNUM);
            outObj.Values[3] = SetValue_Int(splitLine[3], ref outObj.Values[3], "other type", areaFile, lineNum, outObj.VNUM);
            outObj.Values[4] = SetValue_Int(splitLine[4], ref outObj.Values[4], "other type", areaFile, lineNum, outObj.VNUM);

            return true;
        }

        /// <summary>
        /// Sets the Values array of <paramref name="outObj"/> based on input values from <paramref name="splitLine"/> appropriate where object type is Wand or Staff
        /// </summary>
        /// <returns><c>true</c> if values were set without errors, <c>false</c> otherwise. Errors are logged within this method.</returns>
        /// <param name="splitLine">Array of values to parse</param>
        /// <param name="outObj">Object whose Values property should be set</param>
        /// <param name="areaFile">Filename of the area file being parsed, used for error messages</param>
        /// <param name="lineNum">Line number the values came from, used for error messages</param>
        private static bool SetPotionPillScrollValues(string[] splitLine, ObjectIndexData outObj, string areaFile, int lineNum)
        {
            // Segment 1 - Level, should be an integer
            outObj.Values[0] = SetValue_Int(splitLine[0], ref outObj.Values[0], "potion, pill, or scroll", areaFile, lineNum, outObj.VNUM);

            // Segment 2 - Spell #1, should be a skill
            outObj.Values[1] = SetValue_Skill(splitLine[1], ref outObj.Values[1], "potion, pill, or scroll", areaFile, lineNum, outObj.VNUM);

            // Segment 3 - Spell #2, should be a skill
            outObj.Values[2] = SetValue_Skill(splitLine[2], ref outObj.Values[2], "potion, pill, or scroll", areaFile, lineNum, outObj.VNUM);

            // Segment 4 - Spell #3, should be a skill
            outObj.Values[3] = SetValue_Skill(splitLine[3], ref outObj.Values[3], "potion, pill, or scroll", areaFile, lineNum, outObj.VNUM);

            // Segment 5 - Spell #4, should be a skill
            outObj.Values[4] = SetValue_Skill(splitLine[4], ref outObj.Values[4], "potion, pill, or scroll", areaFile, lineNum, outObj.VNUM);

            return true;
        }

        /// <summary>
        /// Sets the Values array of <paramref name="outObj"/> based on input values from <paramref name="splitLine"/> appropriate where object type is Wand or Staff
        /// </summary>
        /// <returns><c>true</c> if values were set without errors, <c>false</c> otherwise. Errors are logged within this method.</returns>
        /// <param name="splitLine">Array of values to parse</param>
        /// <param name="outObj">Object whose Values property should be set</param>
        /// <param name="areaFile">Filename of the area file being parsed, used for error messages</param>
        /// <param name="lineNum">Line number the values came from, used for error messages</param>
        private static bool SetWandAndStaffValues(string[] splitLine, ObjectIndexData outObj, string areaFile, int lineNum)
        {
            // Segment 1 - Level, should be an integer
            outObj.Values[0] = SetValue_Int(splitLine[0], ref outObj.Values[0], "staff or wand", areaFile, lineNum, outObj.VNUM);
            
            // Segment 2 - Current charges, should be an integer
            outObj.Values[1] = SetValue_Int(splitLine[1], ref outObj.Values[1], "staff or wand", areaFile, lineNum, outObj.VNUM);

            // Segment 3 - Max charges, should be an integer
            outObj.Values[2] = SetValue_Int(splitLine[2], ref outObj.Values[2], "staff or wand", areaFile, lineNum, outObj.VNUM);

            // Segment 4 - Skill for wielding
            outObj.Values[3] = SetValue_Skill(splitLine[3], ref outObj.Values[3], "staff or wand", areaFile, lineNum, outObj.VNUM);

            // Segment 5 - Appears to be unused, but should be an integer
            outObj.Values[3] = SetValue_Int(splitLine[4], ref outObj.Values[3], "staff or wand", areaFile, lineNum, outObj.VNUM);

            return true;
        }

        /// <summary>
        /// Sets the Values array of <paramref name="outObj"/> based on input values from <paramref name="splitLine"/> appropriate where object type is DrinkContainer or Fountain
        /// </summary>
        /// <returns><c>true</c> if values were set without errors, <c>false</c> otherwise. Errors are logged within this method.</returns>
        /// <param name="splitLine">Array of values to parse</param>
        /// <param name="outObj">Object whose Values property should be set</param>
        /// <param name="areaFile">Filename of the area file being parsed, used for error messages</param>
        /// <param name="lineNum">Line number the values came from, used for error messages</param>
        private static bool SetFountainAndDrinkContainerValues(string[] splitLine, ObjectIndexData outObj, string areaFile, int lineNum)
        {
            // Segment 1 - Container capacity, should be an integer
            int capacity = 0;
            if (!Int32.TryParse(splitLine[0], out capacity))
            {
                // Invalid damage dice number
                Logging.Log.Error(String.Format("Error parsing capacity for fountain/drink container object {0} in area {1}: expected an integer but found \"{2}\" on line {3}", outObj.VNUM, areaFile, splitLine[0], lineNum));
                return false;
            }
            else
                // Store the damage dice number
                outObj.Values[0] = capacity;
            
            // Segment 2 - Container fill level, should be an integer
            int fillLevel = 0;
            if (!Int32.TryParse(splitLine[1], out fillLevel))
            {
                // Invalid damage dice number
                Logging.Log.Error(String.Format("Error parsing fill level for fountain/drink container object {0} in area {1}: expected an integer but found \"{2}\" on line {3}", outObj.VNUM, areaFile, splitLine[1], lineNum));
                return false;
            }
            else
                // Store the damage dice number
                outObj.Values[1] = fillLevel;


            // Segment 3 - Liquid Type, should be a string matching the Name of a LiquidType in the LiquidTable
            string liqType = String.Empty;

            if (splitLine[2].StartsWith("'"))
            {
                int i = 2;
                string nextElem;

                do
                {
                    nextElem = splitLine[i++];
                    liqType += " " + nextElem;
                }
                while (!nextElem.EndsWith("'"));

                liqType = liqType.Trim().Trim('\'');
            }
            else
                liqType = splitLine[2];
            
            LiquidType liqiudType = Consts.Liquids.LiquidTable.SingleOrDefault(l => l.Name.ToLower().Equals(liqType.ToLower()));

            if (liqiudType == null)
            {
                // Invalid weapon class
                Logging.Log.Error(String.Format("Error parsing liquid type for fountain/drink container object {0} in area {1}: unknown liquid type \"{2}\" found on line {3}", outObj.VNUM, areaFile, splitLine[2], lineNum));
                return false;
            }
            else
                // Store the weapon class
                outObj.Values[2] = liqiudType;

            // Segment 4 - Appears to be unused, but should be an integer
            //int unknown4 = 0;
            //if (!Int32.TryParse(splitLine[3], out unknown4))
            //{
            //    // Invalid damage dice number
            //    Logging.Log.Error(String.Format("Error parsing unknown value 4 for fountain/drink container object {0} in area {1}: expected an integer but found \"{2}\" on line {3}", outObj.VNUM, areaFile, splitLine[3], lineNum));
            //    return false;
            //}
            //else
            //    // Store the damage dice number
            //    outObj.Values[0] = unknown4;


            //// Segment 5 - Appears to be unused, but should be an integer
            //int unknown5 = 0;
            //if (!Int32.TryParse(splitLine[4], out unknown5))
            //{
            //    // Invalid damage dice number
            //    Logging.Log.Error(String.Format("Error parsing unknown value 5 for fountain/drink container object {0} in area {1}: expected an integer but found \"{2}\" on line {3}", outObj.VNUM, areaFile, splitLine[4], lineNum));
            //    return false;
            //}
            //else
                //// Store the damage dice number
                //outObj.Values[4] = unknown5;

            return true;
        }
        /// <summary>
        /// Sets the Values array of <paramref name="outObj"/> based on input values from <paramref name="splitLine"/> appropriate where object type is Container
        /// </summary>
        /// <returns><c>true</c> if values were set without errors, <c>false</c> otherwise. Errors are logged within this method.</returns>
        /// <param name="splitLine">Array of values to parse</param>
        /// <param name="outObj">Object whose Values property should be set</param>
        /// <param name="areaFile">Filename of the area file being parsed, used for error messages</param>
        /// <param name="lineNum">Line number the values came from, used for error messages</param>
        private static bool SetContainerValues(string[] splitLine, ObjectIndexData outObj, string areaFile, int lineNum)
        {
            // Segment 1 - Capacity, should be an integer
            int capacity = 0;
            if(!Int32.TryParse(splitLine[0], out capacity))
            {
                // Invalid damage dice number
                Logging.Log.Error(String.Format("Error parsing capacity for container object {0} in area {1}: expected an integer but found \"{2}\" on line {3}", outObj.VNUM, areaFile, splitLine[0], lineNum));
                return false;
            }
            else
                // Store the damage dice number
                outObj.Values[0] = capacity;

            // Segment 2 - Flags, should be a string matching Container flags
            try
            {
                ContainerFlag conFlags = AlphaConversions.ConvertROMAlphaToContainerFlag(splitLine[1]);
                outObj.Values[1] = conFlags;
            }
            catch (ArgumentException e)
            {
                // Invalid extra flags
                Logging.Log.Error(String.Format("Error parsing container flags for object {0} in area {1}: invalid weapon flag value \"{2}\" found on line {3}", outObj.VNUM, areaFile, splitLine[1], lineNum));
                return false;
            }

            // Segment 3 - Appears to be unused, but should be an integer
            int unknown = 0;
            if (!Int32.TryParse(splitLine[2], out unknown))
            {
                // Invalid damage dice number
                Logging.Log.Error(String.Format("Error parsing unknown value (value #3) for container object {0} in area {1}: expected an integer but found \"{2}\" on line {3}", outObj.VNUM, areaFile, splitLine[2], lineNum));
                return false;
            }
            else
                // Store the damage dice number
                outObj.Values[2] = unknown;

            // Segment 4 - Maximum weight, should be an integer
            int maxWeight = 0;
            if (!Int32.TryParse(splitLine[3], out capacity))
            {
                // Invalid damage dice number
                Logging.Log.Error(String.Format("Error parsing maximum weight for container object {0} in area {1}: expected an integer but found \"{2}\" on line {3}", outObj.VNUM, areaFile, splitLine[3], lineNum));
                return false;
            }
            else
                // Store the damage dice number
                outObj.Values[3] = maxWeight;

            // Segment 5 - Weight multiplier, should be an integer
            int weightMult = 0;
            if (!Int32.TryParse(splitLine[4], out capacity))
            {
                // Invalid damage dice number
                Logging.Log.Error(String.Format("Error parsing weight multiplier for container object {0} in area {1}: expected an integer but found \"{2}\" on line {3}", outObj.VNUM, areaFile, splitLine[4], lineNum));
                return false;
            }
            else
                // Store the damage dice number
                outObj.Values[4] = weightMult;

            return true;
        }
        /// <summary>
        /// Sets the Values array of <paramref name="outObj"/> based on input values from <paramref name="splitLine"/> appropriate where object type is Weapon
        /// </summary>
        /// <returns><c>true</c> if values were set without errors, <c>false</c> otherwise. Errors are logged within this method.</returns>
        /// <param name="splitLine">Array of values to parse</param>
        /// <param name="outObj">Object whose Values property should be set</param>
        /// <param name="areaFile">Filename of the area file being parsed, used for error messages</param>
        /// <param name="lineNum">Line number the values came from, used for error messages</param>
        private static bool SetWeaponValues(string[] splitLine, ObjectIndexData outObj, string areaFile, int lineNum)
        {
            // Segment 1 - Weapon Type, should be a string matching the Name of a WeaponClass in the WeaponTable
            WeaponClass weapClass = Consts.WeaponClass.WeaponTable.SingleOrDefault(w => w.Name.ToLower().Equals(splitLine[0].ToLower()));

            if (weapClass == null)
            {
                // Invalid weapon class
                Logging.Log.Error(String.Format("Error parsing weapon class for object {0} in area {1}: unknown weapon class \"{2}\" found on line {3}", outObj.VNUM, areaFile, splitLine[0], lineNum));
                return false;
            }
            else
                // Store the weapon class
                outObj.Values[0] = weapClass;

            // Segment 2 - Damage dice number, should be an integer
            int damDiceNum;
            if (!Int32.TryParse(splitLine[1], out damDiceNum))
            {
                // Invalid damage dice number
                Logging.Log.Error(String.Format("Error parsing weapon damage dice number for object {0} in area {1}: expected an integer but found \"{2}\" on line {3}", outObj.VNUM, areaFile, splitLine[1], lineNum));
                return false;
            }
            else
                // Store the damage dice number
                outObj.Values[1] = damDiceNum;

            // Segment 3 - Damage dice type, should be an integer
            int damDiceType;
            if (!Int32.TryParse(splitLine[2], out damDiceType))
            {
                // Invalid damage dice number
                Logging.Log.Error(String.Format("Error parsing weapon damage dice type for object {0} in area {1}: expected an integer but found \"{2}\" on line {3}", outObj.VNUM, areaFile, splitLine[2], lineNum));
                return false;
            }
            else
                // Store the damage dice number
                outObj.Values[2] = damDiceType;

            // Segment 4 - Attack Type, should be a string matching the Abreviation of a DamageType in the AttackTable
            DamageType damType = Consts.DamageTypes.AttackTable.SingleOrDefault(w => w.Abbreviation.ToLower().Equals(splitLine[3].ToLower()));

            if (weapClass == null)
            {
                // Invalid weapon class
                Logging.Log.Error(String.Format("Error parsing attack type for object {0} in area {1}: unknown attachk type \"{2}\" found on line {3}", outObj.VNUM, areaFile, splitLine[3], lineNum));
                return false;
            }
            else
                // Store the weapon class
                outObj.Values[3] = damType;

            // Segment 5 - Weapon Flags
            try
            {
                WeaponFlag weapFlags = AlphaConversions.ConvertROMAlphaToWeaponFlag(splitLine[4]);
                outObj.Values[4] = weapFlags;
            }
            catch (ArgumentException e)
            {
                // Invalid extra flags
                Logging.Log.Error(String.Format("Error parsing weapon flags for object {0} in area {1}: invalid weapon flag value \"{2}\" found on line {3}", outObj.VNUM, areaFile, splitLine[4], lineNum));
                return false;
            }

            return true;
        }
        #endregion
    }
}
