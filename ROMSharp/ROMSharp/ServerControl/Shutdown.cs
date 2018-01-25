using System;
namespace ROMSharp
{
    public partial class ServerControl
    {
        public static void Shutdown()
        {
            Console.WriteLine("Shutdown request received, shutting down...");
            Environment.Exit(0);
        }
    }
}
