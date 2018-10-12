using System.Collections.Generic;
using ROMSharp.Enums;

namespace ROMSharp.Consts
{
    public class Gender
    {
        public static List<Models.Gender> GenderTable = new List<Models.Gender>() {
            new Models.Gender("none", Sex.Neutral),
            new Models.Gender("male", Sex.Male),
            new Models.Gender("female", Sex.Female),
            new Models.Gender("either", Sex.Random)
        };

        public Gender() { }
    }
}
