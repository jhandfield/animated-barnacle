using System;
namespace ROMSharp.Models
{
    public class ItemType
    {
        public string Name { get; set; }
        public Enums.ItemClass Type { get; set; }

        public ItemType() { }
        public ItemType(string name, Enums.ItemClass type)
        {
            Name = name;
            Type = type;
        }
    }
}
