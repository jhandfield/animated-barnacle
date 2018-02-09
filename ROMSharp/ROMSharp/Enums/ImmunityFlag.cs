﻿using System;
namespace ROMSharp.Enums
{
    /// <summary>
    /// Damage types a mobile is immune to
    /// </summary>
    [Flags]
    public enum ImmunityFlag
    {
        None = 0,
        Summon = 1 << 0,
        Charm = 1 << 1,
        Magic = 1 << 2,
        Weapon = 1 << 3,
        Bash = 1 << 4,
        Pierce = 1 << 5,
        Slash = 1 << 6,
        Fire = 1 << 7,
        Cold = 1 << 8,
        Lightning = 1 << 9,
        Acid = 1 << 10,
        Poison = 1 << 11,
        Negative = 1 << 12,
        Holy = 1 << 13,
        Energy = 1 << 14,
        Mental = 1 << 15,
        Disease = 1 << 16,
        Drowning = 1 << 17,
        Light = 1 << 18,
        Sound = 1 << 19,
        Wood = 1 << 23,
        Silver = 1 << 24,
        Iron = 1 << 25
    }
}
