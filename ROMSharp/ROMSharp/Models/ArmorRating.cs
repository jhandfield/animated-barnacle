using System;

namespace ROMSharp.Models
{
    /// <summary>
    /// Represents a mobile's armor rating across four damage types
    /// </summary>
    public class ArmorRating
    {
        #region Properties
        /// <summary>
        /// Resistance to Piercing damage
        /// </summary>
        public int Pierce { get; set; }

        /// <summary>
        /// Resistance to Bashing damage
        /// </summary>
        public int Bash { get; set; }

        /// <summary>
        /// Resistance to Slashing damage
        /// </summary>
        public int Slash { get; set; }

        /// <summary>
        /// Resistance to Exotic damage
        /// </summary>
        public int Exotic { get; set; }
        #endregion

        #region Constructors
        public ArmorRating() { }

        /// <summary>
        /// Instantiate a new ArmorRating object with a preset value applied to all ratings
        /// </summary>
        /// <param name="rating">Armor rating to default all types to</param>
        public ArmorRating(int rating)
        {
            // Set all components to the rating
            Pierce = rating;
            Bash = rating;
            Slash = rating;
            Exotic = rating;
        }

        /// <summary>
        /// Instantiate a new ArmorRating object with preset values
        /// </summary>
        /// <param name="pierce">Piercing resistance</param>
        /// <param name="bash">Bashing resistance</param>
        /// <param name="slash">Slashing resistance</param>
        /// <param name="exotic">Exotic resistance</param>
        public ArmorRating(int pierce, int bash, int slash, int exotic)
        {
            // Set components
            Pierce = pierce;
            Bash = bash;
            Slash = slash;
            Exotic = exotic;
        }

        internal void Modify(int modifier)
        {
            Pierce += modifier;
            Bash += modifier;
            Slash += modifier;
            Exotic += modifier;
        }
        #endregion
    }
}