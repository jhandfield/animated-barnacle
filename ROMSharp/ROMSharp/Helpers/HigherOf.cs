using System;
using System.Collections.Generic;
using System.Linq;

namespace ROMSharp.Helpers
{
    public partial class Miscellaneous
    {
        public static int HighestOf(ICollection<int> values)
        {
            return values.Max();
        }
    }
}
