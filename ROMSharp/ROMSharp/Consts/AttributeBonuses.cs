using System;
using ROMSharp.Models.AttributeBonus;

namespace ROMSharp.Consts
{
    public static class AttributeBonuses
    {
        /// <summary>
        /// Strength attribute bonuses
        /// </summary>
        public static StrengthBonus[] StrengthBonusTable = new StrengthBonus[26] {
            new StrengthBonus(-5, -4, 0, 0),
            new StrengthBonus(-5, -4, 3, 1),
            new StrengthBonus(-3, -2, 3, 2),
            new StrengthBonus(-3, -1, 10, 3),
            new StrengthBonus(-2, -1, 25, 4),
            new StrengthBonus(-2, -1, 55, 5),
            new StrengthBonus(-1, 0, 80, 6),
            new StrengthBonus(-1, 0, 90, 7),
            new StrengthBonus(0, 0, 100, 8),
            new StrengthBonus(0, 0, 100, 9),
            new StrengthBonus(0, 0, 115, 10),
            new StrengthBonus(0, 0, 115, 11),
            new StrengthBonus(0, 0, 130, 12),
            new StrengthBonus(0, 0, 130, 13),
            new StrengthBonus(0, 1, 140, 14),
            new StrengthBonus(1, 1, 150, 15),
            new StrengthBonus(1, 2, 165, 16),
            new StrengthBonus(2, 3, 180, 22),
            new StrengthBonus(2, 3, 200, 25),
            new StrengthBonus(3, 4, 225, 30),
            new StrengthBonus(3, 5, 250, 35),
            new StrengthBonus(4, 6, 300, 40),
            new StrengthBonus(4, 6, 350, 45),
            new StrengthBonus(5, 7, 400, 50),
            new StrengthBonus(5, 8, 450, 55),
            new StrengthBonus(6, 9, 500, 60)
        };
    }
}
