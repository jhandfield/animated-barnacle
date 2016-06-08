using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMSharp.Consts
{
    public class Strings
    {
		public const string LoginPasswordPrompt = "Password: ";
		public const string CreationPasswordPrompt = "Give me a password for";
		public const string LoginCharacterNameIllegal = "Illegal name, try another.\nName: ";
        public const string Goodbye = "Goodbye!";
		public const string Greeting = @"THIS IS A MUD BASED ON.....

                                ROM Version 2.4 beta

               Original DikuMUD by Hans Staerfeldt, Katja Nyboe,
               Tom Madsen, Michael Seifert, and Sebastian Hammer
               Based on MERC 2.1 code by Hatchet, Furey, and Kahn
               ROM 2.4 copyright (c) 1993-1998 Russ Taylor

By what name do you wish to be known? ";

		public static readonly string[] IllegalNames = new string[10] { "all", "auto", "immortal", "self", "someone", "something", "the", "you", "loner", "Alander" };
    }
}
