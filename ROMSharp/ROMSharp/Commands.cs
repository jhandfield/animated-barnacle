using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ROMSharp
{
	/// <summary>
	/// Contains methods representing the possible commands to be invoked by users
	/// </summary>
	public class Commands
	{
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

        public static void DoGoto(int connID, string dest)
        {
            Network.ClientConnection state;
            state = Network.ClientConnections.Single(c => c.ID == connID);

            if (Int32.TryParse(dest, out int roomID) && Program.World.Rooms[roomID] != null)
            {
                state.PlayerCharacter.InRoom = Program.World.Rooms[roomID];
                Network.Send("Ok.\n\r\n\r", state);
            }
            else
                Network.Send("Syntax: goto [room VNUM]\n\r\n\r", state);
        }

        public static void DoLoad(int connID, string[] args)
        {
            Network.ClientConnection state;
            state = Network.ClientConnections.Single(c => c.ID == connID);

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

        public static void DoInventory(int connID)
        {
            Network.ClientConnection state;

            // Get the client state
            state = Network.ClientConnections.Single(c => c.ID == connID);

            StringBuilder sb = new StringBuilder();
            sb.Append("You are carrying:\n\r");

            if (state.PlayerCharacter.Inventory.Count == 0)
            {
                sb.Append("Nothing.\n\r");
            }
            else
            {
                foreach(Models.ObjectData obj in state.PlayerCharacter.Inventory)
                {
                    sb.Append(obj.ShortDescription + "\n\r");
                }
            }

            // Send output
            Network.Send(sb.ToString() + "\n\r", state);
        }

        /// <summary>
        /// Describes the room, its contents, and the people in it to the player. Not fully implemented.
        /// </summary>
        /// <param name="connID">Conn identifier.</param>
        public static void DoLook(int connID, string[] args)
        {
            string arguments = String.Empty;
            string arg1, arg2;

            // Recombine args
            List<string> argList = args.ToList();
            argList.RemoveAt(0);
            arguments = String.Join(" ", argList);

            // Pull arguments
            arguments = GetOneArgument(arguments, out arg1);
            arguments = GetOneArgument(arguments, out arg2);

            Network.ClientConnection state;
            Models.PlayerCharacterData character;
            Models.CharacterData victim;
            Models.RoomIndexData room;

            // Get the client state
            state = Network.ClientConnections.Single(c => c.ID == connID);

            // Get the client character
            character = state.PlayerCharacter;

            // Get the character's current room
            room = character.InRoom;

            // Attempt to pull a character from the first argument
            victim = room.Characters.SingleOrDefault(c => c.Name.ToLower().Equals(arg1));

            if (victim != null)
            {
                string output = ShowCharToChar(character, victim);
                Network.Send(output + "\n\r", state);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(String.Format("{0}\n\r\n\r{1}\n\r\n\r", room.Name, room.Description));

                foreach (Models.ObjectData obj in room.Objects)
                    sb.Append("\t" + obj.Description + "\n\r");

                foreach (Models.CharacterData person in room.Characters)
                    sb.Append(person.LongDescription + "\n\r");

                Network.Send(sb.ToString() + "\n\r", state);
            }


        }

        public static void DoSpawn(int mobID, int roomID, int connID)
        {
            Network.ClientConnection state = Network.ClientConnections.Single(c => c.ID == connID);
            Models.PlayerCharacterData character = state.PlayerCharacter;
            Models.RoomIndexData room = Program.World.Rooms[roomID];

            // Check that the mob is valid
            Models.MobPrototypeData mobProto = Program.World.Mobs.SingleOrDefault(m => m.VNUM.Equals(mobID));

            if (mobProto != null)
            {
                // Instantiate a new mob
                Models.CharacterData newMob = new Models.CharacterData(mobProto);

                // Place the mob into the room
                room.Characters.Add(newMob);

                Network.Send("OK.", state);
            }
            else
                Network.Send("Invalid mob VNUM " + mobID, state);

        }

		/// <summary>
		/// Requests the current server time be sent to the client
		/// </summary>
		/// <param name="connID">Connection ID of the user invoking the command.</param>
		public static void WhatTimeIsIt(int connID)
		{
			// For now, get a ClientConnection since I haven't reworked everything to just use the ID yet
			Network.ClientConnection state = Network.ClientConnections.Single(c => c.ID == connID);

			Network.Send(String.Format ("The current server time is {0}\n\r", DateTime.Now.ToString ()), state);
		}

		/// <summary>
		/// Tells the user we don't know what they're asking us to do
		/// </summary>
		/// <param name="connID">Connection ID of the requesting user</param>
		public static void UnknownCommand(int connID, string command)
		{
			// For now, get a ClientConnection since I haven't reworked everything to just use the ID yet
			Network.ClientConnection state = Network.ClientConnections.Single(c => c.ID == connID);

			Network.Send ("Sorry, I don't know what you're asking - " + command + "\n\r", state);
		}

		/// <summary>
		/// Sends a list of open connections to the user
		/// </summary>
		/// <param name="connID">Connection ID of the requesting user</param>
		public static void ListConnections(int connID)
		{
			// For now, get a ClientConnection since I haven't reworked everything to just use the ID yet
			Network.ClientConnection state = Network.ClientConnections.Single(c => c.ID == connID);

			// Header
			string result = "ACTIVE CONNECTIONS\n\rID     Remote IP         Duration   Tx/Rx\n\r";
			//2345	  123.123.123.132   00:00:00   1024.1MB/1024.1MB   

			// Data
			foreach (Network.ClientConnection conn in Network.ClientConnections) {
				result += String.Format ("{0,-7}{1,-18}{2,-11}{3}/{4}\n\r",
					conn.ID.ToString (),
					conn.RemoteIP.ToString (),
					conn.ConnectionDuration.ToString (@"hh\:mm\:ss"),
					conn.bytesSent,
					conn.bytesReceived);
			}

			// Send the result
			Network.Send(result, state);
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
            Network.Send("Connected to server running in single-user mode.\n", state);
        }

        public static void DoServerStats(int connID)
        {
            // For now, get a ClientConnection since I haven't reworked everything to just use the ID yet
            Network.ClientConnection state = Network.ClientConnections.Single(c => c.ID == connID);

            // Send statistics
            Network.Send(String.Format("SERVER STATISTICS\n=================\n{0} rooms loaded\n{1} mobiles loaded\n{2} object prototypes loaded\n{3} connections currently open\nServer uptime is {4}\n\n",
                Program.World.Rooms.Count,
                Program.World.Mobs.Count,
                Program.World.Objects.Count,
                Network.ClientConnections.Count,
                                       (DateTime.Now - Program.World.StartupTime).ToString()), state);
            
        }

        /// <summary>
        /// Returns information about a given room VNUM
        /// </summary>
        public static void DoStatRoom(int connID, int vnum)
        {
            // For now, get a ClientConnection since I haven't reworked everything to just use the ID yet
            Network.ClientConnection state = Network.ClientConnections.Single(c => c.ID == connID);

            // Attempt to find the room
            Models.RoomIndexData targetRoom = Program.World.Rooms.SingleOrDefault(r => r.VNUM.Equals(vnum));

            // Did we find it?
            if (targetRoom == null)
            {
                // Inform the user
                Network.Send("No such location\n\n", state);
            }
            else
            {
                string output = String.Empty;
                output += String.Format("Name: '{0}'\nArea: '{1}'\n", targetRoom.Name, Program.World.Areas.Single(a => a.MinVNum <= targetRoom.VNUM && a.MaxVNum >= targetRoom.VNUM).Name);
                output += String.Format("VNUM: {0}  Sector: {1}  Light: {2}  Healing: {3}  Mana: {4}\n",
                                        targetRoom.VNUM,
                                        targetRoom.SectorType.ToString(),
                                        targetRoom.LightLevel,
                                        targetRoom.HealRate.ToString(),
                                        targetRoom.ManaRate.ToString());
                output += String.Format("Room Flags: {0}\n", ((Enums.AlphaMacros)targetRoom.Attributes).ToString().Replace(",","").Replace(" ",""));
                output += String.Format("Description:\n{0}\n", targetRoom.Description);
                output += "Extra description keywords: " + String.Join(",", targetRoom.ExtraDescriptions.Select(ed => ed.Keywords)) + "\n";

                // TODO: Should check that the character can be seen by the person invoking this command
                output += "Characters: " + String.Join(",", targetRoom.Characters.Select(person => person.Name)) + "\n";
                output += "Objects: " + String.Join(",", targetRoom.Objects.Select(obj => obj.Name)) + "\n";

                // Loop over possible exits
                for (int i = 0; i <= 5; i++)
                {
                    // Check that the exit is defined
                    if (targetRoom.Exits[i] != null)
                        // Add to output
                        output += String.Format("Door: {0}.  To: {1}.  Key: {2}.  Exit flags: {3}.\nKeyword: '{4}'.  Description: {5}\n",
                                                i,
                                                targetRoom.Exits[i].ToVNUM,
                                                targetRoom.Exits[i].KeyVNUM,
                                                ((Enums.AlphaMacros)targetRoom.Exits[i].Attributes).ToString(),
                                                targetRoom.Exits[i].Keywords,
                                                targetRoom.Exits[i].Description);
                }

                output += "\n";

                // Send output to the user
                Network.Send(output, state);
            }
        }
	}
}