using System.Collections.Generic;
using System.Linq;

namespace ROMSharp.Models
{
    public class Mobs : List<MobPrototypeData>
    {
        public Mobs() { }

        public new MobPrototypeData this[int key]
        {
            get
            {
                return this.SingleOrDefault(m => m.VNUM == key);
            }
        }
    }
}
