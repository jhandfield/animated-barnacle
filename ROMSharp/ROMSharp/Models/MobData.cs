using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using ROMSharp.Enums;
using ROMSharp.Helpers;

namespace ROMSharp.Models
{
    public class MobData
    {
        #region Properties
        public int VNUM { get; set; }
        public int Group { get; set; }
        public int Count { get; set; }
        public int Killed { get; set;  }
        public string Name { get; set;  }
        public string ShortDescription { get; set;  }
        public string LongDescription { get; set; }
        public string Description { get; set; }     // So many descriptions...
        public ActionFlag Actions { get; set; }
        public AffectedByFlag AffectedBy { get; set; }
        public int Alignment { get; set; }
        public int Level { get; set; }
        public int HitRoll { get; set; }

        /// <summary>
        /// Mobile's health. Stored as an array of three dimensions - dice
        /// number, dice type, and dice bonus, representing D&amp;D-style notation
        /// such as 2d10+5 (elements 0 - 2 having the values 2, 10, and 5)
        /// </summary>
        public DiceRoll Health { get; set; }

        /// <summary>
        /// Mobile's mana dice. Stored as an array of three dimensions - dice
        /// number, dice type, and dice bonus, representing D&amp;D-style notation
        /// such as 2d10+5 (elements 0 - 2 having the values 2, 10, and 5)
        /// </summary>
        public DiceRoll Mana { get; set; }

        /// <summary>
        /// Mobile's damage dice. Stored as an array of three dimensions - dice
        /// number, dice type, and dice bonus, representing D&amp;D-style notation
        /// such as 2d10+5 (elements 0 - 2 having the values 2, 10, and 5)
        /// </summary>
        public DiceRoll Damage { get; set; }

        /// <summary>
        /// The type of damage inflicted by the mobile
        /// </summary>
        public DamageType DamageType { get; set; }

        /// <summary>
        /// Mobile's armor rating against damage types
        /// </summary>
        public ArmorRating ArmorRating { get; set; }

        /// <summary>
        /// The mobile's offensive capabilities
        /// </summary>
        public OffensiveFlag Offense { get; set; }

        /// <summary>
        /// The mobile's immunities
        /// </summary>
        public ImmunityFlag Immunity { get; set; }

        /// <summary>
        /// The mobile's resistances
        /// </summary>
        public ResistanceFlag Resistance { get; set; }

        /// <summary>
        /// The mobile's vulnerabilities
        /// </summary>
        public VulnerabilityFlag Vulnerability { get; set; }

        /// <summary>
        /// The position the mob starts in
        /// </summary>
        public Position StartingPosition { get; set; }

        /// <summary>
        /// The position the mob defaults to
        /// </summary>
        /// <value>The default position.</value>
        public Position DefaultPosition { get; set; }

        /// <summary>
        /// Gender of the mob
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Race of the mob
        /// </summary>
        public Race Race { get; set; }

        /// <summary>
        /// The wealth of the mob (amount of gold on its person)
        /// </summary>
        /// <value>The wealth.</value>
        public int Wealth { get; set; }

        /// <summary>
        /// The form of the mob (e.g. Edible, Magical, Spider)
        /// </summary>
        public FormFlag Form { get; set; }

        /// <summary>
        /// The parts of the mob (e.g. head, feet, hands, etc.)
        /// </summary>
        public PartFlag Parts { get; set; }

        /// <summary>
        /// The size of the mob
        /// </summary>
        public Size Size { get; set; }

        /// <summary>
        /// The material the mob is made of
        /// </summary>
        public string Material { get; set; }

        #endregion

        #region Constructors
        public MobData()
        {
            Actions = new ActionFlag();
            AffectedBy = new AffectedByFlag();
            Health = new DiceRoll();
            Mana = new DiceRoll();
            Damage = new DiceRoll();
            ArmorRating = new ArmorRating();
            Offense = new OffensiveFlag();
            Immunity = new ImmunityFlag();
            Resistance = new ResistanceFlag();
            Vulnerability = new VulnerabilityFlag();
        }

        internal static MobData ParseMobData(ref StringReader sr, string areaFile, ref int lineNum, string firstLine)
        {
            Logging.Log.Debug(String.Format("ParseMobData() called for area {0} starting on line {1}", areaFile, lineNum));

            // Instantiate variables for the method
            MobData outMob = new MobData();
            string lineData = firstLine;

            // First, pull the VNUM, then set it if it's valid
            int vnum = Data.ParseVNUM(lineData);

            if (!vnum.Equals(0))
                outMob.VNUM = vnum;
            else
                return null;

            Logging.Log.Debug(String.Format("Found mob definition for vnum {0} beginning on line {1}", outMob.VNUM, lineNum));

            // Read the mob name - technically we should just read 'til we get a tilde, but it looks like they're always on one line anyway...
            outMob.Name = sr.ReadLine().TrimEnd('~');
            lineNum++;

            // Next, read the short description; again, a single line
            outMob.ShortDescription = sr.ReadLine().TrimEnd('~');
            lineNum++;

            // Then, read the long description
            outMob.LongDescription = Data.ReadLongText(sr, ref lineNum, areaFile, outMob.VNUM);

            // Finally, read yet another description
            outMob.Description = Data.ReadLongText(sr, ref lineNum, areaFile, outMob.VNUM);

            // TODO: Capitalize the first letter of LongDescription and Description. Or don't, I'm not your dad.

            // Next, parse the race
            string mobRaceName = sr.ReadLine().TrimEnd('~');
            lineNum++;

            Race mobRace = Consts.Races.RaceTable.SingleOrDefault(r => r.Name.ToLower().Equals(mobRaceName.ToLower()));

            // If we can't find the race, log a warning and return null
            if (mobRace == null)
            {
                Logging.Log.Error(String.Format("Encountered unknown race {0} for mob {1} of area {2} on line {3}", mobRaceName, outMob.VNUM, areaFile, lineNum));
                return null;
            }
            else
            {
                // Otherwise, store the race
                outMob.Race = mobRace;

                // Race defaults a number of flags; set these now
                outMob.Form = outMob.Race.Form;
                outMob.Parts = outMob.Race.Parts;
                outMob.Actions = outMob.Race.Actions;
                outMob.AffectedBy = outMob.Race.Affects;
                outMob.Immunity = outMob.Race.Immunities;
                outMob.Resistance = outMob.Race.Resistances;
                outMob.Vulnerability = outMob.Race.Vulnerabilities;
            }

            // Split the next line into an array that should have four elements
            lineData = sr.ReadLine();
            lineNum++;

            string[] splitLine = lineData.Split(' ');

            // Expect four segments
            if (splitLine.Length != 4)
            {
                Logging.Log.Error(String.Format("Error parsing mobile {0} in area {1}: invalid act/aff/align/group line, expected 4 segments but got {2} - value {3} on line {4}", outMob.VNUM, areaFile, splitLine.Length, lineData, lineNum));
                return null;
            }

            int parsedValue = 0;

            // First segment, action flags - also add IsNPC to all mobs
            outMob.Actions |= AlphaConversions.ConvertROMAlphaToActionFlag(splitLine[0]) | ActionFlag.IsNPC;

            // Second segment, affected by flags
            outMob.AffectedBy = AlphaConversions.ConvertROMAlphaToAffectedByFlag(splitLine[1]);

            // Third segment, alignment
            if (!Int32.TryParse(splitLine[2], out parsedValue))
            {
                Logging.Log.Error(String.Format("Error parsing alignment for mobile {0} in area {1}: non-numeric value {2} encountered on line {3}", outMob.VNUM, areaFile, splitLine[2], lineNum));
                return null;
            }
            else
                outMob.Alignment = Convert.ToInt32(splitLine[2]);

            // Fourth segment, group
            if (!Int32.TryParse(splitLine[3], out parsedValue))
            {
                Logging.Log.Error(String.Format("Error parsing group number for mobile {0} in area {1}: non-numeric value {2} encountered on line {3}", outMob.VNUM, areaFile, splitLine[3], lineNum));
                return null;
            }
            else
                outMob.Alignment = Convert.ToInt32(splitLine[3]);

            // Read the next line and split - expect six segments
            lineData = sr.ReadLine();
            lineNum++;
            splitLine = lineData.Split(' ');

            if (splitLine.Length != 6)
            {
                Logging.Log.Error(String.Format("Error parsing mobile {0} in area {1}: invalid level/hit/health/mana/damage/dtype line, expected 6 segments but got {2} - value {3} on line {4}", outMob.VNUM, areaFile, splitLine.Length, lineData, lineNum));
                return null;
            }

            // First segment, level
            if (!Int32.TryParse(splitLine[0], out parsedValue))
            {
                Logging.Log.Error(String.Format("Error parsing level for mobile {0} in area {1}: non-numeric value {2} encountered on line {3}", outMob.VNUM, areaFile, splitLine[0], lineNum));
                return null;
            }
            else
                outMob.Level = Convert.ToInt32(splitLine[0]);

            // Second segment, hitroll
            if (!Int32.TryParse(splitLine[1], out parsedValue))
            {
                Logging.Log.Error(String.Format("Error parsing hitroll for mobile {0} in area {1}: non-numeric value {2} encountered on line {3}", outMob.VNUM, areaFile, splitLine[1], lineNum));
                return null;
            }
            else
                outMob.HitRoll = Convert.ToInt32(splitLine[1]);

            // Third segment, hit dice
            DiceRoll dice;

            if (!DiceRoll.TryParse(splitLine[2], out dice))
            {
                Logging.Log.Error(String.Format("Error parsing hit dice for mobile {0} in area {1}: invalid dice roll string ({2}) encountered on line {3}", outMob.VNUM, areaFile, splitLine[2], lineNum));
                return null;
            }
            else
                outMob.Health = dice;

            // Fourth segment, mana dice
            if (!DiceRoll.TryParse(splitLine[3], out dice))
            {
                Logging.Log.Error(String.Format("Error parsing mana dice for mobile {0} in area {1}: invalid dice roll string ({2}) encountered on line {3}", outMob.VNUM, areaFile, splitLine[3], lineNum));
                return null;
            }
            else
                outMob.Mana = dice;
            
            // Fifth segment, damage dice
            if (!DiceRoll.TryParse(splitLine[4], out dice))
            {
                Logging.Log.Error(String.Format("Error parsing damage dice for mobile {0} in area {1}: invalid dice roll string ({2}) encountered on line {3}", outMob.VNUM, areaFile, splitLine[4], lineNum));
                return null;
            }
            else
                outMob.Damage = dice;
            
            // Sixth segment, damage type - check that we have a matching damage type with the given abbreviation
            DamageType dtype = Consts.DamageTypes.AttackTable.SingleOrDefault(d => d.Abbreviation.Equals(splitLine[5].Trim()));
            if (dtype == null)
            {
                Logging.Log.Error(String.Format("Error parsing damage type for mobile {0} in area {1}: unknown damage type {2} specified on line {4}", outMob.VNUM, areaFile, splitLine[5], lineNum));
                return null;
            }
            else
                outMob.DamageType = dtype;

            // Read the next line and split again, armor classes - expect four segments
            lineData = sr.ReadLine();
            lineNum++;
            splitLine = lineData.Split(' ');

            if (splitLine.Length != 4)
            {
                Logging.Log.Error(String.Format("Error parsing mobile {0} in area {1}: invalid level/hit/health/mana/damage/dtype line, expected 4 segments but got {2} - value {3} on line {4}", outMob.VNUM, areaFile, splitLine.Length, lineData, lineNum));
                return null;
            }

            // First segment, piercing AC
            if (!Int32.TryParse(splitLine[0], out parsedValue))
            {
                Logging.Log.Error(String.Format("Error parsing piercing AC for mobile {0} in area {1}: non-numeric value {2} encountered on line {3}", outMob.VNUM, areaFile, splitLine[0], lineNum));
                return null;
            }
            else
                outMob.ArmorRating.Pierce = Convert.ToInt32(splitLine[0]);

            // Second segment, bashing AC
            if (!Int32.TryParse(splitLine[1], out parsedValue))
            {
                Logging.Log.Error(String.Format("Error parsing bashing AC for mobile {0} in area {1}: non-numeric value {2} encountered on line {3}", outMob.VNUM, areaFile, splitLine[1], lineNum));
                return null;
            }
            else
                outMob.ArmorRating.Bash = Convert.ToInt32(splitLine[1]);
            
            // Third segment, slashing AC
            if (!Int32.TryParse(splitLine[2], out parsedValue))
            {
                Logging.Log.Error(String.Format("Error parsing slashing AC for mobile {0} in area {1}: non-numeric value {2} encountered on line {3}", outMob.VNUM, areaFile, splitLine[2], lineNum));
                return null;
            }
            else
                outMob.ArmorRating.Slash = Convert.ToInt32(splitLine[2]);
            
            // Fourth segment, exotic AC
            if (!Int32.TryParse(splitLine[3], out parsedValue))
            {
                Logging.Log.Error(String.Format("Error parsing exotic AC for mobile {0} in area {1}: non-numeric value {2} encountered on line {3}", outMob.VNUM, areaFile, splitLine[3], lineNum));
                return null;
            }
            else
                outMob.ArmorRating.Exotic = Convert.ToInt32(splitLine[3]);

            // Read the next line and split again, offense/imm/res/vuln flags - expect four segments
            lineData = sr.ReadLine();
            lineNum++;
            splitLine = lineData.Split(' ');

            if (splitLine.Length != 4)
            {
                Logging.Log.Error(String.Format("Error parsing mobile {0} in area {1}: invalid offense/imm/res/vuln line, expected 4 segments but got {2} - value {3} on line {4}", outMob.VNUM, areaFile, splitLine.Length, lineData, lineNum));
                return null;
            }

            // First segment, offense flags
            outMob.Offense |= AlphaConversions.ConvertROMAlphaToOffensiveFlag(splitLine[0]);

            // Second segment, immunity flags
            outMob.Immunity |= AlphaConversions.ConvertROMAlphaToImmunitylag(splitLine[1]);

            // Third segment, resistance flags
            outMob.Resistance |= AlphaConversions.ConvertROMAlphaToResistanceFlag(splitLine[2]);

            // Fourth segment, vulnerability flags
            outMob.Vulnerability |= AlphaConversions.ConvertROMAlphaToVulnerabilityFlag(splitLine[3]);

            // Read the next line and split again, start pos/default pos/sex/wealth - epect four segments
            lineData = sr.ReadLine();
            lineNum++;
            splitLine = lineData.Split(' ');

            if (splitLine.Length != 4)
            {
                Logging.Log.Error(String.Format("Error parsing mobile {0} in area {1}: invalid start pos/default pos/sex/wealth line, expected 4 segments but got {2} - value {3} on line {4}", outMob.VNUM, areaFile, splitLine.Length, lineData, lineNum));
                return null;
            }

            // First segment, start position
            Position startPos = Consts.Positions.PositionTable.SingleOrDefault(p => p.ShortName.Equals(splitLine[0]));
            if (startPos == null)
            {
                Logging.Log.Error(String.Format("Error parsing mobile {0} in area {1}: invalid start position \"{2}\" found on line {3}", outMob.VNUM, areaFile, splitLine[0], lineNum));
                return null;
            }
            else
                outMob.StartingPosition = startPos;
            
            // Second segment, default position
            Position defPos = Consts.Positions.PositionTable.SingleOrDefault(p => p.ShortName.Equals(splitLine[1]));
            if (startPos == null)
            {
                Logging.Log.Error(String.Format("Error parsing mobile {0} in area {1}: invalid default position \"{2}\" found on line {3}", outMob.VNUM, areaFile, splitLine[1], lineNum));
                return null;
            }
            else
                outMob.DefaultPosition = defPos;

            // Third segment, gender
            Gender mobGender = Consts.Gender.GenderTable.SingleOrDefault(g => g.Name.Equals(splitLine[2]));
            if (mobGender == null)
            {
                Logging.Log.Error(String.Format("Error parsing mobile {0} in area {1}: invalid gender \"{2}\" found on line {3}", outMob.VNUM, areaFile, splitLine[2], lineNum));
                return null;
            }
            else
                outMob.Gender = mobGender;

            // Fourth segment, wealth
            int wealth = 0;
            if (!Int32.TryParse(splitLine[3], out wealth))
            {
                Logging.Log.Error(String.Format("Error parsing mobile {0} in area {1}: invalid wealth \"{2}\" found on line {3}, expected an integer", outMob.VNUM, areaFile, splitLine[3], lineNum));
                return null;
            }
            else
                outMob.Wealth = wealth;

            // Read the next line and split again, form/parts/size/material - epect four segments
            lineData = sr.ReadLine();
            lineNum++;
            splitLine = lineData.Split(' ');

            if (splitLine.Length != 4)
            {
                Logging.Log.Error(String.Format("Error parsing mobile {0} in area {1}: invalid start pos/default pos/sex/wealth line, expected 4 segments but got {2} - value {3} on line {4}", outMob.VNUM, areaFile, splitLine.Length, lineData, lineNum));
                return null;
            }

            // First segment, form
            outMob.Form |= AlphaConversions.ConvertROMAlphaToFormFlag(splitLine[0]);

            // Second segment, parts
            outMob.Parts |= AlphaConversions.ConvertROMAlphaToPartFlag(splitLine[1]);

            // Third segment, size
            Models.Size mobSize = Consts.Size.SizeTable.SingleOrDefault(s => s.Name.Equals(splitLine[2]));
            if (mobSize == null)
            {
                Logging.Log.Error(String.Format("Error parsing mobile {0} in area {1}: invalid size \"{2}\" found on line {3}", outMob.VNUM, areaFile, splitLine[2], lineNum));
                return null;
            }
            else
                outMob.Size = mobSize;

            // Fourth segment, material
            outMob.Material = splitLine[3];

            // Peek ahead to the next line, see if it starts with F, which tells us to un-set some flags
            while ((char)sr.Peek() == 'F')
            {
                // Read the line
                lineData = sr.ReadLine();
                lineNum++;

                // Split the line, expect 3 segments
                splitLine = lineData.Split(' ');

                if (splitLine.Length != 3)
                {
                    Logging.Log.Error(String.Format("Error parsing mobile {0} in area {1}: invalid flag modification line, expected 3 segments but got {2} - value {3} on line {4}", outMob.VNUM, areaFile, splitLine.Length, lineData, lineNum));
                    return null;
                }

                // First segment is line identifier, ignore it. Second segment is which flag to modify, third segment is flag(s) to remove.
                switch(splitLine[1])
                {
                    case "act": // Actions
                        Logging.Log.Debug(String.Format("Removing action flags {0} from mob {1} in area {2} on line {3}", splitLine[2], outMob.VNUM, areaFile, lineNum));

                        // Remove flags
                        outMob.Actions &= ~AlphaConversions.ConvertROMAlphaToActionFlag(splitLine[2]);

                        break;
                    case "aff": // AffectedBy
                        Logging.Log.Debug(String.Format("Removing affected by flags {0} from mob {1} in area {2} on line {3}", splitLine[2], outMob.VNUM, areaFile, lineNum));

                        // Remove flags
                        outMob.AffectedBy &= ~AlphaConversions.ConvertROMAlphaToAffectedByFlag(splitLine[2]);

                        break;
                    case "off": // Offense
                        Logging.Log.Debug(String.Format("Removing offense flags {0} from mob {1} in area {2} on line {3}", splitLine[2], outMob.VNUM, areaFile, lineNum));

                        // Remove flags
                        outMob.Offense &= ~AlphaConversions.ConvertROMAlphaToOffensiveFlag(splitLine[2]);

                        break;
                    case "imm": // Immunities
                        Logging.Log.Debug(String.Format("Removing immunity flags {0} from mob {1} in area {2} on line {3}", splitLine[2], outMob.VNUM, areaFile, lineNum));

                        // Remove flags
                        outMob.Immunity &= ~AlphaConversions.ConvertROMAlphaToImmunitylag(splitLine[2]);

                        break;
                    case "res": // Resistances
                        Logging.Log.Debug(String.Format("Removing restistance flags {0} from mob {1} in area {2} on line {3}", splitLine[2], outMob.VNUM, areaFile, lineNum));

                        // Remove flags
                        outMob.Resistance &= ~AlphaConversions.ConvertROMAlphaToResistanceFlag(splitLine[2]);

                        break;
                    case "vul": // Vulnerabilities
                        Logging.Log.Debug(String.Format("Removing vulnerability flags {0} from mob {1} in area {2} on line {3}", splitLine[2], outMob.VNUM, areaFile, lineNum));

                        // Remove flags
                        outMob.Vulnerability &= ~AlphaConversions.ConvertROMAlphaToVulnerabilityFlag(splitLine[2]);

                        break;
                    case "for": // Form
                        Logging.Log.Debug(String.Format("Removing form flags {0} from mob {1} in area {2} on line {3}", splitLine[2], outMob.VNUM, areaFile, lineNum));

                        // Remove flags
                        outMob.Form &= ~AlphaConversions.ConvertROMAlphaToFormFlag(splitLine[2]);

                        break;
                    case "par": // Parts
                        Logging.Log.Debug(String.Format("Removing parts flags {0} from mob {1} in area {2} on line {3}", splitLine[2], outMob.VNUM, areaFile, lineNum));

                        // Remove flags
                        outMob.Parts &= ~AlphaConversions.ConvertROMAlphaToPartFlag(splitLine[2]);

                        break;
                    default:
                        Logging.Log.Warn(String.Format("Encountered unexpected mob flag modifier type {0} for mob {1} in file {2} on line {3}", splitLine[1], outMob.VNUM, areaFile, lineNum));
                        break;
                }
            }

            Logging.Log.Debug(String.Format("Mobile {0} in area {1} loaded", outMob.VNUM, areaFile));

            return outMob;
        }
        #endregion
    }

    /// <summary>
    /// Defines a race and the attributes which make it up
    /// </summary>
    public class Race
    {
        /// <summary>
        /// Name of the race
        /// </summary>
        public string Name { get; set;  }

        /// <summary>
        /// Indicates whether the race can be chosen for play by PCs
        /// </summary>
        /// <value><c>true</c> if player characters can use this race, <c>false</c> otherwise</value>
        public bool IsPCRace { get; set; }

        public ActionFlag Actions { get; set; }
        public AffectedByFlag Affects { get; set; }
        public OffensiveFlag Offenses { get; set; }
        public ImmunityFlag Immunities { get; set; }
        public ResistanceFlag Resistances { get; set; }
        public VulnerabilityFlag Vulnerabilities { get; set; }
        public FormFlag Form { get; set; }
        public PartFlag Parts { get; set; }

        public Race() {
            Actions = ActionFlag.None;
            Affects = AffectedByFlag.None;
            Offenses = OffensiveFlag.None;
            Immunities = ImmunityFlag.None;
            Resistances = ResistanceFlag.None;
            Vulnerabilities = VulnerabilityFlag.None;
            Form = FormFlag.None;
            Parts = PartFlag.None;
        }
    }

    /// <summary>
    /// Special behaviors inherited by some mobiles
    /// </summary>
    public class SpecialBehavior
    {
        /// <summary>
        /// Name of the special behavior
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Method to invoke when the special behavior is triggered
        /// </summary>
        public Func<CharacterData, bool> Method { get; set; }

        public SpecialBehavior() { }
        public SpecialBehavior(string name, Func<CharacterData, bool> method)
        {
            Name = name;
            Method = method;
        }
    }
}
