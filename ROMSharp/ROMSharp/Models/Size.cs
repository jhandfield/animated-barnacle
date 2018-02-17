using System;
namespace ROMSharp.Models
{
    public class Size
    {
        public string Name { get; set; }

        public Enums.Size SizeCode { get; set; }

        public Size() { }
        public Size(string name, Enums.Size sizeCode) {
            Name = name;
            SizeCode = sizeCode;
        }
    }
}
