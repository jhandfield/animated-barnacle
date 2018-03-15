using System;
using System.Linq;
using ROMSharp.Enums;

namespace ROMSharp.Models
{
    /// <summary>
    /// Represents a collection of up to 6 exits from a room
    /// </summary>
    public class Exits
    {
        #region Fields
        private Exit[] _exits;
        #endregion

        #region Constructors
        public Exits()
        {
            this._exits = new Exit[6];
        }
        #endregion

        #region Indexers
        public Exit this[int index]
        {
            get
            {
                // Ensure the index is in range
                if (index < 0)
                    throw new IndexOutOfRangeException("Exit index must be 0 or greater");
                else if (index > (int)Enum.GetValues(typeof(Direction)).Cast<Direction>().Max())
                    throw new IndexOutOfRangeException(String.Format("Exit index must not be greater than {0}", (int)Enum.GetValues(typeof(Direction)).Cast<Direction>().Max()));
                else
                    return this._exits[index];
            }
            set {
                this._exits[index] = value;
            }
        }
        #endregion
    }

    /// <summary>
    /// Represents an exit portal from a room
    /// </summary>
    public class Exit
    {
        #region Properties
        /// <summary>
        /// Reference to the RoomIndexData the exit leads to
        /// </summary>
        public RoomIndexData ToRoom { get; set; }

        /// <summary>
        /// VNUM of the room the exit leads to
        /// </summary>
        public int ToVNUM { get; set; }

        /// <summary>
        /// Attributes of the door (e.g. IsDoor &amp; Closed &amp; Locked)
        /// </summary>
        public ExitAttributes Attributes { get; set; }

        /// <summary>
        /// VNUM of the key for this exit, if applicable
        /// </summary>
        public int KeyVNUM { get; set; }

        /// <summary>
        /// ObjectData reference to the key object for this exit
        /// </summary>
        public ObjectData Key { get; set; }

        /// <summary>
        /// Keywords to describe this exit
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        /// Description to provide to the character who looks at one of the keywords
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Direction of the exit (e.g. north, south, up)
        /// </summary>
        public Direction Direction { get; set; }
        #endregion

        #region Constructors
        public Exit() { }
        #endregion
    }

    /// <summary>
    /// Attributes that describe an exit (e.g. it is a door (Door) that is 
    /// closed (Closed) and locked (Locked))
    /// </summary>
    /// <remarks>
    /// To maintain compatibility with stock ROM area files, the flags are
    /// arranged in the same order as in the ROM 2.4b6 code. This makes the
    /// flags a little disorganized, but it is what it is.
    /// </remarks>
    [Flags]
    public enum ExitAttributes
    {
        None = 0,

        /// <summary>
        /// Legacy EX_ISOOR (A)
        /// </summary>
        Door = AlphaMacros.A,

        /// <summary>
        /// Legacy EX_CLOSED (B)
        /// </summary>
        Closed = AlphaMacros.B,

        /// <summary>
        /// Legacy EX_LOCKED (C)
        /// </summary>
        Locked = AlphaMacros.C,

        /// <summary>
        /// Legacy EX_PICKPROOF (F)
        /// </summary>
        PickProof = AlphaMacros.F,

        /// <summary>
        /// Legacy EX_NOPASS (G)
        /// </summary>
        NoPass = AlphaMacros.G,

        /// <summary>
        /// Legacy EX_EASY (H)
        /// </summary>
        LockedEasy = AlphaMacros.H,

        /// <summary>
        /// Legacy EX_HARD (I)
        /// </summary>
        LockedHard = AlphaMacros.I,

        /// <summary>
        /// Legacy EX_INFURIATING (J)
        /// </summary>
        LockedInfuriating = AlphaMacros.J,

        /// <summary>
        /// Legacy EX_NOCLOSE (K)
        /// </summary>
        NoClose = AlphaMacros.K,

        /// <summary>
        /// Legacy EX_NOLOCK (L)
        /// </summary>
        NoLock = AlphaMacros.L
    }
}