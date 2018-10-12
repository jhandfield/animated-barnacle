using System;
namespace ROMSharp.Helpers
{
    public static partial class Miscellaneous
    {
        /// <summary>
        /// Implementation of the ROM 2.4b4 alias URANGE
        /// </summary>
        /// <returns>Generally the middle number, but not always. Not 100% certain the logic/intent behind this.</returns>
        /// <param name="a">The alpha value</param>
        /// <param name="b">The bravo value</param>
        /// <param name="c">The charlie value</param>
        public static int URange(int a, int b, int c)
        {
            return ((b) < (a) ? (a) : ((b) > (c) ? (c) : (b)));
        }
    }
}
