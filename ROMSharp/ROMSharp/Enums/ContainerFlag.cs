using System;
namespace ROMSharp.Enums
{
    [Flags]
    public enum ContainerFlag
    {
        None = 0,
        /// <summary>
        /// Legacy CONT_CLOSEABLE (1)
        /// </summary>
        Closeable = 1 << 0,

        /// <summary>
        /// Legacy CONT_PICKPROOF (2)
        /// </summary>
        PickProof = 1 << 1,

        /// <summary>
        /// Legacy CONT_CLOSED (4)
        /// </summary>
        Closed = 1 << 2,

        /// <summary>
        /// Legacy CONT_LOCKED (8)
        /// </summary>
        Locked = 1 << 3,

        /// <summary>
        /// Legacy CONT_PUT_ON (16)
        /// </summary>
        PutOn = 1 << 4
    }
}
