using System;
namespace ROMSharp.Enums
{
    /// <summary>
    /// WizNet channel flags
    /// </summary>
    [Flags]
    public enum WizNetFlag
    {
        None = 0,

        /// <summary>
        /// Legacy WIZ_ON (A)
        /// </summary>
        On = AlphaMacros.A,

        /// <summary>
        /// Legacy WIZ_TICKS (B)
        /// </summary>
        Ticks = AlphaMacros.B,

        /// <summary>
        /// Legacy WIZ_LOGINS (C)
        /// </summary>
        Logins = AlphaMacros.C,

        /// <summary>
        /// Legacy WIZ_SITES (D)
        /// </summary>
        Sites = AlphaMacros.D,

        /// <summary>
        /// Legacy WIZ_LINKS (E)
        /// </summary>
        Links = AlphaMacros.E,

        /// <summary>
        /// Legacy WIZ_DEATHS (F)
        /// </summary>
        Deaths = AlphaMacros.F,

        /// <summary>
        /// Legacy WIZ_RESETS (G)
        /// </summary>
        Resets = AlphaMacros.G,

        /// <summary>
        /// Legacy WIZ_MOBDEATHS (H)
        /// </summary>
        MobDeaths = AlphaMacros.H,

        /// <summary>
        /// Legacy WIZ_FLAGS (I)
        /// </summary>
        Flags = AlphaMacros.I,

        /// <summary>
        /// Legacy WIZ_PENALTIES (J)
        /// </summary>
        Penalties = AlphaMacros.J,

        /// <summary>
        /// Legacy WIZ_SACCING (K)
        /// </summary>
        Saccing = AlphaMacros.K,

        /// <summary>
        /// Legacy WIZ_LEVELS (L)
        /// </summary>
        Levels = AlphaMacros.L,

        /// <summary>
        /// Legacy WIZ_SECURE (M)
        /// </summary>
        Secure = AlphaMacros.M,

        /// <summary>
        /// Legacy WIZ_SWITCHES (N)
        /// </summary>
        Switches = AlphaMacros.N,

        /// <summary>
        /// Legacy WIZ_SNOOPS (O)
        /// </summary>
        Snoops = AlphaMacros.O,

        /// <summary>
        /// Legacy WIZ_RESTORE (P)
        /// </summary>
        Restore = AlphaMacros.P,

        /// <summary>
        /// Legacy WIZ_LOAD (O)
        /// </summary>
        Load = AlphaMacros.Q,

        /// <summary>
        /// Legacy WIZ_NEWBIE (R)
        /// </summary>
        Newbie = AlphaMacros.R,

        /// <summary>
        /// Legacy WIZ_PREFIX (S)
        /// </summary>
        Prefix = AlphaMacros.S,

        /// <summary>
        /// Legacy WIZ_SPAM (T)
        /// </summary>
        Spam = AlphaMacros.T
    }
}
