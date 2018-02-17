using System;
namespace ROMSharp.Models
{
    public class Position
    {
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public Enums.Position PositionCode { get; set; }

        public Position() { }
        public Position(string shortName, string longName, Enums.Position posCode)
        {
            ShortName = shortName;
            LongName = longName;
            PositionCode = posCode;
        }
    }
}
