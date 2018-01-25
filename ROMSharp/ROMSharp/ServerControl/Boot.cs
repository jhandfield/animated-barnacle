using System;
using System.Collections.Generic;
using System.Threading;

namespace ROMSharp
{
    public partial class ServerControl
    {
        public static void Boot(string[] args)
        {
            Console.WriteLine("Server startup beginning...");

            try
            {
                // Set the server configuration from any command line arguments
                Program.config = ServerConfiguration.ParseArguments(args);

                Console.WriteLine("Fatal error parsing config parameters, server startup aborted.");

                // Instantiate our ClientConnections object which will contain all active connections
                Network.ClientConnections = new List<Network.ClientConnection>();

                // Set up Pulses
                TimerCallback pointTimerCallback = Program.PointTimerCallback;
                Program.pointTimer = new Timer(pointTimerCallback, null, Consts.Time.PointPulseInterval, Consts.Time.PointPulseInterval);
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Unhandled exception caught: {0}: {1}\n{2}", e.GetType(), e.Message, e.StackTrace));
            }

            Console.WriteLine("Server setup complete, starting server...");

            // Listen for connections
            Network.StartListening(Program.config);
        }
    }
}
