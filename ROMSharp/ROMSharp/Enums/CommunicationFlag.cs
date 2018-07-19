using System;
namespace ROMSharp.Enums
{
    [Flags]
    public enum CommunicationFlag
    {
        None = 0,

        /// <summary>
        /// Legacy COMM_QUIET (A)
        /// </summary>
        Quiet = AlphaMacros.A,

        /// <summary>
        /// Legacy COMM_DEAF (B)
        /// </summary>
        Deaf = AlphaMacros.B,

        /// <summary>
        /// Legacy COMM_NOWIZ (C)
        /// </summary>
        NoWiz = AlphaMacros.C,

        /// <summary>
        /// Legacy COMM_NOAUCTION (D)
        /// </summary>
        NoAuction = AlphaMacros.D,

        /// <summary>
        /// Legacy COMM_NOGOSSIP (E)
        /// </summary>
        NoGossip = AlphaMacros.E,

        /// <summary>
        /// Legacy COMM_NOQUESTION (F)
        /// </summary>
        NoQuestion = AlphaMacros.F,

        /// <summary>
        /// Legacy COMM_NOMUSIC (G)
        /// </summary>
        NoMusic = AlphaMacros.G,

        /// <summary>
        /// Legacy COMM_NOCLAN (H)
        /// </summary>
        NoClan = AlphaMacros.H,

        /// <summary>
        /// Legacy COMM_NOQUOTE (I)
        /// </summary>
        NoQuote = AlphaMacros.I,

        /// <summary>
        /// Legacy COMM_SHOUTSOFF (J)
        /// </summary>
        ShoutsOff = AlphaMacros.J,

        #region Display Flags
        /// <summary>
        /// Legacy COMM_COMPACT (L)
        /// </summary>
        Compact = AlphaMacros.L,

        /// <summary>
        /// Legacy COMM_BRIEF (M)
        /// </summary>
        Brief = AlphaMacros.M,

        /// <summary>
        /// Legacy COMM_PROMPT (N)
        /// </summary>
        Prompt = AlphaMacros.N,

        /// <summary>
        /// Legacy COMM_COMBINE (O)
        /// </summary>
        Combine = AlphaMacros.O,

        /// <summary>
        /// Legacy COMM_TELNET_GA (P)
        /// </summary>
        TelnetGA = AlphaMacros.P,

        /// <summary>
        /// Legacy COMM_SHOW_AFFECTS (O)
        /// </summary>
        ShowAffects = AlphaMacros.Q,

        /// <summary>
        /// Legacy COMM_NOGRATS (R)
        /// </summary>
        NoGrats = AlphaMacros.R,
        #endregion

        #region Penalties
        /// <summary>
        /// Legacy COMM_NOEMOTE (T)
        /// </summary>
        NoEmote = AlphaMacros.T,

        /// <summary>
        /// Legacy COMM_NOSHOUT (U)
        /// </summary>
        NoShout = AlphaMacros.U,

        /// <summary>
        /// Legacy COMM_NOTELL (V)
        /// </summary>
        NoTell = AlphaMacros.V,

        /// <summary>
        /// Legacy COMM_NOCHANNELS (W)
        /// </summary>
        NoChannels = AlphaMacros.W,

        /// <summary>
        /// Legacy COMM_SNOOP_PROOF (Y)
        /// </summary>
        SnoopProof = AlphaMacros.Y,

        /// <summary>
        /// Legacy COMM_AFK (Z)
        /// </summary>
        AFK = AlphaMacros.Z,
        #endregion
    }
}
