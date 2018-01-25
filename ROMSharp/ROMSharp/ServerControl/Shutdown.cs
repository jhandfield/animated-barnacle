using System;
namespace ROMSharp
{
    public partial class ServerControl
    {
        public static void Shutdown()
        {
            // Log
            Program.log.Info("Shutdown request received, shutting down...");

            // TODO: Close connections, file handles, write player data to storage, etc.

            // Shut down logging
            Program.log.Info("ROMSharp is shut down - goodbye.");
            Program.log.Logger.Repository.Shutdown();

            // Exit the application
            Environment.Exit(0);
        }
    }
}
