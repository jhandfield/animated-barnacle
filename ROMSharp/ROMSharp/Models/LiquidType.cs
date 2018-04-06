using System;
namespace ROMSharp.Models
{
    public class LiquidType
    {
        /// <summary>
        /// Name of the liquid
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Color of the liquid
        /// </summary>
        /// <value>The color.</value>
        public string Color { get; set; }

        /// <summary>
        /// Affects / properties of the liquid
        /// </summary>
        public LiquidAffects Affects { get; set; }

        public LiquidType() { Affects = new LiquidAffects(); }
        public LiquidType(string name, string color, int[] affects) : this()
        {
            // Validate the affects array
            if (affects.Length != 5)
                throw new ArgumentException("Invalid array length, must be 5 elements", "affects");

            // Set properties
            Name = name;
            Color = color;
            Affects.Proof = affects[0];
            Affects.Full = affects[1];
            Affects.Thirst = affects[2];
            Affects.Food = affects[3];
            Affects.SSize = affects[4];
        }
    }

    public class LiquidAffects
    {
        /// <summary>
        /// Alcohol content of the liquid
        /// </summary>
        public int Proof { get; set; }

        /// <summary>
        /// Impact on the drinker's fullness
        /// </summary>
        public int Full { get; set; }

        /// <summary>
        /// Impact on the drinker's thirst
        /// </summary>
        public int Thirst { get; set; }

        /// <summary>
        /// Impact on the drinker's hunger
        /// </summary>
        public int Food { get; set; }

        /// <summary>
        /// Volume consumed per drink
        /// </summary>
        public int SSize { get; set; }
    }
}
