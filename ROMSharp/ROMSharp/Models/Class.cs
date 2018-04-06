using System;
using System.Collections.Generic;

namespace ROMSharp.Models
{
    public class Class
    {
        private string _abbreviation;

        /// <summary>
        /// Name of the class
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Three-letter abbreviation for the class (used in 'who')
        /// </summary>
        public string Abbreviation
        {
            get
            {
                return _abbreviation;
            }

            set
            {
                if (value.Trim().Length != 3)
                    throw new ArgumentException("Class abbreviations must be 3 characters in length");
                else
                    _abbreviation = value;
            }
        }

        /// <summary>
        /// The prime attribute of the class
        /// </summary>
        public Enums.Attribute PrimeAttribute { get; set; }

        /// <summary>
        /// The starting weapon of the class
        /// </summary>
        public ObjectIndexData StarterWeapon { get { return Program.World.Objects[StarterWeaponVNUM]; } }
    
        /// <summary>
        /// VNUM of the starting weapon of the class
        /// </summary>
        public int StarterWeaponVNUM { get; set; }

        /// <summary>
        /// VNUMs of guild rooms for this class (where they go to practice skills)
        /// </summary>
        public List<int> GuildRoomVNUMs { get; set; }

        /// <summary>
        /// Maximum skill level for the class
        /// </summary>
        public int AdeptSkillLevel { get; set; }

        /// <summary>
        /// THAC0 (To Hit Armor Class 0) for level 0
        /// </summary>
        public int THAC0_0 { get; set; }

        /// <summary>
        /// THAC0 (To Hit Armor Class 0) for level 32
        /// </summary>
        /// <value>The THAC 0 32.</value>
        public int THAC0_32 { get; set; }

        /// <summary>
        /// Minimum HP to gain per level
        /// </summary>
        public int MinHPPerLevel { get; set; }

        /// <summary>
        /// Maximum HP to gain per level
        /// </summary>
        public int MaxHPPerLevel { get; set; }

        /// <summary>
        /// Indicates whether this class gains mana on level up
        /// </summary>
        /// <value><c>true</c> if the class gains mana on level up; otherwise, <c>false</c>.</value>
        public bool GainsManaOnLevelUp { get; set; }

        /// <summary>
        /// Basic skill group for the class
        /// </summary>
        public string BaseSkillGroup { get; set; }

        /// <summary>
        /// Default skill group for the class
        /// </summary>
        public string DefaultSkillGroup { get; set; }

        public Class()
        {
        }
    }
}
