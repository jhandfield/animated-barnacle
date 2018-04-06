using System;
using System.Collections.Generic;
using System.Linq;

namespace ROMSharp.Models
{
    public class Objects : List<ObjectIndexData>
    {
        public Objects() { }

        public new ObjectIndexData this[int key]
        {
            get
            {
                return this.SingleOrDefault(o => o.VNUM == key);
            }
        }
    }
}
