using System;
using System.Collections.Generic;

namespace ROMSharp.Models
{
    /// <summary>
    /// Represents a room contained within an area
    /// </summary>
    public class RoomIndexData
    {
        #region Properties
        /// <summary>
        /// Contains the next room in the sequence of loading
        /// </summary>
        /// <remarks>Not sure this is still needed</remarks>
        public RoomIndexData NextRoom { get; set; }

        /// <summary>
        /// Contains references to all characters currently in the room
        /// </summary>
        /// <value>The people.</value>
        public List<CharacterData> People { get; set; }

        /// <summary>
        /// Contains references to all objects currently in the room
        /// </summary>
        public List<ObjectData> Objects { get; set; }

        /// <summary>
        /// Contains references to all extra descriptions available in the room
        /// </summary>
        public List<ExtraDescription> ExtraDescriptions { get; set; }

        /// <summary>
        /// Information regarding the exits of the room
        /// </summary>
        public Exits Exits { get; set; }

        /// <summary>
        /// Name of the room
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the room
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// VNUM of the room
        /// </summary>
        public int VNUM { get; set; }

        /// <summary>
        /// Attributes of the room (e.g. that it is dark, indoors, and private)
        /// </summary>
        /// <value>The attributes.</value>
        public RoomAttributes Attributes { get; set; }

        /// <summary>
        /// Level of light in the room - anything greater than 0 is lit
        /// </summary>
        public int LightLevel { get; set; }

        /// <summary>
        /// Defines the type of terrain the room represents
        /// </summary>
        public SectorType SectorType { get; set; }

        /// <summary>
        /// The rate at which health regenerates while in this room (percent
        /// bonus, 100 is default)
        /// </summary>
        public int HealRate { get; set; }

        /// <summary>
        /// The rate at which mana regenerates while in this room (percent
        /// bonus, 100 is default)
        /// </summary>
        public int ManaRate { get; set; }

        /// <summary>
        /// Indicates the clan that owns the room; influences who can see and
        /// enter the room.
        /// </summary>
        public int OwningClan { get; set; }
        #endregion

        #region Constructors
        public RoomIndexData() { }
        #endregion
    }

    /// <summary>
    /// Attributes that describe a room (e.g. that it is Dark (Dark), 
    /// Indoors (Indoors), and only allows 1 person at a time (Solitary)
    /// </summary>
    /// <remarks>
    /// To maintain compatibility with stock ROM area files, the flags are
    /// arranged in the same order as in the ROM 2.4b6 code. This makes the
    /// flags a little disorganized, but it is what it is.
    /// </remarks>
    [Flags]
    public enum RoomAttributes
    {
        None = 0,
        Dark = 1 << 0,
        NoMobs = 1 << 1,
        Indoors = 1 << 2,
        Private = 1 << 3,
        Safe = 1 << 4,
        Solitary = 1 << 5,
        PetShop = 1 << 6,
        NoRecall = 1 << 7,
        ImpOnly = 1 << 8,
        GodsOnly = 1 << 9,
        HeroesOnly = 1 << 10,
        NewbiesOnly = 1 << 11,
        Law = 1 << 12,
        Nowhere = 1 << 13
    }

    /// <summary>
    /// Represents the terrain of a room
    /// </summary>
    public enum SectorType
    {
        Inside = 0,
        City = 1,
        Field = 2,
        Forest = 3,
        Hills = 4,
        Mountain = 5,
        /// <summary>
        /// Fun fact, the *only* thing this influences is the chance of being
        /// able to blind something by kicking dirt while fighting!
        /// </summary>
        WaterSwimming = 6,
        WaterNotSwimming = 7,
        /// <summary>
        /// Kept around for compatibility with old area files. I guess?
        /// </summary>
        Unused = 8,
        Air = 9,
        Desert = 10,
        Max = 11
    }
}
