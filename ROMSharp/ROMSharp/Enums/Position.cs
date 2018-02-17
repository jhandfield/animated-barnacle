using System;
namespace ROMSharp.Enums
{
    /// <summary>
    /// Possible positions for a character or mobile
    /// </summary>
    public enum Position
    {
        /// <summary>
        /// The (N)PC is transcending their mortal form (no one should hit this state)
        /// </summary>
        Transcendant = -1,

        /// <summary>
        /// The (N)PC is dead
        /// </summary>
        Dead = 0,

        /// <summary>
        /// The (N)PC is mortally wounded and will die soon without aid
        /// </summary>
        MortallyWounded = 1,

        /// <summary>
        /// The (N)PC is incapacitated and will die in the future without aid
        /// </summary>
        Incapacitated = 2,

        /// <summary>
        /// The (N)PC is stunned but will recover without further outside negative influence
        /// </summary>
        Stunned = 3,

        /// <summary>
        /// The (N)PC is sleeping, unaware of its surroundings
        /// </summary>
        Sleeping = 4,

        /// <summary>
        /// The (N)PC is resting, aware of its surroundings
        /// </summary>
        Resting = 5,

        /// <summary>
        /// The (N)PC is sitting, chillin'
        /// </summary>
        Sitting = 6,

        /// <summary>
        /// The (N)PC is in combat
        /// </summary>
        Fighting = 7,

        /// <summary>
        /// The (N)PC is standing around looking dumb
        /// </summary>
        Standing = 8
    }
}
