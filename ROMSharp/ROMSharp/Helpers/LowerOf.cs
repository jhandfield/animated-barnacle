using System;
using System.Collections.Generic;
using System.Linq;

namespace ROMSharp.Helpers
{
    public static partial class Miscellaneous
    {
        /// <summary>
        /// Return the lowest value in the set <paramref name="values"/>
        /// </summary>
        /// <param name="values">Collection of values to consider</param>
        public static int LowestOf(ICollection<int> values)
        {
            return values.Min();
        }
    }
}
