using System.Collections.Generic;
using ROMSharp.Models;
using ROMSharp.Enums;

namespace ROMSharp.Consts
{
    public class ItemTypes
    {
        public static List<ItemType> ItemTypeTable = new List<ItemType>()
        {
            new ItemType("light", ItemClass.Light),
            new ItemType("scroll", ItemClass.Scroll),
            new ItemType("wand", ItemClass.Wand),
            new ItemType("staff", ItemClass.Staff),
            new ItemType("weapon", ItemClass.Weapon),
            new ItemType("treasure", ItemClass.Treasure),
            new ItemType("armor", ItemClass.Armor),
            new ItemType("potion", ItemClass.Portal),
            new ItemType("clothing", ItemClass.Clothing),
            new ItemType("furniture", ItemClass.Furniture),
            new ItemType("trash", ItemClass.Trash),
            new ItemType("container", ItemClass.Container),
            new ItemType("drink", ItemClass.DrinkContainer),
            new ItemType("key", ItemClass.Key),
            new ItemType("food", ItemClass.Food),
            new ItemType("money", ItemClass.Money),
            new ItemType("boat", ItemClass.Boat),
            new ItemType("npc_corpse", ItemClass.CorpseNPC),
            new ItemType("pc_corpse", ItemClass.CorpsePC),
            new ItemType("fountain", ItemClass.Fountain),
            new ItemType("pill", ItemClass.Pill),
            new ItemType("protect", ItemClass.Protect),
            new ItemType("map", ItemClass.Map),
            new ItemType("portal", ItemClass.Portal),
            new ItemType("warp_stone", ItemClass.WarpStone),
            new ItemType("room_key", ItemClass.RoomKey),
            new ItemType("gem", ItemClass.Gem),
            new ItemType("jewelry", ItemClass.Jewelry),
            new ItemType("jukebox", ItemClass.Jukebox)
        };
    }
}
