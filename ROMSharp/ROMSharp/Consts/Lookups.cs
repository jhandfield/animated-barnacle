using System;
using System.Collections.Generic;
namespace ROMSharp.Consts
{
    public partial class Lookups
    {
        // Provides a more verbose description of the EquipmentSlot
        public static Dictionary<Enums.EquipSlot, string> EquipSlotNames = new Dictionary<Enums.EquipSlot, string>() {
            { Enums.EquipSlot.Light, "<used as light>     " },
            { Enums.EquipSlot.LeftFinger, "<worn on finger>    " },
            { Enums.EquipSlot.RightFinger, "<worn on finger>    " },
            { Enums.EquipSlot.Neck1, "<worn around neck>  " },
            { Enums.EquipSlot.Neck2, "<worn around neck>  "},
            { Enums.EquipSlot.Body, "<worn on torso>     "},
            { Enums.EquipSlot.Head, "<worn on head>      "},
            { Enums.EquipSlot.Legs, "<worn on legs>      "},
            { Enums.EquipSlot.Feet, "<worn on feet>      "},
            { Enums.EquipSlot.Hands, "<worn on hands>     "},
            { Enums.EquipSlot.Arms, "<worn on arms>      "},
            { Enums.EquipSlot.Shield, "<worn as shield>    "},
            { Enums.EquipSlot.About, "<worn about body>   "},
            { Enums.EquipSlot.Waist, "<worn about waist>  "},
            { Enums.EquipSlot.LeftWrist, "<worn around wrist> "},
            { Enums.EquipSlot.RightWrist, "<worn around wrist> "},
            { Enums.EquipSlot.Wield, "<wielded>           "},
            { Enums.EquipSlot.Hold, "<held>              "},
            { Enums.EquipSlot.Float, "<floating nearby>   "}
        };
    }
}
