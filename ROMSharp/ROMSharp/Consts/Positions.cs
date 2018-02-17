using System.Collections.Generic;
using ROMSharp.Enums;

namespace ROMSharp.Consts
{
    public class Positions
    {
        public static List<Models.Position> PositionTable = new List<Models.Position>() {
            new Models.Position("dead", "dead", Position.Dead),
            new Models.Position("mort", "mortally wounded", Position.MortallyWounded),
            new Models.Position("incap", "incapacitated", Position.Incapacitated),
            new Models.Position("stun", "stunned", Position.Stunned),
            new Models.Position("sleep", "sleeping", Position.Sleeping),
            new Models.Position("rest", "resting", Position.Resting),
            new Models.Position("sit", "sitting", Position.Sitting),
            new Models.Position("fight", "fighting", Position.Fighting),
            new Models.Position("stand", "standing", Position.Standing)
        };
    }
}
