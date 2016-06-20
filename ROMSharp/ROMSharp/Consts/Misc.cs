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
	}
}

