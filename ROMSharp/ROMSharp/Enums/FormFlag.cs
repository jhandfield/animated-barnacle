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
        Edible = 1 << 0,        // FORM_EDIBLE
        Poison = 1 << 1,        // FORM_POISON
        Magical = 1 << 2,       // FORM_MAGICAL
        InstantDecay = 1 << 3,  // FORM_INSTANT_DECAY
        Other = 1 << 4,         // FORM_OTHER

        // Actual form
        Animal = 1 << 6,        // FORM_ANIMAL
        Sentient = 1 << 7,      // FORM_SENTIENT
        Undead = 1 << 8,        // FORM_UNDEAD
        Construct = 1 << 9,     // FORM_CONSTRUCT
        Mist = 1 << 10,         // FORM_MIST
        Intangible = 1 << 11,   // FORM_INTANGIBLE

        Biped = 1 << 12,        // FORM_BPIED
        Centaur = 1 << 13,      // FORM_CENTAUR
        Insect = 1 << 14,       // FORM_INSECT
        Spider = 1 << 15,       // FORM_SPIDER
        Crustacean = 1 << 16,   // FORM_CRUSTACEAN
        Worm = 1 << 17,         // FORM_WORM
        Blob = 1 << 18,         // FORM_BLOB

        Mammal = 1 << 21,       // FORM_MAMMAL
        Bird = 1 << 22,         // FORM_BIRD
        Reptile = 1 << 23,      // FORM_REPTILE
        Snake = 1 << 24,        // FORM_SNAKE
        Dragon = 1 << 25,       // FORM_DRAGON
        Amphibian = 1 << 26,    // FORM_AMPHIBIAN
        Fish = 1 << 27,         // FORM_FISH
        ColdBlood = 1 << 28     // FORM_COLD_BLOOD
    }
}
