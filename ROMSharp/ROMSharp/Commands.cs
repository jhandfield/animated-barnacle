using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using ROMSharp.Interfaces;
using ROMSharp.Enums;
using ROMSharp.Models;
using static ROMSharp.Consts.GameParameters;

namespace ROMSharp
{
	/// <summary>
	/// Contains methods representing the possible commands to be invoked by users
	/// </summary>
	public class Commands
	{
        /// <summary>
        /// Look command - describes the room, object, mob, etc. specified
        /// </summary>
        public class Look : ICommand
        {
            public string Name => "look";

            public IEnumerable<string> Aliases => new string[1] { "examine" };

            public string HelpText =>
                @"Syntax: look\n\r
Syntax: look    <object>\n\r
Syntax: look    <character>\n\r
Syntax: look    <direction>\n\r
Syntax: look    <keyword>\n\r
Syntax: look in <container>\n\r
Syntax: look in <corpse>\n\r
Syntax: examine <container>\n\r
Syntax: examine <corpse>\n\r
\n\r
LOOK looks at something and sees what you can see.\n\r
\n\r
EXAMINE is short for 'LOOK container' followed by 'LOOK IN container'.\n\r"
;
            public Enums.Position MinimumPosition => Enums.Position.Resting;

            public int MinimumLevel => 0;

            public CommandLogLevel LogLevel => CommandLogLevel.LogNormal;

            public bool Show => true;

            public void Execute(CharacterData ch, string[] args)
            {
                string arg1, arg2;

                // Recombine args
                List<string> argList = args.ToList();
                string command = args.First();
                argList.RemoveAt(0);
                string arguments = String.Join(" ", argList);

                // Pull arguments
                arguments = GetOneArgument(arguments, out arg1);
                arguments = GetOneArgument(arguments, out arg2);

                Network.ClientConnection state = ch.Descriptor;
                CharacterData victim;
                RoomIndexData room;

                // Get the character's current room
                room = ch.InRoom;

                // Attempt to pull a character from the first argument
                victim = room.Characters.SingleOrDefault(c => c.Name.ToLower().Equals(arg1));

                if (victim != null)
                {
                    string output = ShowCharToChar(ch, victim);
                    Network.Send(output + "\n\r", state);
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(String.Format("{0}\n\r\n\r{1}\n\r\n\r", room.Name, room.Description));

                    foreach (CharacterData person in room.Characters)
                        sb.Append(person.LongDescription + "\n\r");

                    Network.Send(sb.ToString() + "\n\r", state);
                }
            }
        }

        /// <summary>
        /// Goto command - sends the character to the specified room
        /// </summary>
        public class Goto : ICommand
        {
            public string Name => "goto";

            public IEnumerable<string> Aliases => new string[0];

            public string HelpText => @"Usage: goto <room VNUM>\n\r
Immediately sends the player to the room with the specified VNUM.\n\r";

            public Enums.Position MinimumPosition => Enums.Position.Dead;

            public int MinimumLevel => Maximums.Level - 4;

            public CommandLogLevel LogLevel => CommandLogLevel.LogNormal;

            public bool Show => true;

            public void Execute(CharacterData ch, string[] args)
            {
                string arg1 = args[1];

                Network.ClientConnection state;
                state = ch.Descriptor;

                if (Int32.TryParse(arg1, out int roomID) && Program.World.Rooms[roomID] != null)
                {
                    state.PlayerCharacter.InRoom = Program.World.Rooms[roomID];
                    Network.Send("Ok.\n\r\n\r", state);
                }
                else
                    Network.Send("Syntax: goto [room VNUM]\n\r\n\r", state);
            }
        }

        /// <summary>
        /// Shutdown - Shuts down the service
        /// </summary>
        public class Shutdown : ICommand
        {
            public string Name => "shutdown";

            public IEnumerable<string> Aliases => new string[1] { "shutdow" };

            public string HelpText => "Shuts down the service";

            public Enums.Position MinimumPosition => Enums.Position.Dead;

            public int MinimumLevel => Maximums.Level - 1;

            public CommandLogLevel LogLevel => CommandLogLevel.LogAlways;

            public bool Show => true;

            public void Execute(CharacterData ch, string[] args)
            {
                ServerControl.Shutdown();
            }
        }

        /// <summary>
        /// Ends a user's session with the service
        /// </summary>
        public class Quit : ICommand
        {
            public string Name => "quit";

            public IEnumerable<string> Aliases => new string[1] { "qui" };

            public string HelpText => @"Syntax: QUIT\n\r
Syntax: RENT ... not!\n\r
Syntax: SAVE\n\r
\n\r
SAVE saves your character and object.  The game saves your character every\n\r
15 minutes regardless, and is the preferred method of saving.  Typing save\n\r
will block all other command for about 20 seconds, so use it sparingly.\n\r
(90+ players all typing save every 30 seconds just generated too much lag)\n\r
\n\r
Some objects, such as keys and potions, may not be saved.\n\r
\n\r
QUIT leaves the game.  You may QUIT anywhere.  When you re-enter the game \n\r
you will be back in the same room.\n\r
\n\r
QUIT automatically does a SAVE, so you can safely leave the game with just one\n\r
command.  Nevertheless it's a good idea to SAVE before QUIT.  If you get into\n\r
the habit of using QUIT without SAVE, and then you play some other mud that\n\r
doesn't save before quitting, you're going to regret it.\n\r
\n\r
There is no RENT in this mud.  Just SAVE and QUIT whenever you want to leave.\n\r";

            public Enums.Position MinimumPosition => Enums.Position.Dead;

            public int MinimumLevel => 0;

            public CommandLogLevel LogLevel => CommandLogLevel.LogNormal;

            public bool Show => true;

            public void Execute(CharacterData ch, string[] args)
            {
                //TODO: Implement actual quit/save logic
                Network.EndSession(ch.Descriptor);
            }
        }

        /// <summary>
        /// Outputs a list of open sockets in the service to the calling player
        /// </summary>
        public class ListConnections : ICommand
        {
            public string Name => "listconnections";

            public IEnumerable<string> Aliases => new string[0];

            public string HelpText => "Lists all active connections with the service";

            public Enums.Position MinimumPosition => Enums.Position.Dead;

            public int MinimumLevel => 0;

            public CommandLogLevel LogLevel => CommandLogLevel.LogNormal;

            public bool Show => true;

            public void Execute(CharacterData ch, string[] args)
            {
                // For now, get a ClientConnection since I haven't reworked everything to just use the ID yet
                Network.ClientConnection state = ch.Descriptor;

                // Header
                string result = "ACTIVE CONNECTIONS\n\rID     Remote IP         Player       Duration   Tx/Rx\n\r";
                //2345	  123.123.123.132   00:00:00   Seath        1024.1MB/1024.1MB   

                // Data
                foreach (Network.ClientConnection conn in Network.ClientConnections)
                {
                    result += String.Format("{0,-7}{1,-18}{2,-13}{3,-11}{4}/{5}\n\r",
                        conn.ID.ToString(),
                        conn.RemoteIP.ToString(),
                        ch.Name,
                        conn.ConnectionDuration.ToString(@"hh\:mm\:ss"),
                        conn.bytesSent,
                        conn.bytesReceived);
                }

                // Send the result
                Network.Send(result, state);
            }
        }

        /// <summary>
        /// Loads the specified mobile of the specified level in the calling player's room, or loads the specified object of the specified level into the calling player's inventory
        /// </summary>
        public class Load : ICommand
        {
            public string Name => "load";

            public IEnumerable<string> Aliases => new string[0];

            public string HelpText => @"Syntax: load mob <vnum>\n\r
        load obj <vnum> <level>\n\r
\n\r
The load command is used to load new objects or mobiles (use clone to\n\r
duplicate strung items and mobs).  The vnums can be found with the vnum\n\r
command, or by stat'ing an existing mob or object.\n\r
\n\r
Load puts objects in inventory if they can be carried, otherwise they are\n\r
put in the room.  Mobiles are always put into the same room as the god. Old\n\r
format objects must be given a level argument to determine their power, new\n\r
format objects have a preset level that cannot be changed without set.\n\r
(see also clone, vnum, stat)\n\r";

            public Enums.Position MinimumPosition => Enums.Position.Dead;

            public int MinimumLevel => Maximums.Level - 4;

            public CommandLogLevel LogLevel => CommandLogLevel.LogAlways;

            public bool Show => true;

            public void Execute(CharacterData ch, string[] args)
            {
                Network.ClientConnection state = ch.Descriptor;

                if (args.Length < 3)
                {
                    // Invalid, we need at least 3 arguments
                    Network.Send("Syntax:\n\r  load mob <vnum>\n\r  load obj <vnum> <level>\n\r", state);
                    return;
                }
                else
                {
                    switch (args[1].ToLower().Trim())
                    {
                        case "obj":
                            int objVNUM, objLevel;

                            // Need 4 args for this
                            if (args.Length != 4)
                            {
                                Network.Send("Syntax:\n\r  load mob <vnum>\n\r  load obj <vnum> <level>\n\r", state);
                                return;
                            }

                            // VNUM must be numeric
                            if (!Int32.TryParse(args[2], out objVNUM))
                            {
                                Network.Send("Syntax: load obj <vnum:int> <level:int>\n\r", state);
                                return;
                            }

                            // Level must be numeric and between 0 and the player's level
                            if (!Int32.TryParse(args[3], out objLevel))
                            {
                                Network.Send("Syntax: load obj <vnum:int> <level:int>\n\r", state);
                                return;
                            }
                            else
                            {
                                // Level needs to be between 0 and the player's trust level 9using player level for now)
                                // TODO: Switch to using trust level
                                if (objLevel < 0 || objLevel > state.PlayerCharacter.Level)
                                {
                                    Network.Send("Level must be between 0 and your level.\n\r", state);
                                    return;
                                }
                            }

                            // Object VNUM must exist
                            if (Program.World.Objects[objVNUM] == null)
                            {
                                Network.Send("No object has that VNUM.\n\r", state);
                                return;
                            }

                            // Go ahead and instantiate the object
                            Models.ObjectData newObj = new Models.ObjectData(Program.World.Objects[objVNUM]);

                            // Give it to the character
                            state.PlayerCharacter.Inventory.Add(newObj);

                            // Send feedback
                            Network.Send("Ok.\n\r\n\r", state);

                            break;
                        default:
                            Network.Send("Syntax:\n\r  load mob <vnum>\n\r  load obj <vnum> <level>\n\r", state);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Displays the player's inventory to themselves
        /// </summary>
        public class Inventory : ICommand
        {
            public string Name => "inventory";

            public IEnumerable<string> Aliases => new string[0];

            public string HelpText => @"Syntax: inventory\n\r
Lists your inventory\n\r";

            public Enums.Position MinimumPosition => Enums.Position.Dead;

            public int MinimumLevel => 0;

            public CommandLogLevel LogLevel => CommandLogLevel.LogNormal;

            public bool Show => true;

            public void Execute(CharacterData ch, string[] args)
            {
                Network.ClientConnection state = ch.Descriptor;

                StringBuilder sb = new StringBuilder();
                sb.Append("You are carrying:\n\r");

                if (state.PlayerCharacter.Inventory.Count == 0)
                {
                    sb.Append("Nothing.\n\r");
                }
                else
                {
                    foreach (ObjectData obj in state.PlayerCharacter.Inventory)
                    {
                        sb.Append(obj.ShortDescription + "\n\r");
                    }
                }

                // Send output
                Network.Send(sb.ToString() + "\n\r", state);
            }
        }

        /// <summary>
        /// Displays detailed statistics of the specified object/mobile/room to the calling player
        /// </summary>
        public class Stat : ICommand
        {
            public string Name => "stat";

            public IEnumerable<string> Aliases => new string[0];

            public string HelpText => @"Syntax:\n\r
        stat <name>\n\r
        stat obj <name>\n\r
        stat mob <name>\n\r
        stat room <number>\n\r
\n\r
Displays detailed statistics about the specified object, mob, or room";

            public Enums.Position MinimumPosition => Enums.Position.Dead;

            public int MinimumLevel => StateOfBeing.Immortal;

            public CommandLogLevel LogLevel => CommandLogLevel.LogAlways;

            public bool Show => true;

            public void StatRoom(CharacterData ch, int vnum)
            {
                // Attempt to find the room
                Models.RoomIndexData targetRoom = Program.World.Rooms.SingleOrDefault(r => r.VNUM.Equals(vnum));

                // Did we find it?
                if (targetRoom == null)
                {
                    // Inform the user
                    Network.Send("No such location\n\r\n\r", ch.Descriptor);
                }
                else
                {
                    string output = String.Empty;
                    output += String.Format("Name: '{0}'\n\rArea: '{1}'\n\r", targetRoom.Name, Program.World.Areas.Single(a => a.MinVNum <= targetRoom.VNUM && a.MaxVNum >= targetRoom.VNUM).Name);
                    output += String.Format("VNUM: {0}  Sector: {1}  Light: {2}  Healing: {3}  Mana: {4}\n\r",
                                            targetRoom.VNUM,
                                            targetRoom.SectorType.ToString(),
                                            targetRoom.LightLevel,
                                            targetRoom.HealRate.ToString(),
                                            targetRoom.ManaRate.ToString());
                    output += String.Format("Room Flags: {0}\n\r", ((Enums.AlphaMacros)targetRoom.Attributes).ToString().Replace(",", "").Replace(" ", ""));
                    output += String.Format("Description:\n\r{0}\n\r", targetRoom.Description);
                    output += "Extra description keywords: " + String.Join(",", targetRoom.ExtraDescriptions.Select(ed => ed.Keywords)) + "\n\r";

                    // TODO: Should check that the character can be seen by the person invoking this command
                    output += "Characters: " + String.Join(",", targetRoom.Characters.Select(person => person.Name)) + "\n\r";
                    output += "Objects: " + String.Join(",", targetRoom.Objects.Select(obj => obj.Name)) + "\n\r";

                    // Loop over possible exits
                    for (int i = 0; i <= 5; i++)
                    {
                        // Check that the exit is defined
                        if (targetRoom.Exits[i] != null)
                            // Add to output
                            output += String.Format("Door: {0}.  To: {1}.  Key: {2}.  Exit flags: {3}.\n\rKeyword: '{4}'.  Description: {5}\n\r",
                                                    i,
                                                    targetRoom.Exits[i].ToVNUM,
                                                    targetRoom.Exits[i].KeyVNUM,
                                                    ((Enums.AlphaMacros)targetRoom.Exits[i].Attributes).ToString(),
                                                    targetRoom.Exits[i].Keywords,
                                                    targetRoom.Exits[i].Description);
                    }

                    output += "\n\r";

                    // Send output to the user
                    Network.Send(output, ch.Descriptor);
                }
            }

            public void Execute(CharacterData ch, string[] args)
            {
                Network.ClientConnection state = ch.Descriptor;

                // Check the first argument for a type
                string firstArg = args[1];
                
                switch(firstArg.ToLower())
                {
                    case "room":
                        string secondArg = args[2];

                        if (!Int32.TryParse(secondArg, out int vnum))
                        {
                            Network.Send(@"Syntax:\n\r
        stat <name>\n\r
        stat obj <name>\n\r
        stat mob <name>\n\r
        stat room <number>\n\r", state);
                            return;
                        }
                        else
                            StatRoom(ch, vnum);

                        return;
                    case "obj":
                        Network.Send("\"stat obj\" not implemented yet", state);
                        return;
                    case "mob":
                        Network.Send("\"stat mob\" not implemented yet", state);
                        return;
                }
            }
        }


        /// <summary>
        /// Provides statistics of the service to the calling player
        /// </summary>
        public class ServerStats : ICommand
        {
            public string Name => "serverstats";

            public IEnumerable<string> Aliases => new string[0];

            public string HelpText => @"Syntax: serverstats\n\r
                Provides statistical information about the running service\n\r";

            public Enums.Position MinimumPosition => Enums.Position.Dead;

            public int MinimumLevel => StateOfBeing.Immortal;

            public CommandLogLevel LogLevel => CommandLogLevel.LogAlways;

            public bool Show => true;

            public void Execute(CharacterData ch, string[] args)
            {
                Network.ClientConnection state = ch.Descriptor;

                // Send statistics
                Network.Send(String.Format("SERVER STATISTICS\n\r=================\n\r{0} rooms loaded\n\r{1} mobiles loaded\n\r{2} object prototypes loaded\n\r{3} connections currently open\n\rServer uptime is {4}\n\r",
                    Program.World.Rooms.Count,
                    Program.World.Mobs.Count,
                    Program.World.Objects.Count,
                    Network.ClientConnections.Count,
                    (DateTime.Now - Program.World.StartupTime).ToString()), state);
            }
        }
        /// <summary>
        /// Forces the point pulse outside of its regular schedule. Invoking this does not reset the point pulse schedule, the next automated pulse will happen as scheduled.
        /// </summary>
        /// <param name="connID">Connection ID of the user requesting the point pulse</param>
        public static void ForcePointPulse(int connID)
        {
            Network.ClientConnection state = Network.ClientConnections.Single(c => c.ID == connID);

            Program.PointTimerCallback(state);
            Network.Send("Point tick forced.\n\r", state);
        }

        /// <summary>
        /// Retrieves one argument (either a single word or a quoted phrase) from <paramref name="input"/>
        /// </summary>
        /// <returns>The input string <paramref name="input"/> with the first argument remoed.</returns>
        /// <param name="input">Input string to parse</param>
        /// <param name="argument">The first argument of <paramref name="input"/></param>
        static string GetOneArgument(string input, out string argument)
        {
            char endCharacter = ' ';
            int pos = 0;
            argument = String.Empty;

            // Trim input
            input = input.Trim();

            // If the input string has no data, return and be done
            if (input.Length == 0)
                return String.Empty;
            
            // Reset endCharacter if the input starts with a quote
            if (input[0] == '\'' || input[0] == '"')
            {
                endCharacter = input[0];    // End on the matched quote
                pos++;                      // Move position ahead to 1 character
            }

            while (pos < input.Length)
            {
                if (input[pos] == endCharacter)
                    break;
                else
                    argument += input[pos].ToString();

                pos++;
            }

            // Remove what we cut off off input and return it
            return input.Remove(0, pos);
        }

        static string ShowCharToChar(Models.CharacterData character, Models.CharacterData victim)
        {
            int percent;
            StringBuilder sb = new StringBuilder();

            if (!String.IsNullOrWhiteSpace(victim.Description))
                sb.Append(String.Format("{0}\n\r", victim.Description));

            if (victim.MaxHealth > 0)
                percent = (100 * victim.Health) / victim.MaxHealth;
            else
                percent = -1;

            if (percent >= 100)
                sb.Append(String.Format("{0} is in excellent condition.\n\r", victim.Name));
            else if (percent >= 90)
                sb.Append(String.Format("{0} has a few scratches.\n\r", victim.Name));
            else if (percent >= 75)
                sb.Append(String.Format("{0} has some small wounds and bruises.\n\r", victim.Name));
            else if (percent >= 50)
                sb.Append(String.Format("{0} has quite a few wounds.\n\r", victim.Name));
            else if (percent >= 30)
                sb.Append(String.Format("{0} has some big nasty wounds and scratches.\n\r", victim.Name));
            else if (percent >= 15)
                sb.Append(String.Format("{0} looks pretty hurt.\n\r", victim.Name));
            else if (percent >= 0)
                sb.Append(String.Format("{0} is in awful condition.\n\r", victim.Name));
            else
                sb.Append(String.Format("{0} is bleeding to death.\n\r", victim.Name));

            sb.Append("\n\r");

            // Check if the victim has anything equipped
            if (!victim.Equipment.IsNaked)
            {
                sb.Append(String.Format("{0} is using:\n\r", victim.Name));

                for (int i = 0; i < Models.EquipSlots.MaxValue; i++)
                {
                    // List the equipment
                    if (victim.Equipment[i] != null)
                        sb.Append(String.Format("{0}{1}\n\r", Consts.Lookups.EquipSlotNames[(Enums.EquipSlot)i], victim.Equipment[i].FormatObjToChar(character, true)));
                }

                // Final line break
                sb.Append("\n\r");
            }

            // Peek at the inventory - TODO: Only do this when we're supposed to
            sb.Append("You peek at the inventory:\n\r");

            foreach(Models.ObjectData obj in victim.Inventory)
            {
                sb.Append(obj.FormatObjToChar(character, true) + "\n\r");
            }

            // This function ultimately needs to call Network.Send() itself, but we don't have a version
            //   that doesn't set up a new callback yet.
            return sb.ToString();
        }

		public static void DoGreeting(int connID)
		{
			// For now, get a ClientConnection since I haven't reworked everything to just use the ID yet
			Network.ClientConnection state = Network.ClientConnections.Single(c => c.ID == connID);

			// Update the client's state
			state.State = ROMSharp.Enums.ClientState.Login_WaitingForCharacterName;

			// Send the greeting text
			Network.Send(Consts.Strings.Greeting, state);
			//
			//				// Ensure we don't call BeginReceive() multiple times
			//				if (!state.IsWaitingForData) {
			//					// Flag that we're waiting for data
			//					state.IsWaitingForData = true;
			//
			//					// Wait for data
			//					handler.BeginReceive (state.buffer, 0, ClientConnection.BufferSize, 0, new AsyncCallback (ReadCallback), state);
			//				}
		}

        public static void SingleUser(int connID)
        {
            // For now, get a ClientConnection since I haven't reworked everything to just use the ID yet
            Network.ClientConnection state = Network.ClientConnections.Single(c => c.ID == connID);

            // Send the single user login text
            Network.Send("Connected to server running in single-user mode.\n\r", state);
        }
	}
}