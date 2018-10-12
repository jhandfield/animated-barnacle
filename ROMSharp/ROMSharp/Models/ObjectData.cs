using System;
using System.Collections.Generic;
using System.Text;
using ROMSharp.Enums;
using ROMSharp.Models;

namespace ROMSharp.Models
{
    public class ObjectData
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

        public RoomIndexData InRoom { get; set; }

        public ObjectData InObject { get; set; }

        public bool Enchanted { get; set; }

        public int Timer { get; set; }

        /// <summary>
        /// The multiplier for the weight of objects contained within, in percentage; typically 100%, but containers can override
        /// </summary>
        public int WeightMultiplier { get { return (this.ObjectType == Enums.ItemClass.Container) ? (int)this.Values[4] : 100; } }

        /// <summary>
        /// Extra descriptions for the object
        /// </summary>
        public List<ExtraDescription> ExtraDescriptions { get; set; }

        /// <summary>
        /// Effects provided by the object
        /// </summary>
        public List<AffectData> Affected { get; set; }

        /// <summary>
        /// Whether the object definition is in the new format?
        /// </summary>
        /// <remarks>Is this needed still?</remarks>
        /// <value><c>true</c> if new format; otherwise, <c>false</c>.</value>
        public bool NewFormat { get; set; }

        /// <summary>
        /// Name of the object
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Short description of the object
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Long description of the object
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Reset number of the object
        /// </summary>
        public int ResetNum { get; set; }

        /// <summary>
        /// Material of the object
        /// </summary>
        public string Material { get; set; }

        /// <summary>
        /// Type of the object
        /// </summary>
        public ItemClass ObjectType { get; set; }

        /// <summary>
        /// Extra flags to describe the object
        /// </summary>
        public ItemExtraFlag ExtraFlags { get; set; }

        /// <summary>
        /// Wear flags of the object, describing how it is worn
        /// </summary>
        public WearFlag WearFlags { get; set; }

        /// <summary>
        /// Level of the object
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Condition of the object
        /// </summary>
        public int Condition { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Weight of the object
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Cost/value of the object
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// Additional values for the object, dependent on the <seealso cref="ObjectType"/>
        /// </summary>
        /// <remarks>
        /// This is probably the first place I'm diverging from the stock ROM
        /// 2.4 source code in a significant way. In the original source, there
        /// are cases where this array will contain integer representations of
        /// things like weapon types (sword, dagger, etc.) which are stored as
        /// the array index of the matching row. This is 2018, there's simpler
        /// ways to handle this now, so Values is an array of objects and we'll
        /// just know what to convert them to inherently based on other factors
        /// when the time to read them comes. Deal with it.
        /// </remarks>
        public object[] Values { get; set; }

        public ObjectPrototypeData Prototype { get; set; }

        #region Facts
        public bool IsAffected(Enums.ItemExtraFlag aff)
        {
            return this.ExtraFlags.HasFlag(aff);
        }
        #endregion
        #endregion

        #region Constructors
        public ObjectData()
        {
            Contains = new List<ObjectData>();
            ExtraDescriptions = new List<ExtraDescription>();
            Affected = new List<AffectData>();
        }

        public ObjectData(ObjectPrototypeData proto, int level) : this(proto)
        {
            Level = (level > 0) ? level : 0;
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
            Prototype = proto;

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

        public string FormatObjToChar(CharacterData ch, bool shortVersion)
        {
            if ((shortVersion && String.IsNullOrWhiteSpace(this.ShortDescription)) || String.IsNullOrWhiteSpace(this.Description))
                return String.Empty;

            StringBuilder sb = new StringBuilder();

            if (this.IsAffected(ItemExtraFlag.Invis))
                sb.Append("(Invis) ");

            if (ch.IsAffected(AffectedByFlag.DetectEvil) && this.IsAffected(ItemExtraFlag.Evil))
                sb.Append("(Red Aura) ");

            if (ch.IsAffected(AffectedByFlag.DetectGood) && this.IsAffected(ItemExtraFlag.Bless))
                sb.Append("(Blue Aura)");

            if (ch.IsAffected(AffectedByFlag.DetectMagic) && this.IsAffected(ItemExtraFlag.Magic))
                sb.Append("(Magical) ");

            if (this.IsAffected(ItemExtraFlag.Glow))
                sb.Append("(Glowing) ");

            if (this.IsAffected(ItemExtraFlag.Hum))
                sb.Append("(Humming) ");

            if (shortVersion)
                sb.Append(this.ShortDescription);
            else
                sb.Append(this.Description);

            return sb.ToString();
        }
        #endregion
    }
}
