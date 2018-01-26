using System;
namespace ROMSharp.Models
{
    public class ExtraDescription
    {
        #region Properties
        /// <summary>
        /// Keywords the player can search for to reference this object
        /// </summary>
        /// <value>The keywords.</value>
        public string Keywords { get; set;  }

        /// <summary>
        /// Description to return for the Keywords
        /// </summary>
        public string Description { get; set; }
        #endregion

        #region Constructors
        public ExtraDescription() { }
        #endregion
    }
}
