using System;
namespace ROMSharp.Helpers
{
    public partial class Miscellaneous
    {
        public partial class Randomness
        {
            /// <summary>
            /// Reimplementation of number_fuzzy() from handler.c
            /// </summary>
            public static int NumberFuzzy(int number)
            {
                switch (NumberBits(2))
                {
                    case 0: number -= 1; break;
                    case 3: number += 1; break;
                }

                return Helpers.Miscellaneous.HighestOf(new int[] { 1, number });
            }

            /// <summary>
            /// Reimplemenation of number_bits() from handler.c
            /// </summary>
            public static int NumberBits(int width)
            {
                return NumberMM() & ((1 << width) - 1);
            }

            /// <summary>
            /// Reimplementation of number_mm() from handler.c
            /// </summary>
            public static int NumberMM()
            {
                return Program.randGen.Next() >> 6;
            }
        }
    }
}
