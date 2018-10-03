using System.Collections.Generic;

namespace ROMSharp.Models
{
    public class ObjectData : ObjectPrototypeData
    {
        #region Properties
        public int VNUM { get; set; }

        /// <summary>
        /// List of objects contained within this object
        /// </summary>
        public List<ObjectData> Contains { get; set; }

        /// <summary>
        /// Reference to the object in which this object is contained
        /// </summary>
        public ObjectData ContainedBy { get; set; }

        /// <summary>
        /// Reference to the object on which this object is placed (e.g. on top of a table)
        /// </summary>
        public ObjectData On { get; set; }

        /// <summary>
        /// Reference to the character (or mobile) carrying this object
        /// </summary>
        public CharacterData CarriedBy { get; set; }

        /// <summary>
        /// Extra descriptions for this object
        /// </summary>
        public ExtraDescription ExtraDescription { get; set; }

        public RoomIndexData InRoom { get; set; }

        public bool Enchanted { get; set; }

        public int Timer { get; set; }

        /// <summary>
        /// Effects inherent in this obejct
        /// </summary>
        //public AffectData Affected { get; set; }

        /// <summary>
        /// Name of the object
        /// </summary>
        //public string Name { get; set; }

        /// <summary>
        /// Weight of the object
        /// </summary>
        //public int Weight { get; set; }
        #endregion

        #region Constructors
        public ObjectData() : base()
        {
            Contains = new List<ObjectData>();

        }
        public ObjectData(ObjectPrototypeData proto) : base()
        {
            Level = proto.Level;
            Name = proto.Name;
            ShortDescription = proto.ShortDescription;
            Description = proto.Description;
            Material = proto.Material;
            ObjectType = proto.ObjectType;
            ExtraFlags = proto.ExtraFlags;
            WearFlags = proto.WearFlags;
            Values = proto.Values;
            Weight = proto.Weight;
            Cost = proto.Cost;

            if (ObjectType == Enums.ItemClass.Light && (int)Values[2] == 999)
                Values[2] = -1;

            foreach (AffectData aff in Affected)
            {
                if (aff.Location == Enums.ApplyType.SpellAffect)
                    ApplyAffect(aff);

            }
        }
        #endregion
        #region Methods
        public void ApplyAffect(AffectData aff)
        {
            // Add the affect to the object
            this.Affected.Add(aff);

            // Apply affect vectors if appropriate
            if (aff.BitVector != Enums.AffectedByFlag.None)
            {
                switch (aff.Where)
                {
                    case Enums.ToWhere.Object:
                        // Not 100% sure this is correct, should I be loading BitVector as an ItemExtraFlag initially?
                        this.ExtraFlags |= (Enums.ItemExtraFlag)aff.BitVector;
                        break;
                    case Enums.ToWhere.Weapon:
                        if (this.ObjectType == Enums.ItemClass.Weapon)
                            this.Values[4] = aff.BitVector;

                        break;
                }
            }
        }
        #endregion
    }
}
