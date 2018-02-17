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
        Head = 1 << 0,          // PART_HEAD
        Arms = 1 << 1,          // PART_ARMS
        Legs = 1 << 2,          // PART_LEGS
        Heart = 1 << 3,         // PART_HEART
        Brains = 1 << 4,        // PART_BRAINS
        Guts = 1 << 5,          // PART_GUTS
        Hands = 1 << 6,         // PART_HANDS
        Feet = 1 << 7,          // PART_FEET
        Fingers = 1 << 8,       // PART_FINGERS
        Ear = 1 << 9,           // PART_EAR
        Eye = 1 << 10,          // PART_EYE
        LongTongue = 1 << 11,   // PART_LONG_TONGUE
        Eyestalks = 1 << 12,    // PART_EYESTALKS
        Tentacles = 1 << 13,    // PART_TENTACLES
        Fins = 1 << 14,         // PART_FINS
        Wings = 1 << 15,        // PART_WINGS
        Tail = 1 << 16,         // PART_TAIL

        // For combat
        Claws = 1 << 20,        // PART_CLAWS
        Fangs = 1 << 21,        // PART_FANGS
        Horns = 1 << 22,        // PART_HORNS
        Scales = 1 << 23,       // PART_SCALES
        Tusks = 1 << 24         // PART_TUSKS
    }
}
