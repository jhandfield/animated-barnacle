using System;
namespace ROMSharp.Enums
{
    /// <summary>
    /// Damage types a mobile is resistant to
    /// </summary>
    [Flags]
    public enum ResistanceFlag
    {
        None = 0,

        /// <summary>
        /// Legacy RES_SUMMON (A)
        /// </summary>
        Summon = AlphaMacros.A,

        /// <summary>
        /// Legacy RES_CHARM (B)
        /// </summary>
        Charm = AlphaMacros.B,

        /// <summary>
        /// Legacy RES_MAGIC (C)
        /// </summary>
        Magic = AlphaMacros.C,

        /// <summary>
        /// Legacy RES_WEAPON (D)
        /// </summary>
        Weapon = AlphaMacros.D,

        /// <summary>
        /// Legacy RES_BASH (E)
        /// </summary>
        Bash = AlphaMacros.E,

        /// <summary>
        /// Legacy RES_PIERCE (F)
        /// </summary>
        Pierce = AlphaMacros.F,

        /// <summary>
        /// Legacy RES_SLASH (G)
        /// </summary>
        Slash = AlphaMacros.G,

        /// <summary>
        /// Legacy RES_FIRE (H)
        /// </summary>
        Fire = AlphaMacros.H,

        /// <summary>
        /// Legacy RES_COLD (I)
        /// </summary>
        Cold = AlphaMacros.I,

        /// <summary>
        /// Legacy RES_LIGHTNING (J)
        /// </summary>
        Lightning = AlphaMacros.J,

        /// <summary>
        /// Legacy RES_ACID (K)
        /// </summary>
        Acid = AlphaMacros.K,

        /// <summary>
        /// Legacy RES_POISON (L)
        /// </summary>
        Poison = AlphaMacros.L,

        /// <summary>
        /// Legacy RES_NEGATIVE (M)
        /// </summary>
        Negative = AlphaMacros.M,

        /// <summary>
        /// Legacy RES_HOLY (N)
        /// </summary>
        Holy = AlphaMacros.N,

        /// <summary>
        /// Legacy RES_ENERGY (O)
        /// </summary>
        Energy = AlphaMacros.O,

        /// <summary>
        /// Legacy RES_MENTAL (P)
        /// </summary>
        Mental = AlphaMacros.P,

        /// <summary>
        /// Legacy RES_DISEASE (Q)
        /// </summary>
        Disease = AlphaMacros.Q,

        /// <summary>
        /// Legacy RES_DROWNING (R)
        /// </summary>
        Drowning = AlphaMacros.R,

        /// <summary>
        /// Legacy RES_LIGHT (S)
        /// </summary>
        Light = AlphaMacros.S,

        /// <summary>
        /// Legacy RES_SOUND (T)
        /// </summary>
        Sound = AlphaMacros.T,

        /// <summary>
        /// Legacy RES_WOOD (X)
        /// </summary>
        Wood = AlphaMacros.X,

        /// <summary>
        /// Legacy RES_SILVER (Y)
        /// </summary>
        Silver = AlphaMacros.Y,

        /// <summary>
        /// Legacy RES_IRON (Z)
        /// </summary>
        Iron = AlphaMacros.Z
    }
}
