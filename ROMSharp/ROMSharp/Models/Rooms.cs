using System;
using System.Collections.Generic;
using System.Linq;

namespace ROMSharp.Models
{
    public class Rooms : List<RoomIndexData>
    {
        public Rooms() { }

        public new RoomIndexData this[int key]
        {
            get {
                return this.SingleOrDefault(r => r.VNUM == key);
            }
        }
    }
}
