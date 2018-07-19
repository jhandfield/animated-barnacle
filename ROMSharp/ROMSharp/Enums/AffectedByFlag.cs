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
        /// <summary>
        /// Legacy AFF_BLIND (A)
        /// </summary>
        Blind = AlphaMacros.A,

        /// <summary>
        /// Legacy AFF_INVISIBLE (B)
        /// </summary>
        Invisible = AlphaMacros.B,

        /// <summary>
        /// Legacy AFF_DETECT_EVIL (C)
        /// </summary>
        DetectEvil = AlphaMacros.C,

        /// <summary>
        /// Legacy AFF_DETECT_INVIS (D)
        /// </summary>
        DetectInvis = AlphaMacros.D,

        /// <summary>
        /// Legacy AFF_DETECT_MAGIC (E)
        /// </summary>
        DetectMagic = AlphaMacros.E,

        /// <summary>
        /// Legacy AFF_DETECT_HIDDEN (F)
        /// </summary>
        DetectHidden = AlphaMacros.F,

        /// <summary>
        /// Legacy AFF_DETECT_GOOD (G)
        /// </summary>
        DetectGood = AlphaMacros.G,

        /// <summary>
        /// Legacy AFF_SANCTUARY (H)
        /// </summary>
        Sanctuary = AlphaMacros.H,

        /// <summary>
        /// Legacy AFF_FAERIE_FIRE (I)
        /// </summary>
        FaerieFire = AlphaMacros.I,

        /// <summary>
        /// Legacy AFF_INFRARED (J)
        /// </summary>
        Infrared = AlphaMacros.J,

        /// <summary>
        /// Legacy AFF_CURSE (K)
        /// </summary>
        Curse = AlphaMacros.K,

        /// <summary>
        /// Legacy AFF_UNDEAD_FLAG (L) - Marked as unused in original source
		/// </summary>
        UndeadFlag = AlphaMacros.L,

        /// <summary>
        /// Legacy AFF_POISON (M)
        /// </summary>
        Poison = AlphaMacros.M,

        /// <summary>
        /// Legacy AFF_PROTECT_EVIL (N)
        /// </summary>
        ProtectEvil = AlphaMacros.N,

        /// <summary>
        /// Legacy AFF_PROTECT_GOOD (O)
        /// </summary>
        ProtectGood = AlphaMacros.O,

        /// <summary>
        /// Legacy AFF_SNEAK (P)
        /// </summary>
        Sneak = AlphaMacros.P,

        /// <summary>
        /// Legacy AFF_HIDE (O)
        /// </summary>
        Hide = AlphaMacros.Q,

        /// <summary>
        /// Legacy AFF_SLEEP (R)
        /// </summary>
        Sleep = AlphaMacros.R,

        /// <summary>
        /// Legacy AFF_CHARM (S)
        /// </summary>
        Charm = AlphaMacros.S,

        /// <summary>
        /// Legacy AFF_FLYING (T)
        /// </summary>
        Flying = AlphaMacros.T,

        /// <summary>
        /// Legacy AFF_PASS_DOOR (U)
        /// </summary>
        PassDoor = AlphaMacros.U,

        /// <summary>
        /// Legacy AFF_HASTE (V)
        /// </summary>
        Haste = AlphaMacros.V,

        /// <summary>
        /// Legacy AFF_CALM (W)
        /// </summary>
        Calm = AlphaMacros.W,

        /// <summary>
        /// Legacy AFF_PLAGUE (X)
        /// </summary>
        Plague = AlphaMacros.X,

        /// <summary>
        /// Legacy AFF_WEAKEN (Y)
        /// </summary>
        Weaken = AlphaMacros.Y,

        /// <summary>
        /// Legacy AFF_DARK_VISION (Z)
        /// </summary>
        DarkVision = AlphaMacros.Z,

        /// <summary>
        /// Legacy AFF_BERSERK (aa)
        /// </summary>
        Berserk = AlphaMacros.aa,

        /// <summary>
        /// Legacy AFF_SWIM (bb)
        /// </summary>
        Swim = AlphaMacros.bb,

        /// <summary>
        /// Legacy AFF_REGENERATION (cc)
        /// </summary>
        Regeneration = AlphaMacros.cc,

        /// <summary>
        /// Legacy AFF_SLOW (dd)
        /// </summary>
        Slow = AlphaMacros.dd
    }
}