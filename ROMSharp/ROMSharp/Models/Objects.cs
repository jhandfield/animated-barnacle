using System;
using System.Collections.Generic;
using System.Linq;

namespace ROMSharp.Models
{
    public class Objects : List<ObjectPrototypeData>
    {
        public Objects() { }

        public new ObjectPrototypeData this[int key]
        {
            get
            {
                return this.SingleOrDefault(o => o.VNUM == key);
            }
        }
    }
}
