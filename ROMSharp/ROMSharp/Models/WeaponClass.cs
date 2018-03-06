using System;
namespace ROMSharp.Models
{
    public class WeaponClass
    {
        public string Name { get; set; }
        public Enums.WeaponClass Type { get; set; }
        public ObjectIndexData StarterWeapon { get { return Program.World.Objects[this.StarterWeaponVNUM]; } }
        public int StarterWeaponVNUM { get; set; }
        public object PrimarySkill { get { throw new NotImplementedException(); } }

        public WeaponClass() { }
        public WeaponClass(string name, Enums.WeaponClass type, int starterVNUM, object skill)
        {
            Name = name;
            Type = type;
            StarterWeaponVNUM = starterVNUM;
        }
    }
}
