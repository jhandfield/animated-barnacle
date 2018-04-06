using System;
namespace ROMSharp.Enums
{
    /// <summary>
    /// Flags to indicate the parts of the mobile's form
    /// </summary>
    [Flags]
    public enum PartFlag
    {
        // Body parts
        None = 0,

        /// <summary>
        /// Legacy PART_HEAD (A)
        /// </summary>
        Head = AlphaMacros.A,

        /// <summary>
        /// Legacy PART_ARMS (B)
        /// </summary>
        Arms = AlphaMacros.B,

        /// <summary>
        /// Legacy PART_LEGS (C)
        /// </summary>
        Legs = AlphaMacros.C,

        /// <summary>
        /// Legacy PART_HEAR (D)
        /// </summary>
        Heart = AlphaMacros.D,

        /// <summary>
        /// Legacy PART_BRAINS (E)
        /// </summary>
        Brains = AlphaMacros.E,

        /// <summary>
        /// Legacy PART_GUTS (F)
        /// </summary>
        Guts = AlphaMacros.F,

        /// <summary>
        /// Legacy PART_HANDS (G)
        /// </summary>
        Hands = AlphaMacros.G,

        /// <summary>
        /// Legacy PART_FEET (H)
        /// </summary>
        Feet = AlphaMacros.H,

        /// <summary>
        /// Legacy PART_FINGERS (I)
        /// </summary>
        Fingers = AlphaMacros.I,

        /// <summary>
        /// Legacy PART_EAR (J)
        /// </summary>
        Ear = AlphaMacros.J,

        /// <summary>
        /// Legacy PART_EYE (K)
        /// </summary>
        Eye = AlphaMacros.K,

        /// <summary>
        /// Legacy PART_LONG_TONGUE (L)
        /// </summary>
        LongTongue = AlphaMacros.L,

        /// <summary>
        /// Legacy PART_EYESTALKS (M)
        /// </summary>
        Eyestalks = AlphaMacros.M,

        /// <summary>
        /// Legacy PART_TENTACLES (N)
        /// </summary>
        Tentacles = AlphaMacros.N,

        /// <summary>
        /// Legacy PART_FINS (O)
        /// </summary>
        Fins = AlphaMacros.O,

        /// <summary>
        /// Legacy PART_WINGS (P)
        /// </summary>
        Wings = AlphaMacros.P,

        /// <summary>
        /// Legacy PART_TAIL (Q)
        /// </summary>
        Tail = AlphaMacros.Q,

        // For combat
        /// <summary>
        /// Legacy PART_CLAWS (U)
        /// </summary>
        Claws = AlphaMacros.U,

        /// <summary>
        /// Legacy PART_FANGS (V)
        /// </summary>
        Fangs = AlphaMacros.V,

        /// <summary>
        /// Legacy PART_HORNS (W)
        /// </summary>
        Horns = AlphaMacros.W,

        /// <summary>
        /// Legacy PART_SCALES (X)
        /// </summary>
        Scales = AlphaMacros.X,

        /// <summary>
        /// Legacy PART_TUSKS (Y)
        /// </summary>
        Tusks = AlphaMacros.Y
    }
}
