using System.Collections.Generic;

namespace ROMSharp.Consts
{
    public class WeaponClass
    {
        public static List<Models.WeaponClass> WeaponTable = new List<Models.WeaponClass>() {
            new Models.WeaponClass("sword", Enums.WeaponClass.Sword, 3702, null),
            new Models.WeaponClass("mace", Enums.WeaponClass.Mace, 3700, null),
            new Models.WeaponClass("dagger", Enums.WeaponClass.Dagger, 3701, null),
            new Models.WeaponClass("axe", Enums.WeaponClass.Axe, 3719, null),
            new Models.WeaponClass("staff", Enums.WeaponClass.Spear, 3718, null),
            new Models.WeaponClass("flail", Enums.WeaponClass.Flail, 3720, null),
            new Models.WeaponClass("whip", Enums.WeaponClass.Whip, 3721, null),
            new Models.WeaponClass("polearm", Enums.WeaponClass.Polearm, 3722, null),
            new Models.WeaponClass("exotic", Enums.WeaponClass.Exotic, 0, null)
        };
    }
}
