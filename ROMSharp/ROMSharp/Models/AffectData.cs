using System;
namespace ROMSharp.Models
{
    public class AffectData
    {
        #region Properties
        public bool Valid { get; set; }
        public Enums.ToWhere Where { get; set; }
        public int Type { get; set; }
        public int Level { get; set; }
        public int Duration { get; set; }
        public Enums.ApplyType Location { get; set; }
        public int Modifier { get; set; }
        public int BitVector { get; set; }
        #endregion

        public AffectData()
        {
            Where = new Enums.ToWhere();
        }

		public override bool Equals(object obj)
		{
            if (obj == null || GetType() != obj.GetType())
                return false;

            AffectData ad = (AffectData)obj;

            return Valid == ad.Valid
                              && Where == ad.Where
                              && Type == ad.Type
                              && Level == ad.Level
                              && Duration == ad.Duration
                              && Location == ad.Location
                              && Modifier == ad.Modifier
                              && BitVector == ad.BitVector;
		}
	}
}
