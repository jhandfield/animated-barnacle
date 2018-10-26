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

        /// <summary>
        /// The server socket through which players will connect and communicate
        /// </summary>
        public static Socket listener;

        /// <summary>
        /// Represents the game World
        /// </summary>
        public static World World;

        /// <summary>
        /// The command line arguments from server startup
        /// </summary>
        public static string[] commandArgs;

        /// <summary>
        /// Random number generator available to everything
        /// </summary>
        public static System.Random randGen;

        public static int Main(string[] args)
        {
            // Configure the Console.CancelKeyPress event
            Console.CancelKeyPress += Console_CancelKeyPress;

            // Notify that the logger is running
            Logging.Log.Info("Logger initialized");

            // Copy arguments to the global
            commandArgs = args;

            // Instantiate the World object
            Program.World = new World();

            // Advance the World state to Starting
            Program.World.State = Enums.GameState.Starting;

            // Start the simulation
            Program.World.StartSimulation();

            // Main blocking loop
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