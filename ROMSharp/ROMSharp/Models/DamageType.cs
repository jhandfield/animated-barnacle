using System;
namespace ROMSharp.Models
{
    public class DamageType
    {
        /// <summary>
        /// Internal name for the damage type, for use in mob definitions (e.g. "shbite")
        /// </summary>
        public string Abbreviation { get; set; }

        /// <summary>
        /// Long name for the damage type, for display to players (e.g. "shcoking bite")
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Damage class for the damage type
        /// </summary>
        public Enums.DamageClass DamageClass { get; set; }

        public DamageType() { }
        /// <summary>
        /// Instantiate a new <see cref="T:ROMSharp.Models.DamageType"/> object with the provided values
        /// </summary>
        /// <param name="abbrev">Internal name for the damage type</param>
        /// <param name="name">Long name for the damage type</param>
        /// <param name="damClass">Damage class of the damage type</param>
        public DamageType(string abbrev, string name, Enums.DamageClass damClass) {
            Abbreviation = abbrev;
            Name = name;
            DamageClass = damClass;
        }
    }
}
