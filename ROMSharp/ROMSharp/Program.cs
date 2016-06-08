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
		public static Timer pointTimer;

        public static int Main(string[] args)
        {
            // Configure the Console.CancelKeyPress event
            Console.CancelKeyPress += Console_CancelKeyPress;

			// Start the server
			Startup(args);

            // Return success
            return 0;
        }

		public static void PointTimerCallback(object stateInfo)
		{
			Console.WriteLine ("PointTimerCallback() called");

			// Loop over all connections
			foreach (Network.ClientConnection connection in Network.ClientConnections) {
				Console.WriteLine ("Processing character on connection ID " + connection.ID);

				// Send a message to them
				Network.Send("Tick!\n\r", connection);
			}
		}

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            // Call Shutdown()
            Shutdown();
        }

		public static void Startup(string[] args)
		{
			Console.WriteLine ("Server startup beginning...");

			// Instantiate a new ServerConfiguration - this may be modified prior to starting the server
			ServerConfiguration config = new ServerConfiguration();

			// Parse any command-line arguments
			if (!ServerConfiguration.ParseArguments(args, out config))
				Console.WriteLine("Fatal error parsing config parameters, server startup aborted.");

			// Instantiate our ClientConnections object which will contain all active connections
			Network.ClientConnections = new List<Network.ClientConnection>();

			// Set up Pulses
			TimerCallback pointTimerCallback = PointTimerCallback;
			pointTimer = new Timer (pointTimerCallback, null, Consts.Time.PointPulseInterval, Consts.Time.PointPulseInterval	);

			Console.WriteLine ("Server setup complete, starting server...");

			// Listen for connections
			Network.StartListening(config);
		}

        public static void Shutdown()
        {
            Console.WriteLine("Shutdown request received, shutting down...");
            Environment.Exit(0);
        }
    }
}