using System;
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


        #endregion

        #region Constructors
        public MobileData() { }
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
