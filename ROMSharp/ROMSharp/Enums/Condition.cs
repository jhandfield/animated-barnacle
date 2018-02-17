using System;
namespace ROMSharp.Enums
{
    /// <summary>
    /// Potential conditions for a mobile or character
    /// </summary>
    public enum Condition
    {
        /// <summary>
        /// None of the conditions apply
        /// </summary>
        None = -1,

        /// <summary>
        /// The (N)PC is drunk
        /// </summary>
        Drunk = 0,

        /// <summary>
        /// The (N)PC is full and cannot eat more
        /// </summary>
        Full = 1,

        /// <summary>
        /// The (N)PC is thirsty and needs to drink
        /// </summary>
        Thirsty = 2,

        /// <summary>
        /// The (N)PC is hungry and needs to eat
        /// </summary>
        Hungry = 3
    }
}
