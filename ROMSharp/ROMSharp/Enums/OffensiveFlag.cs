using System;
namespace ROMSharp.Enums
{
    /// <summary>
    /// Defines offensive abilities of a mobile, as well as assisting behaviors
    /// </summary>
    [Flags]
    public enum OffensiveFlag
    {
        None = 0,
        Offense_AreaAttack = 1 << 0,    // OFF_AREA_ATTACK
        Offense_Backstab = 1 << 1,      // OFF_BACKSTAB
        Offense_Bash = 1 << 2,          // OFF_BASH
        Offense_Berserk = 1 << 3,       // OFF_BERSERK
        Offense_Disarm = 1 << 4,        // OFF_DISARM
        Offense_Dodge = 1 << 5,         // OFF_DODGE
        Offense_Fade = 1 << 6,          // OFF_FADE
        Offense_Fast = 1 << 7,          // OFF_FAST
        Offense_Kick = 1 << 8,          // OFF_KICK
        Offense_KickDirt = 1 << 9,      // OFF_KICK_DIRT
        Offense_Parry = 1 << 10,        // OFF_PARRY
        Offense_Rescue = 1 << 11,       // OFF_RESCUE
        Offense_Tail = 1 << 12,         // OFF_TAIL
        Offense_Trip = 1 << 13,         // OFF_TRIP
        Offense_Crush = 1 << 14,        // OFF_CRUSH
        Assist_All = 1 << 15,           // ASSIST_ALL
        Assist_Align = 1 << 16,         // ASSIST_ALIGN
        Assist_Race = 1 << 17,          // ASSIST_RACE
        Assist_Players = 1 << 18,       // ASSIST_PLAYERS
        Assist_Guard = 1 << 19,         // ASSIST_GUARD
        Assist_VNUM = 1 << 20           // ASSIST_VNUM
    }
}
