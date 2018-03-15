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
        /// <summary>
        /// Legacy OFF_AREA_ATTACK (A)
        /// </summary>
        Offense_AreaAttack = AlphaMacros.A,

        /// <summary>
        /// Legacy OFF_BACKSTAB (B)
        /// </summary>
        Offense_Backstab = AlphaMacros.B,

        /// <summary>
        /// Legacy OFF_BASH (C)
        /// </summary>
        Offense_Bash = AlphaMacros.C,

        /// <summary>
        /// Legacy OFF_BERSERK (D)
        /// </summary>
        Offense_Berserk = AlphaMacros.D,

        /// <summary>
        /// Legacy OFF_DISARM (E)
        /// </summary>
        Offense_Disarm = AlphaMacros.E,

        /// <summary>
        /// Legacy OFF_DODGE (F)
        /// </summary>
        Offense_Dodge = AlphaMacros.F,

        /// <summary>
        /// Legacy OFF_FADE (G)
        /// </summary>
        Offense_Fade = AlphaMacros.G,

        /// <summary>
        /// Legacy OFF_FAST (H)
        /// </summary>
        Offense_Fast = AlphaMacros.H,

        /// <summary>
        /// Legacy OFF_KICK (I)
        /// </summary>
        Offense_Kick = AlphaMacros.I,

        /// <summary>
        /// Legacy OFF_KICK_DIRT (J)
        /// </summary>
        Offense_KickDirt = AlphaMacros.J,

        /// <summary>
        /// Legacy OFF_PARRY (K)
        /// </summary>
        Offense_Parry = AlphaMacros.K,

        /// <summary>
        /// Legacy OFF_RESCUE (L)
        /// </summary>
        Offense_Rescue = AlphaMacros.L,

        /// <summary>
        /// Legacy OFF_TAIL (M)
        /// </summary>
        Offense_Tail = AlphaMacros.M,

        /// <summary>
        /// Legacy OFF_TRIP (N)
        /// </summary>
        Offense_Trip = AlphaMacros.N,

        /// <summary>
        /// Legacy OFF_CRUSH (O)
        /// </summary>
        Offense_Crush = AlphaMacros.O,

        /// <summary>
        /// Legacy ASSIST_ALL (P)
        /// </summary>
        Assist_All = AlphaMacros.P,

        /// <summary>
        /// Legacy ASSIST_ALIGN (Q)
        /// </summary>
        Assist_Align = AlphaMacros.Q,

        /// <summary>
        /// Legacy ASSIST_RACE (R)
        /// </summary>
        Assist_Race = AlphaMacros.R,

        /// <summary>
        /// Legacy ASSIST_PLAYERS (S)
        /// </summary>
        Assist_Players = AlphaMacros.S,

        /// <summary>
        /// Legacy ASSIST_GUARD (T)
        /// </summary>
        Assist_Guard = AlphaMacros.T,

        /// <summary>
        /// Legacy ASSIST_VNUM (U)
        /// </summary>
        Assist_VNUM = AlphaMacros.U
    }
}
