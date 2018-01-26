using System;
namespace ROMSharp.Models
{
    /// <summary>
    /// Represents an area within the world
    /// </summary>
    public class AreaData
    {
        #region Properties
        /// <summary>
        /// Contains the next area in the sequence of loading
        /// </summary>
        /// <remarks>Is this needed in this code? I'm not so sure.</remarks>
        public AreaData NextArea { get; set; }

        /// <summary>
        /// Used when resetting area, identifies the first object to be reset
        /// </summary>
        /// <value>The reset first.</value>
        public ResetData ResetFirst { get; set; }

        /// <summary>
        /// Used when resetting area, identifies the last object to be reset
        /// </summary>
        /// <value>The reset last.</value>
        public ResetData ResetLast { get; set; }

        /// <summary>
        /// Filename the area was loaded from
        /// </summary>
        public string Filename { get; set;  }

        /// <summary>
        /// Name of the area
        /// </summary>
        public string Name { get; set;  }

        /// <summary>
        /// Credits data for the information (author, license, etc.)
        /// </summary>
        /// <value>The credits.</value>
        public string Credits { get; set;  }

        /// <summary>
        /// Age of the area - used to determine when the area should be reset
        /// </summary>
        /// <value>The age.</value>
        public int Age { get; set; }

        /// <summary>
        /// Number of players currently in the area
        /// </summary>
        public int NumPlayers { get; set;  }

        /// <summary>
        /// Minimum VNum in the area's range
        /// </summary>
        public int MinVNum { get; set;  }

        /// <summary>
        /// Maximum VNum in the area's range
        /// </summary>
        /// <value>The max VN um.</value>
        public int MaxVNum { get; set;  }

        /// <summary>
        /// Indicates whether the area is empty (has no PC's within it)
        /// </summary>
        public bool IsEmpty { get { return this.NumPlayers == 0; } }
        #endregion

        #region Constructors
        public AreaData() { }
        #endregion
    }
}