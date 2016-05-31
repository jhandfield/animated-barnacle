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
    }
}
