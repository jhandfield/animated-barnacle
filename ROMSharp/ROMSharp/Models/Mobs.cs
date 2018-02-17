using System.Collections.Generic;
using System.Linq;

namespace ROMSharp.Models
{
    public class Mobs : List<MobData>
    {
        public Mobs() { }

        public new MobData this[int key]
        {
            get
            {
                return this.SingleOrDefault(m => m.VNUM == key);
            }
        }
    }
}
