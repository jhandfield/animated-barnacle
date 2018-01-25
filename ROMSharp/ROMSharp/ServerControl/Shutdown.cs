using System;
namespace ROMSharp
{
    public partial class ServerControl
    {
        public static void Shutdown()
        {
            // Log
            Logging.Log.Info("Shutdown request received, shutting down...");

            // TODO: Close connections, file handles, write player data to storage, etc.
            // Stop the main timer
            Program.pointTimer.Dispose();

            // Close the socket
            Program.listener.Close();

            // Shut down logging
            Logging.Log.Info("ROMSharp is shut down - goodbye.");
            Logging.Log.Logger.Repository.Shutdown();

            // Exit the application
            Environment.Exit(0);
        }
    }
}