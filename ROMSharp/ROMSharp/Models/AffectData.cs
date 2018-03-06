using System;
namespace ROMSharp.Models
{
    public class AffectData
    {
        #region Properties
        public bool Valid { get; set; }
        public int Where { get; set; }
        public int Type { get; set; }
        public int Level { get; set; }
        public int Duration { get; set; }
        public int Location { get; set; }
        public int Modifier { get; set; }
        public int BitVector { get; set; }
        #endregion

        public AffectData()
        {
        }
    }
}
