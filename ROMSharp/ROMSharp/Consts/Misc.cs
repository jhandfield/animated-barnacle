using System;

namespace ROMSharp.Consts
{
	public class Misc
	{
		public class CharacterName
		{
			public const int MinLength = 2;
			public const int MaxLength = 12;
		}

        public class TelnetCommands
        {
            public static byte[] LocalEchoOff = new byte[3] { 0xFF, 0xFB, 0x01 };
            public static byte[] LocalEchoOnn = new byte[3] { 0xFF, 0xFC, 0x01 };
        }

        public class Safety {
            /// <summary>
            /// Maximum number of lines to read before assuming a long text record is malformed and we've missed the terminator somehow
            /// </summary>
            public static int MaxLongTextLines = 100;
        }
	}
}

