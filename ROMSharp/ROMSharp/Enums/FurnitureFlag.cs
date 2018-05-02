using System;
namespace ROMSharp.Enums
{
    /// <summary>
    /// Defines the ability to interact with furniture
    /// </summary>
    [Flags]
    public enum FurnitureFlag
    {
        None = 0,

        /// <summary>
        /// Legacy STAND_AT (A)
        /// </summary>
        StandAt = AlphaMacros.A,

        /// <summary>
        /// Legacy STAND_ON (B)
        /// </summary>
        StandOn = AlphaMacros.B,

        /// <summary>
        /// Legacy STAND_IN (C)
        /// </summary>
        StandIn = AlphaMacros.C,

        /// <summary>
        /// Legacy SIT_AT (D)
        /// </summary>
        SitAt = AlphaMacros.D,

        /// <summary>
        /// Legacy SIT_ON (E)
        /// </summary>
        SitOn = AlphaMacros.E,

        /// <summary>
        /// Legacy SIT_IN (F)
        /// </summary>
        SitIn = AlphaMacros.F,

        /// <summary>
        /// Legacy REST_AT (G)
        /// </summary>
        RestAt = AlphaMacros.G,

        /// <summary>
        /// Legacy REST_ON (H)
        /// </summary>
        RestOn = AlphaMacros.H,

        /// <summary>
        /// Legacy REST_IN (I)
        /// </summary>
        RestIn = AlphaMacros.I,

        /// <summary>
        /// Legacy SLEEP_AT (J)
        /// </summary>
        SleepAt = AlphaMacros.J,

        /// <summary>
        /// Legacy SLEEP_ON (K)
        /// </summary>
        SleepOn = AlphaMacros.K,

        /// <summary>
        /// Legacy SLEEP_IN (L)
        /// </summary>
        SleepIn = AlphaMacros.L,

        /// <summary>
        /// Legacy PUT_AT (M)
        /// </summary>
        PutAt = AlphaMacros.M,

        /// <summary>
        /// Legacy PUT_ON (N)
        /// </summary>
        PutOn = AlphaMacros.N,

        /// <summary>
        /// Legacy PUT_IN (O)
        /// </summary>
        PutIn = AlphaMacros.O,

        /// <summary>
        /// Legacy PUT_INSIDE (P)
        /// </summary>
        PutInside = AlphaMacros.P
    }
}
