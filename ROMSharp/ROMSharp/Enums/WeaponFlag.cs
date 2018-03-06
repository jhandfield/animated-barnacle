using System;
namespace ROMSharp.Enums
{
    [Flags]
    public enum WeaponFlag
    {
        None = 0,
        /// <summary>
        /// Legacy WEAPON_FLAMING (A)
        /// </summary>
        Flaming = 1 << 0,

        /// <summary>
        /// Legacy WEAPON_FROST (B)
        /// </summary>
        Frost = 1 << 1,

        /// <summary>
        /// Legacy WEAPON_VAMPIRIC (C)
        /// </summary>
        Vampiric = 1 << 2,

        /// <summary>
        /// Legacy WEAPON_SHARP (D)
        /// </summary>
        Sharp = 1 << 3,

        /// <summary>
        /// Legacy WEAPON_VORPAL (E)
        /// </summary>
        Vorpal = 1 << 4,

        /// <summary>
        /// Legacy WEAPON_TWO_HANDS (F)
        /// </summary>
        TwoHands = 1 << 5,

        /// <summary>
        /// Legacy WEAPON_SHOCKING (G)
        /// </summary>
        Shocking = 1 << 6,

        /// <summary>
        /// Legacy WEAPON_POISON (H)
        /// </summary>
        Poison = 1 << 7
    }
}
