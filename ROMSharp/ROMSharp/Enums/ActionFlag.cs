using System;
namespace ROMSharp.Enums
{
    /// <summary>
    /// Defines action flags for mobiles
    /// </summary>
    [Flags]
    public enum ActionFlag
    {
        None = 0,
        IsNPC = 1 << 0,         // ACT_IS_NPC
        Sentinel = 1 << 1,      // ACT_SENTINEL
        Scavenger = 1 << 2,     // ACT_SCAVENGER
        Aggressive = 1 << 5,    // ACT_AGGRESSIVE
        StayInArea = 1 << 6,    // ACT_STAY_AREA
        Wimpy = 1 << 7,         // ACT_WIMPY
        Pet = 1 << 8,           // ACT_PET
        Train = 1 << 9,         // ACT_TRAIN
        Practice = 1 << 10,     // ACT_PRACTICE
        Undead = 1 << 14,       // ACT_UNDEAD
        Cleric = 1 << 16,       // ACT_CLERIC
        Mage = 1 << 17,         // ACT_MAGE
        Thief = 1 << 18,        // ACT_THIEF
        Warrior = 1 << 19,      // ACT_WARRIOR
        NoAlign = 1 << 20,      // ACT_NOALIGN
        NoPurge = 1 << 21,      // ACT_NOPURGE
        Outdoors = 1 << 22,     // ACT_OUTDOORS
        Indoors = 1 << 24,      // ACT_INDOORS
        IsHealer = 1 << 26,     // ACT_IS_HEALER
        Gain = 1 << 27,         // ACT_GAIN
        UpdateAlways = 1 << 28, // ACT_UPDATE_ALWAYS
        IsChanger = 1 << 29     // ACT_IS_CHANGER
    }
}
