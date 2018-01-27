using System;
using System.Net.Sockets;
using System.Threading;

namespace ROMSharp
{
    public class Program
    {
        /// <summary>
        /// The master timer for the game - triggers periodic updates (ticks)
        /// </summary>
		public static Timer pointTimer;

        /// <summary>
        /// The overall server configuration
        /// </summary>
        public static ServerConfiguration config;

        public static Socket listener;

        // Instantiate the World
        public static World World = new World();

        public static int Main(string[] args)
        {
            // Notify that the logger is running
            Logging.Log.Info("Logger initialized");

            // Instantiate the server configuration
            config = new ServerConfiguration();

            // Configure the Console.CancelKeyPress event
            Console.CancelKeyPress += Console_CancelKeyPress;

			// Begin server startup
            ServerControl.Boot(args);

            while (true) { }

            // Return success
            return 0;
        }

		public static void PointTimerCallback(object stateInfo)
		{
            Logging.Log.Debug("PointTimerCallback() called");

			// Loop over all connections
			foreach (Network.ClientConnection connection in Network.ClientConnections) {
                Logging.Log.Debug("Processing character on connection ID " + connection.ID);

				// Send a message to them
				Network.Send("Tick!\n\r", connection);
			}
		}

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            // Call Shutdown()
            ServerControl.Shutdown();
        }
    }
}