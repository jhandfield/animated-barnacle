using System;

namespace ROMSharp.Consts
{
	public class Misc
	{
		public class CharacterName
		{
			public static int MinLength = 2;
			public static int MaxLength = 12;
		}

        public class TelnetCommands
        {
            public static byte[] LocalEchoOff = new byte[3] { 0xFF, 0xFB, 0x01 };
            public static byte[] LocalEchoOnn = new byte[3] { 0xFF, 0xFC, 0x01 };
        }

        public class Safety {
            /// <summary>
            /// Maximum number of lines to read before assuming the #ROOM record is malformed around the Description
            /// </summary>
            public static int MaxRoomDescLines = 50;
        }
	}
}

