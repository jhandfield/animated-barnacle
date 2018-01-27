using System;
namespace ROMSharp
{
    public partial class ServerControl
    {
        public static void Shutdown()
        {
            // Log
            Logging.Log.Info("Shutdown request received, shutting down...");

            // Set world state to Stopping
            Program.World.State = Enums.GameState.Stopping;
        }
    }
}