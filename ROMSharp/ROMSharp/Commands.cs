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
	}
}