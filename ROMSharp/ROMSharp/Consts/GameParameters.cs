using System;
using System.Linq;

namespace ROMSharp.Consts
{
    public class GameParameters
    {
        public class Maximums
        {
            public static int Social { get { return 256; } }
            public static int Skill { get { return 150; } }
            public static int Stats { get { return 5; } }
            public static int Group { get { return 30; } }
            public static int InGroup { get { return 15; } }
            public static int Alias { get { return 5; } }
            public static int Class { get { return 4; } }
            public static int PCRace { get { return 5; } }
            public static int Clan { get { return 3; } }
            public static int DamageMessage { get { return 41; } }
            public static int Level { get { return 60; } }
        }

        public class StateOfBeing
        {
            public static int Implementor { get { return Maximums.Level; } }
            public static int Creator { get { return Maximums.Level - 1; } }
            public static int Supreme { get { return Maximums.Level - 2; } }
            public static int Deity { get { return Maximums.Level - 3; } }
            public static int God { get { return Maximums.Level - 4; } }
            public static int Immortal { get { return Maximums.Level - 5; } }
            public static int Demi { get { return Maximums.Level - 6; } }
            public static int Angel { get { return Maximums.Level - 7; } }
            public static int Avatar { get { return Maximums.Level - 8; } }
            public static int Hero { get { return Maximums.Level - 9; } }
        }

        public class Timing
        {
            public static int PulsePerSecond { get { return 4; } }
            public static int PulseViolence { get { return 3 * PulsePerSecond; } }
            public static int PulseMobile { get { return 4 * PulsePerSecond; } }
            public static int PulseMusic { get { return 6 * PulsePerSecond; } }
            public static int PulseTick { get { return 60 * PulsePerSecond; } }
            public static int PulseArea { get { return 120 * PulsePerSecond; } }
        }

        public class Defaults
        {
            public static int PageLength { get { return 22; } }
            public static int ArmorRating { get { return 100; } }
            public static int Health { get { return 20; } }
            public static int Mana { get { return 100; } }
            public static int Movement { get { return 100; } }
            public static Models.Position Position { get { return Positions.PositionTable.Single(p => p.ShortName.Equals("stand")); } }
            public static int Stats { get { return 13; } }
        }
    }
}