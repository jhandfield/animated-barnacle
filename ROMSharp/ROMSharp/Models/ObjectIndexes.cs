using System.Collections.Generic;
using System.Linq;

namespace ROMSharp.Models
{
    public class ObjectIndexes : List<ObjectIndexData>
    {
        public ObjectIndexes() { }

        public new ObjectIndexData this[int key]
        {
            get
            {
                return this.SingleOrDefault(o => o.VNUM == key);
            }
        }
    }
}
