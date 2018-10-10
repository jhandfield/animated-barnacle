using System.Collections.Generic;

namespace ROMSharp.Models
{
    public class ObjectData : ObjectPrototypeData
    {
        #region Properties
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

        public ObjectData InObject { get; set; }

        public bool Enchanted { get; set; }

        public int Timer { get; set; }

        /// <summary>
        /// The multiplier for the weight of objects contained within, in percentage; typically 100%, but containers can override
        /// </summary>
        public int WeightMultiplier { get { return (this.ObjectType == Enums.ItemClass.Container) ? (int)this.Values[4] : 100; } }

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
        public ObjectData()
        {
            Contains = new List<ObjectData>();
        }

        public ObjectData(ObjectPrototypeData proto) : this()
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
        public void GiveTo(CharacterData ch)
        {
            CarriedBy = ch;
            InRoom = null;
            InObject = null;
            ch.CarryNumber = GetObjectNumber();
            ch.CarryWeight = GetObjectWeight();

            ch.Inventory.Add(this);
        }

        /// <summary>
        /// Returns the true weight of an object, ignoring any container multipliers
        /// </summary>
        protected int GetTrueObjectWeight()
        {
            return GetObjectWeight(true);
        }

        /// <summary>
        /// Determine the weight of the object
        /// </summary>
        /// <returns>The weight of the object, plus any objects it contains.</returns>
        protected int GetObjectWeight(bool ignoreMultiplier = false)
        {
            // Base weight is the weight of the object
            int weight = this.Weight;

            // Add weight of any objects contained within
            foreach (ObjectData containedObj in this.Contains)
                if (ignoreMultiplier)
                    weight += containedObj.GetObjectWeight();
                else
                    weight += containedObj.GetObjectWeight() * this.WeightMultiplier;

            // Return the calculated weight
            return weight;
        }

        // Return the number of objects this object counts as - most count as 1, plus any objects they contain
        protected int GetObjectNumber()
        {
            int number = 0;

            // Most objects count as 1
            if (ObjectType != Enums.ItemClass.Container || ObjectType != Enums.ItemClass.Money || ObjectType != Enums.ItemClass.Jewelry || ObjectType != Enums.ItemClass.Gem)
                number = 1;

            // Add any objects this object contains
            foreach(ObjectData obj in Contains)
                number += obj.GetObjectNumber();

            // Return the number
            return number;
        }

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
