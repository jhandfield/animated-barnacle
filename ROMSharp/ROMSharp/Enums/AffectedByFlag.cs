using System;
namespace ROMSharp.Enums
{
    /// <summary>
    /// Flags to indicate conditions the mobile is affected by
    /// </summary>
    [Flags]
    public enum AffectedByFlag
    {
        None = 0,
        Blind = 1 << 0,         // AFF_BLIND
        Invisible = 1 << 1,     // AFF_INVISIBLE
        DetectEvil = 1 << 2,    // AFF_DETECT_EVIL
        DetectInvis = 1 << 3,   // AFF_DETECT_INVIS
        DetectMagic = 1 << 4,   // AFF_DETECT_MAGIC
        DetectHidden = 1 << 5,  // AFF_DETECT_HIDDEN
        DetectGood = 1 << 6,    // AFF_DETECT_GOOD
        Sanctuary = 1 << 7,     // AFF_SANCTUARY
        FaerieFire = 1 << 8,    // AFF_FAERIE_FIRE
        Infrared = 1 << 9,      // AFF_INFRARED
        Curse = 1 << 10,        // AFF_CURSE
        UndeadFlag = 1 << 11,   // AFF_UNDEAD_FLAG, commented "Unused" in ROM
        Poison = 1 << 12,       // AFF_POISON
        ProectEvil = 1 << 13,   // AFF_PROTECT_EVIL
        ProtectGood = 1 << 14,  // AFF_PROTECT_GOOD
        Sneak = 1 << 15,        // AFF_SNEAK
        Hide = 1 << 16,         // AFF_HIDE
        Sleep = 1 << 17,        // AFF_SLEEP
        Charm = 1 << 18,        // AFF_CHARM
        Flying = 1 << 19,       // AFF_FLYING
        PassDoor = 1 << 20,     // AFF_PASS_DOOR
        Haste = 1 << 21,        // AFF_HASTE
        Calm = 1 << 22,         // AFF_CALM
        Plague = 1 << 23,       // AFF_PLAGUE
        Weaken = 1 << 24,       // AFF_WEAKEN
        DarkVision = 1 << 25,   // AFF_DARK_VISION
        Berserk = 1 << 26,      // AFF_BERSERK
        Swim = 1 << 27,         // AFF_SWIM
        Regeneration = 1 << 28, // AFF_REGENERATION
        Slow = 1 << 29          // AFF_SOW
    }
}
