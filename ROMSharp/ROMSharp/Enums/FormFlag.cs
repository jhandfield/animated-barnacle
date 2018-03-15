using System;
namespace ROMSharp.Enums
{
    /// <summary>
    /// Flags to represent the form of a mobile
    /// </summary>
    [Flags]
    public enum FormFlag
    {
        // Body form
		None = 0,

        /// <summary>
        /// Legacy FORM_EDIBLE (A)
        /// </summary>
        Edible = AlphaMacros.A,

        /// <summary>
        /// Legacy FORM_POISON (B)
        /// </summary>
        Poison = AlphaMacros.B,

        /// <summary>
        /// Legacy FORM_MAGICAL (C)
        /// </summary>
        Magical = AlphaMacros.C,

        /// <summary>
        /// Legacy FORM_INSTANT_DECAY (D)
        /// </summary>
        InstantDecay = AlphaMacros.D,

        /// <summary>
        /// Legacy FORM_OTHER (E)
        /// </summary>
        Other = AlphaMacros.E,

        // Actual form
        /// <summary>
        /// Legacy FORM_ANIMAL (G)
        /// </summary>
        Animal = AlphaMacros.G,

        /// <summary>
        /// Legacy FORM_SENTIENT (H)
        /// </summary>
        Sentient = AlphaMacros.H,

        /// <summary>
        /// Legacy FORM_UNDEAD (I)
        /// </summary>
        Undead = AlphaMacros.I,

        /// <summary>
        /// Legacy FORM_CONSTRUCT (J)
        /// </summary>
        Construct = AlphaMacros.J,

        /// <summary>
        /// Legacy FORM_MIST (K)
        /// </summary>
        Mist = AlphaMacros.K,

        /// <summary>
        /// Legacy FORM_INTANGIBLE (L)
        /// </summary>
        Intangible = AlphaMacros.L,

        /// <summary>
        /// Legacy FORM_BIPED (M)
        /// </summary>
        Biped = AlphaMacros.M,

        /// <summary>
        /// Legacy FORM_CENTAUR (N)
        /// </summary>
        Centaur = AlphaMacros.N,

        /// <summary>
        /// Legacy FORM_INSECT (O)
        /// </summary>
        Insect = AlphaMacros.O,

        /// <summary>
        /// Legacy FORM_SPIDER (P)
        /// </summary>
        Spider = AlphaMacros.P,

        /// <summary>
        /// Legacy FORM_CRUSTACEAN (Q)
        /// </summary>
        Crustacean = AlphaMacros.Q,

        /// <summary>
        /// Legacy FORM_WORM (R)
        /// </summary>
        Worm = AlphaMacros.R,

        /// <summary>
        /// Legacy FORM_BLOB (S)
        /// </summary>
        Blob = AlphaMacros.S,

        /// <summary>
        /// Legacy FORM_MAMMAL (V)
        /// </summary>
        Mammal = AlphaMacros.V,

        /// <summary>
        /// Legacy FORM_BIRD (W)
        /// </summary>
        Bird = AlphaMacros.W,

        /// <summary>
        /// Legacy FORM_REPTILE (X)
        /// </summary>
        Reptile = AlphaMacros.X,

        /// <summary>
        /// Legacy FORM_SNAKE (Y)
        /// </summary>
        Snake = AlphaMacros.Y,

        /// <summary>
        /// Legacy FORM_DRAGON (Z)
        /// </summary>
        Dragon = AlphaMacros.Z,

        /// <summary>
        /// Legacy FORM_AMPHIBIAN (aa)
        /// </summary>
        Amphibian = AlphaMacros.aa,

        /// <summary>
        /// Legacy FORM_FISH (bb)
        /// </summary>
        Fish = AlphaMacros.bb,

        /// <summary>
        /// Legacy FORM_COLD_BLOOD (cc)
        /// </summary>
        ColdBlood = AlphaMacros.cc
    }
}
