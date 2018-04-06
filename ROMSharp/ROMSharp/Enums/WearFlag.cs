using System;
namespace ROMSharp.Enums
{
    public enum WearFlag
    {
        None = 0,
        Take = 1 << 0,
        Wear_Finger = 1 << 1,
        Wear_Neck = 1 << 2,
        Wear_Body = 1 << 3,
        Wear_Head = 1 << 4,
        Wear_Legs = 1 << 5,
        Wear_Feet = 1 << 6,
        Wear_Hands = 1 << 7,
        Wear_Arms = 1 << 8,
        Wear_Shield = 1 << 9,
        Wear_About = 1 << 10,
        Wear_Waist = 1 << 11,
        Wear_Wrist = 1 << 12,
        Wield = 1 << 13,
        Hold = 1 << 14,
        NoSacrifice = 1 << 15,
        Wear_Float = 1 << 16
    }
}