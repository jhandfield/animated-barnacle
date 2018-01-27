using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace ROMSharp
{
    public partial class ServerControl
    {
        public static void Boot(string[] args)
        {
            Logging.Log.Info("Server startup beginning");

            try
            {
                // Set the server configuration from any command line arguments
                Program.config = ServerConfiguration.ParseArguments(args);

                // Logging
                Logging.Log.Info("Server configuration loaded");
                
                // Instantiate our ClientConnections object which will contain all active connections
                Network.ClientConnections = new List<Network.ClientConnection>();

                // Instantiate the World
                Program.World.LoadFromDisk(Program.config.AreaDirectory);

                Logging.Log.Info(String.Format("World loaded - {0} areas consisting of {1} rooms", Program.World.Areas.Count, 0));
            }
            catch (Exception e)
            {
                Logging.Log.Error(String.Format("Unhandled exception caught: {0}: {1}\n{2}", e.GetType(), e.Message, e.StackTrace));
            }

            // Log
            Logging.Log.Info("Server setup complete, starting server...");

            // Set state to Starting
            Program.World.State = Enums.GameState.Starting;

            // Listen for connections
            Network.StartListening(Program.config);

            // Start simulation
            Program.World.StartSimulation();
        }
    }
}
