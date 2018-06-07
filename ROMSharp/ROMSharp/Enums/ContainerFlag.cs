using System;
namespace ROMSharp.Enums
{
    [Flags]
    public enum ContainerFlag
    {
        None = 0,
        /// <summary>
        /// Legacy CONT_CLOSEABLE (A)
        /// </summary>
        Closeable = AlphaMacros.A,

        /// <summary>
        /// Legacy CONT_PICKPROOF (B)
        /// </summary>
        PickProof = AlphaMacros.B,

        /// <summary>
        /// Legacy CONT_CLOSED (C)
        /// </summary>
        Closed = AlphaMacros.C,

        /// <summary>
        /// Legacy CONT_LOCKED (D)
        /// </summary>
        Locked = AlphaMacros.D,

        /// <summary>
        /// Legacy CONT_PUT_ON (E)
        /// </summary>
        PutOn = AlphaMacros.E
    }
}
