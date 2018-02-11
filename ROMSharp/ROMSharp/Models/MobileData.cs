using System;
using System.Text.RegularExpressions;
using ROMSharp.Enums;

namespace ROMSharp.Models
{
    public class MobileData
    {
        #region Properties
        public int VNUM { get; set; }
        public int Group { get; set; }
        public int Count { get; set; }
        public int Killed { get; set;  }
        public string Name { get; set;  }
        public string ShortDescription { get; set;  }
        public string LongDescription { get; set; }
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

        public Position StartingPosition { get; set; }

        public Position DefaultPosition { get; set; }

        public Sex Gender { get; set; }

        //public Race { get; set; }

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
        public MobileData()
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

        public Race() { }
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
