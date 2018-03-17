using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ROMSharp
{
    public class World
    {
        #region Fields
        private Enums.GameState _state;
        #endregion

        #region Properties
        public Enums.GameState State
        {
            get { return _state; }
            set
            {
                // Fire OnStatechanging() event
                OnStateChanging(_state, value);

                // Set value
                _state = value;
            }
        }

        /// <summary>
        /// Collection of areas that make up the world
        /// </summary>
        /// <value>The areas.</value>
        public List<Models.AreaData> Areas { get; set; }

        /// <summary>
        /// Collection of rooms that make up the areas of the world
        /// </summary>
        public Models.Rooms Rooms { get; set; }

        /// <summary>
        /// Collection of mobiles that make up the fauna of the world
        /// </summary>
        public Models.Mobs Mobs { get; set; }

        /// <summary>
        /// Collection of objects that make up the flora of the world
        /// </summary>
        public Models.Objects Objects { get; set; }
        #endregion

        #region Constructors
        public World()
        {
            this.Areas = new List<Models.AreaData>();
            this.State = Enums.GameState.Loading;
            this.Rooms = new Models.Rooms();
            this.Mobs = new Models.Mobs();
            this.Objects = new Models.Objects();
        }
        #endregion

        #region Methods
        private void OnStateChanging(Enums.GameState oldState, Enums.GameState newState)
        {
            Logging.Log.Debug(String.Format("Game state changing from {0} to {1}", oldState, newState));

            switch(newState){
                case Enums.GameState.Loading:
                    // Instantiate the server configuration
                    Program.config = new ServerConfiguration();

                    // Set the server configuration from any command line arguments
                    Program.config = ServerConfiguration.ParseArguments(Program.commandArgs);

                    // Logging
                    Logging.Log.Info("Server configuration loaded");

                    break;
                case Enums.GameState.Starting:
                    Logging.Log.Info("Server starting up");
                    Logging.Log.Info(String.Format("Server memory usage: {0:N0}KiB", GC.GetTotalMemory(true) / 1024));

                    //try
                    //{
                        // Instantiate our ClientConnections object which will contain all active connections
                        Network.ClientConnections = new List<Network.ClientConnection>();

                        // Instantiate and load the World
                        Program.World.LoadFromDisk(Program.config.AreaDirectory);

                    Logging.Log.Info(String.Format("World loaded - {0} areas consisting of {1} rooms, with {2} mobs", Program.World.Areas.Count, Program.World.Rooms.Count, Program.World.Mobs.Count));

                    //}
                    //catch (Exception e)
                    //{
                    //    Logging.Log.Fatal(String.Format("Unhandled exception caught: {0}: {1}\n{2}", e.GetType(), e.Message, e.StackTrace));
                    //}

                    // Listen for connections
                    Network.StartListening(Program.config);

                    // Log
                    Logging.Log.Info("Server startup complete, starting simulation");
                    Logging.Log.Info(String.Format("Server memory usage: {0:N0}KiB", GC.GetTotalMemory(true) / 1024));

                    break;
                case Enums.GameState.Stopping:
                    // Loop over active connections and close each
                    foreach(Network.ClientConnection conn in Network.ClientConnections)
                    {
                        // TODO: Save the character first
                        // TODO: Disconnect the character in a cleaner method than this
                        Logging.Log.Info(String.Format("Closing connection {0} for character {1}", conn.ID, conn.PlayerCharacter.Name));
                        conn.workSocket.Close();
                    }

                    // Stop the main timer
                    Program.pointTimer.Dispose();

                    // Close the litening socket
                    Program.listener.Close();

                    // Shut down logging
                    Logging.Log.Info("ROMSharp is shut down - goodbye.");
                    Logging.Log.Logger.Repository.Shutdown();

                    // Exit the application
                    Environment.Exit(0);

                    break;
            }

            Logging.Log.Info(String.Format("Game state is now {0}", newState));
        }

        /// <summary>
        /// Instantiate the World from area files stored on disk
        /// </summary>
        /// <param name="areaPath">Path to the area folder</param>
        public void LoadFromDisk(string areaPath) {
            // Validate that the path exists
            if (!Directory.Exists(areaPath))
            {
                // Log a fatal error and exit
                Logging.Log.Fatal(String.Format("Unable to load area files - direcory does not exist: {0}", areaPath));
                Environment.Exit(1);
            }
            else
                Logging.Log.Debug(String.Format("Area directory {0} located", areaPath));

            // Build the path to the area.lst file
            string areaListPath = Path.Combine(areaPath, "area.lst");

            // Check for the existence of the area.lst file in the area folder
            if (!File.Exists(areaListPath))
            {
                // Log a fatal error and exit
                Logging.Log.Fatal(String.Format("Unable to find area.lst file in expected location: {0}", areaListPath));
                Environment.Exit(1);
            }
            else
                Logging.Log.Debug(String.Format("Area list file {0} located", areaListPath));

            // Load the area list
            string[] areaFileList = File.ReadAllLines(areaListPath);
            Logging.Log.Debug(String.Format("Area list file {0} loaded: {1} areas in list.", areaListPath, areaFileList.Length));

            // Loop over the area file list
            foreach (string areaFile in areaFileList)
            {
                // Skip the EOF line
                if (!areaFile.Equals("$"))
                {
                    // Load the area
                    Logging.Log.Debug(String.Format("Loading area file {0}", areaFile));
                    Models.AreaData newArea = Models.AreaData.LoadFromFile(Path.Combine(Program.config.AreaDirectory,areaFile));

                    // Check that we successfully loaded the area
                    if (newArea != null)
                    {
                        // Log
                        Logging.Log.Info(String.Format("Area {0} loaded", newArea.Name));

                        // Append to the world
                        this.Areas.Add(newArea);
                    }
                }
            }
        }

        /// <summary>
        /// Starts the simulation - enables ticks, mob autonomy, etc.
        /// </summary>
        public void StartSimulation()
        {
            // Set up Pulses
            TimerCallback pointTimerCallback = Program.PointTimerCallback;
            Program.pointTimer = new Timer(pointTimerCallback, null, Consts.Time.PointPulseInterval, Consts.Time.PointPulseInterval);

            // Set world state to running
            Program.World.State = Enums.GameState.Running;

            // Log
            Logging.Log.Info("Simulation started");
        }

        /// <summary>
        /// Pauses the simulation - disables ticks, mob autonomy, etc.
        /// </summary>
        public void PauseSimulation()
        {
            // Disable pulses
            Program.pointTimer.Dispose();

            // Update the world state
            State = Enums.GameState.Paused;

            // Log
            Logging.Log.Info("Simulation paused");
        }
        #endregion
    }
}
