using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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

            // Read the material
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
            splitLine = lineData.Split(' ');

            if (splitLine.Length != 5)
            {
                Logging.Log.Error(String.Format("Error parsing object {0} in area {1}: invalid values line, expected 5 segments but got {2} - value {3} on line {4}", outObj.VNUM, areaFile, splitLine.Length, lineData, lineNum));
                return null;
            }

            // The meaning and data type of each of the 5 values changes depending on the item type
            switch (outObj.ObjectType)
            {
                case ItemClass.Weapon:
                    // Segment 1 - Weapon Type, should be a string matching the Name of a WeaponClass in the WeaponTable
                    WeaponClass weapClass = Consts.WeaponClass.WeaponTable.SingleOrDefault(w => w.Name.ToLower().Equals(splitLine[0].ToLower()));

                    if (weapClass == null)
                    {
                        // Invalid weapon class
                        Logging.Log.Error(String.Format("Error parsing weapon class for object {0} in area {1}: unknown weapon class \"{2}\" found on line {3}", outObj.VNUM, areaFile, splitLine[0], lineNum));
                        return null;
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
                        return null;
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
                        return null;
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
                        return null;
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
                        return null;
                    }
                    break;

            }
            return outObj;
        }
        #endregion
    }
}
