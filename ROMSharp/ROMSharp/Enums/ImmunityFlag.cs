using System;
namespace ROMSharp.Enums
{
    /// <summary>
    /// Damage types a mobile is immune to
    /// </summary>
    [Flags]
    public enum ImmunityFlag
    {
        None = 0,
        /// <summary>
        /// Legacy IMM_SUMMON (A)
        /// </summary>
        Summon = AlphaMacros.A,

        /// <summary>
        /// Legacy IMM_CHARM (B)
        /// </summary>
        Charm = AlphaMacros.B,

        /// <summary>
        /// Legacy IMM_MAGIC (C)
        /// </summary>
        Magic = AlphaMacros.C,

        /// <summary>
        /// Legacy IMM_WEAPON (D)
        /// </summary>
        Weapon = AlphaMacros.D,

        /// <summary>
        /// Legacy IMM_BASH (E)
        /// </summary>
        Bash = AlphaMacros.E,

        /// <summary>
        /// Legacy IMM_PIERCE (F)
        /// </summary>
        Pierce = AlphaMacros.F,

        /// <summary>
        /// Legacy IMM_SLASH (G)
        /// </summary>
        Slash = AlphaMacros.G,

        /// <summary>
        /// Legacy IMM_FIRE (H)
        /// </summary>
        Fire = AlphaMacros.H,

        /// <summary>
        /// Legacy IMM_COLD (I)
        /// </summary>
        Cold = AlphaMacros.I,

        /// <summary>
        /// Legacy IMM_LIGHTNING (J)
        /// </summary>
        Lightning = AlphaMacros.J,

        /// <summary>
        /// Legacy IMM_ACID (K)
        /// </summary>
        Acid = AlphaMacros.K,

        /// <summary>
        /// Legacy IMM_POISON (L)
        /// </summary>
        Poison = AlphaMacros.L,

        /// <summary>
        /// Legacy IMM_NEGATIVE (M)
        /// </summary>
        Negative = AlphaMacros.M,

        /// <summary>
        /// Legacy IMM_HOLY (N)
        /// </summary>
        Holy = AlphaMacros.N,

        /// <summary>
        /// Legacy IMM_ENERGY (O)
        /// </summary>
        Energy = AlphaMacros.O,

        /// <summary>
        /// Legacy IMM_MENTAL (P)
        /// </summary>
        Mental = AlphaMacros.P,

        /// <summary>
        /// Legacy IMM_DISEASE (Q)
        /// </summary>
        Disease = AlphaMacros.Q,

        /// <summary>
        /// Legacy IMM_DROWNING (R)
        /// </summary>
        Drowning = AlphaMacros.R,

        /// <summary>
        /// Legacy IMM_LIGHT (S)
        /// </summary>
        Light = AlphaMacros.S,

        /// <summary>
        /// Legacy IMM_SOUND (T)
        /// </summary>
        Sound = 1 << 19,

        /// <summary>
        /// Legacy IMM_WOOD (X)
        /// </summary>
        Wood = 1 << 23,

        /// <summary>
        /// Legacy IMM_SILVER (Y)
        /// </summary>
        Silver = 1 << 24,

        /// <summary>
        /// Legacy IMM_IRON (Z)
        /// </summary>
        Iron = 1 << 25
    }
}
