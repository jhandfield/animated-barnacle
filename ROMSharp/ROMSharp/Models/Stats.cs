using System;
namespace ROMSharp.Models
{
    public class Stats
    {
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }

        public Stats() { }
        public Stats(int value) {
            Strength = value;
            Intelligence = value;
            Wisdom = value;
            Dexterity = value;
            Constitution = value;
        }

        public int this[int key]
        {
            get
            {
                switch (key)
                {
                    case 0:
                        return Strength;
                    case 1:
                        return Intelligence;
                    case 2:
                        return Wisdom;
                    case 3:
                        return Dexterity;
                    case 4:
                        return Constitution;
                    default:
                        return -1;
                }
            }
        }
    }
}
