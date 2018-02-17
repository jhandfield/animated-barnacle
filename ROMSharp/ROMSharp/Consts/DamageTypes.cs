using System.Collections.Generic;
using ROMSharp.Models;
using ROMSharp.Enums;

namespace ROMSharp.Consts
{
    public class DamageTypes
    {
        /// <summary>
        /// A list mapping various damage descriptors to actual damage classes
        /// </summary>
        public static List<DamageType> AttackTable = new List<DamageType>() {
            new DamageType("none", "hit", 0),
            new DamageType("slice", "slice", DamageClass.Slash),
            new DamageType("stab", "stab", DamageClass.Pierce),
            new DamageType("slash", "slash", DamageClass.Slash),
            new DamageType("whip", "whip", DamageClass.Slash),
            new DamageType("claw", "claw", DamageClass.Slash),                  // 5
            new DamageType("blast", "blast", DamageClass.Bash),
            new DamageType("pound", "pound", DamageClass.Bash),
            new DamageType("crush", "crush", DamageClass.Bash),
            new DamageType("grep", "grep", DamageClass.Slash),
            new DamageType("bite", "bite", DamageClass.Pierce),                 // 10
            new DamageType("pierce", "piece", DamageClass.Pierce),
            new DamageType("suction", "suction", DamageClass.Bash),
            new DamageType("beating", "beating", DamageClass.Bash),
            new DamageType("digestion", "digestion", DamageClass.Acid),
            new DamageType("charge", "charge", DamageClass.Bash),               // 15
            new DamageType("slap", "slap", DamageClass.Bash),
            new DamageType("punch", "punch", DamageClass.Bash),
            new DamageType("wrath", "wrath", DamageClass.Energy),
            new DamageType("magic", "magic", DamageClass.Energy),
            new DamageType("divine", "divine", DamageClass.Holy),               // 20
            new DamageType("cleave", "cleave", DamageClass.Slash),
            new DamageType("scratch", "scratch", DamageClass.Pierce),
            new DamageType("peck", "peck", DamageClass.Pierce),
            new DamageType("peckb", "peck", DamageClass.Bash),
            new DamageType("chop", "chop", DamageClass.Slash),                  // 25
            new DamageType("sting", "sting", DamageClass.Pierce),
            new DamageType("smash", "smash", DamageClass.Bash),
            new DamageType("shbite", "shocking bite", DamageClass.Lightning),
            new DamageType("flbite", "flaming bite", DamageClass.Fire),
            new DamageType("frbite", "freezing bite", DamageClass.Cold),        // 30
            new DamageType("acbite", "acidic bite", DamageClass.Acid),
            new DamageType("chomp", "chomp", DamageClass.Pierce),
            new DamageType("drain", "life drain", DamageClass.Negative),
            new DamageType("thrust", "thrust", DamageClass.Pierce),
            new DamageType("slime", "slime", DamageClass.Acid),                 // 35
            new DamageType("shock", "shock", DamageClass.Lightning),
            new DamageType("thwack", "thwack", DamageClass.Bash),
            new DamageType("flame", "flame", DamageClass.Fire),
            new DamageType("chill", "chill", DamageClass.Cold)                  // 39
        };
    }
}
