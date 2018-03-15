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
        /// <summary>
        /// Legacy ACT_IS_NPC (A)
        /// </summary>
        IsNPC = AlphaMacros.A,

        /// <summary>
        /// Legacy ACT_SENTINEL (B)
        /// </summary>
        Sentinel = AlphaMacros.B,

        /// <summary>
        /// Legacy ACT_SCAVENGER (C)
        /// </summary>
        Scavenger = AlphaMacros.C,

        /// <summary>
        /// Legacy ACT_AGGRESSIVE (F)
        /// </summary>
        Aggressive = AlphaMacros.F,

        /// <summary>
        /// Legacy ACT_STAY_IN_AREA (G)
        /// </summary>
        StayInArea = AlphaMacros.G,

        /// <summary>
        /// Legacy ACT_WIMPY (H)
        /// </summary>
        Wimpy = AlphaMacros.H,

        /// <summary>
        /// Legacy ACT_PET (I)
        /// </summary>
        Pet = AlphaMacros.I,

        /// <summary>
        /// Legacy ACT_TRAIN (J)
        /// </summary>
        Train = AlphaMacros.J,

        /// <summary>
        /// Legacy ACT_PRACTICE (K)
        /// </summary>
        Practice = AlphaMacros.K,

        /// <summary>
        /// Legacy ACT_UNDEAD (O)
        /// </summary>
        Undead = AlphaMacros.O,

        /// <summary>
        /// Legacy ACT_CLERIC (Q)
        /// </summary>
        Cleric = AlphaMacros.Q,

        /// <summary>
        /// Legacy ACT_MAGE (R)
        /// </summary>
        Mage = AlphaMacros.R,

        /// <summary>
        /// Legacy ACT_THIEF (S)
        /// </summary>
        Thief = AlphaMacros.S,

        /// <summary>
        /// Legacy ACT_WARRIOR (T)
        /// </summary>
        Warrior = AlphaMacros.T,

        /// <summary>
        /// Legacy ACT_NOALIGN (U)
        /// </summary>
        NoAlign = AlphaMacros.U,

        /// <summary>
        /// Legacy ACT_NOPURGE (V)
        /// </summary>
        NoPurge = AlphaMacros.V,

        /// <summary>
        /// Legacy ACT_OUTDOORS (W)
        /// </summary>
        Outdoors = AlphaMacros.W,

        /// <summary>
        /// Legacy ACT_INDOORS (Y)
        /// </summary>
        Indoors = AlphaMacros.Y,

        /// <summary>
        /// Legacy ACT_IS_HEALER (aa)
        /// </summary>
        IsHealer = AlphaMacros.aa,

        /// <summary>
        /// Legacy ACT_GAIN (bb)
        /// </summary>
        Gain = AlphaMacros.bb,

        /// <summary>
        /// Legacy ACT_UPDATE_ALWAYS (cc)
        /// </summary>
        UpdateAlways = AlphaMacros.cc,

        /// <summary>
        /// Legacy ACT_IS_CHANGER (dd)
        /// </summary>
        IsChanger = AlphaMacros.dd
    }
}