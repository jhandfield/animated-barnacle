using System;
using System.Linq;

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
			Network.ClientConnection state = Network.ClientConnections.Single (c => c.ID == connID);

			Program.PointTimerCallback (state);
			Network.Send ("Point tick forced.\n\r", state);
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