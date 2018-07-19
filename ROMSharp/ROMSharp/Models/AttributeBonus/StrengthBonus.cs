using System;
namespace ROMSharp.Models.AttributeBonus
{
    public class StrengthBonus
    {
        public int ToHit { get; set; }
        public int ToDamage { get; set; }
        public int Carry { get; set; }
        public int Wield { get; set; }

        public StrengthBonus() { }
        public StrengthBonus(int hit, int dam, int car, int wie) {
            ToHit = hit;
            ToDamage = dam;
            Carry = car;
            Wield = wie;
        }
    }
}
