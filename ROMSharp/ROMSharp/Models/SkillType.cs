using System;
using System.Collections.Generic;

namespace ROMSharp.Models
{
    public class SkillType
    {
        /// <summary>
        /// Name of the skill
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Dictionary of the required level 
        /// </summary>
        public Dictionary<Class, int> RequiredLevels { get; set; }

        /// <summary>
        /// Difficulty level for learning the skill by a given class
        /// </summary>
        public Dictionary<Class, int> Difficulty { get; set; }

        /// <summary>
        /// Method to execute when spell is cast - ONLY FOR SPELLS
        /// </summary>
        public Action SpellFunction { get; set; }

        /// <summary>
        /// Defines legal targets of the skill
        /// </summary>
        public Enums.TargetTypes TargetType { get; set; }

        /// <summary>
        /// Minimum position the skill user must be in to activate the skill
        /// </summary>
        public Enums.Position MinimumPosition { get; set; }

        /// <summary>
        /// "Slot for #OBJECT loading" as per the original ROM 2.4
        /// documentation. Looks like it's only used in old-style #OBJECTS
        /// loading, new format does a skill lookup by name. We'll preserve
        /// these numbers for compatibility with old areas anyway. 
        /// </summary>
        public int Slot { get; set; }

        /// <summary>
        /// Minimum mana cost of the spell
        /// </summary>
        public int MinimumManaCost { get; set; }

        /// <summary>
        /// Wait time after use
        /// </summary>
        /// <remarks>Called "Beats" in the original source</remarks>
        public int WaitTime { get; set; }

        /// <summary>
        /// Damage message for the skill
        /// </summary>
        public string DamageMessage { get; set; }

        /// <summary>
        /// Message when the skill wears off
        /// </summary>
        public string WearOffMessage { get; set; }

        /// <summary>
        /// Message when the skill wears off objects
        /// </summary>
        public string WearOffMessage_Object { get; set; }

        public SkillType() { }
    }
}
