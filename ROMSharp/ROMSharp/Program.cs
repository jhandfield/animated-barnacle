using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ROMSharp
{
    public class Program
    { 
        public static int Main(string[] args)
        {
            // Configure the Console.CancelKeyPress event
            Console.CancelKeyPress += Console_CancelKeyPress;

			// Instantiate a new ServerConfiguration - this may be modified prior to starting the server
            ServerConfiguration config = new ServerConfiguration();

			// Instantiate our ClientConnections object which will contain all active connections
			Network.ClientConnections = new List<Network.ClientConnection>();

            // Parse any command-line arguments
            if (!ServerConfiguration.ParseArguments(args, out config))
                Console.WriteLine("Fatal error parsing config parameters, server startup aborted.");

            // Listen for connections
            Network.StartListening(config);

            // Return success
            return 0;
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            // Call Shutdown()
            Shutdown();
        }

        public static void Shutdown()
        {
            Console.WriteLine("Shutdown request received, shutting down...");
            Environment.Exit(0);
        }

		public static void ParseCommand(string commandString, Network.ClientConnection state)
		{
			// If we have no data, there's nothing to do
			if (String.IsNullOrWhiteSpace (commandString))
				return;
			
			// Split commandString for easier handling
			string[] commandArr = commandString.Split(' ');

			// The first word of a user input is the command - isolate it
			string command = commandArr[0].ToLower();

			// Act on the command
			switch (command) 
			{
				// Shut down the server
				case "shutdown":
					Shutdown ();
					break;

				// Disconnect the client
				case "exit":
					Network.EndSession (state);
					break;

				// Request the current time
				case "whattimeisit":
					Commands.WhatTimeIsIt (state);
					break;

				// Request a list of current connections
				case "listconnections":
					Commands.ListConnections (state.ID);
					break;

				// Repeats the last command
				case "!":
					ParseCommand (state.LastCommand, state);
					break;
			}

			// Store the active command as the client's last command, if it wasn't !
			if (!command.Equals("!"))
				state.LastCommand = command;
		}

		public class Commands {
			public static void WhatTimeIsIt(Network.ClientConnection state)
			{
				Network.Send(String.Format ("The current server time is {0}", DateTime.Now.ToString ()), state);
			}

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
		}
    }
}
