using System;
namespace ROMSharp.Enums
{
    public enum ItemExtraFlag
    {
        None = 0,
        Glow = 1 << 0,
        Hum = 1 << 1,
        Dark = 1 << 2,
        Lock = 1 << 3,
        Evil = 1 << 4,
        Invis = 1 << 5,
        Magic = 1 << 6,
        NoDrop = 1 << 7,
        Bless = 1 << 8,
        AntiGood = 1 << 9,
        AntiEvil = 1 << 10,
        AntiNeutral = 1 << 11,
        NoRemove = 1 << 12,
        Inventory = 1 << 13,
        NoPurge = 1 << 14,
        RotDeath = 1 << 15,
        VisDeath = 1 << 16,
        NonMetal = 1 << 18,
        NoLocate = 1 << 19,
        MeltDrop = 1 << 20,
        HadTimer = 1 << 21,
        SellExtract = 1 << 22,
        BurnProof = 1 << 23,
        NoUnCurse = 1 << 25
    }
}
