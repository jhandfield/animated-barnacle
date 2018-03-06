using System.Collections.Generic;

namespace ROMSharp.Models
{
    public class ObjectData
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

        /// <summary>
        /// Effects inherent in this obejct
        /// </summary>
        public AffectData Affected { get; set; }


        #endregion

        #region Constructors
        public ObjectData() { }
        #endregion
    }
}
