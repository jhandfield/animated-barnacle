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

            ServerConfiguration config = new ServerConfiguration();

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

		public static void ParseCommand(string commandString, Network.StateObject state)
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
			}
		}

		public class Commands {
			public static void WhatTimeIsIt(Network.StateObject state)
			{
				Network.Send(String.Format ("The current server time is {0}", DateTime.Now.ToString ()), state);
			}
		}
    }
}
