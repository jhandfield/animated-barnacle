using System.Collections.Generic;
using ROMSharp.Enums;

namespace ROMSharp.Consts
{
    public class Size
    {
        public static List<Models.Size> SizeTable = new List<Models.Size>() {
            new Models.Size("tiny", Enums.Size.Tiny),
            new Models.Size("small", Enums.Size.Small),
            new Models.Size("medium", Enums.Size.Medium),
            new Models.Size("large", Enums.Size.Large),
            new Models.Size("huge", Enums.Size.Huge),
            new Models.Size("giant", Enums.Size.Giant)
        };
    }
}
