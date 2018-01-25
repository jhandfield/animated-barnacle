using System;
using System.Collections.Generic;
using System.Threading;
using ROMSharp.Consts;
using log4net;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace ROMSharp
{
    public class Program
    {
        /// <summary>
        /// The current state of the game
        /// </summary>
        public static GameState GameMode;

        /// <summary>
        /// The master timer for the game - triggers periodic updates (ticks)
        /// </summary>
		public static Timer pointTimer;

        /// <summary>
        /// The overall server configuration
        /// </summary>
        public static ServerConfiguration config;

        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static int Main(string[] args)
        {
            // Notify that the logger is running
            log.Info("Logger initialized");

            // Set game state to Starting
            GameMode = GameState.Starting;

            // Instantiate the server configuration
            config = new ServerConfiguration();

            // Configure the Console.CancelKeyPress event
            Console.CancelKeyPress += Console_CancelKeyPress;

			// Begin server startup
            ServerControl.Boot(args);

            // Return success
            return 0;
        }

		public static void PointTimerCallback(object stateInfo)
		{
            log.Debug("PointTimerCallback() called");

			// Loop over all connections
			foreach (Network.ClientConnection connection in Network.ClientConnections) {
                log.Debug("Processing character on connection ID " + connection.ID);

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