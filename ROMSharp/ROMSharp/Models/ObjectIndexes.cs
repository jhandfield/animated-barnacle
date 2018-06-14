using System.Collections.Generic;
using System.Linq;

namespace ROMSharp.Models
{
    public class ObjectIndexes : List<ObjectPrototypeData>
    {
        public ObjectIndexes() { }

        public new ObjectPrototypeData this[int key]
        {
            get
            {
                return this.SingleOrDefault(o => o.VNUM == key);
            }
        }
    }
}
