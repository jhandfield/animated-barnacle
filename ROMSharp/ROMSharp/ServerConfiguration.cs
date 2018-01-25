using System;
using System.Collections.Generic;
using System.Net;

namespace ROMSharp
{
    /// <summary>
    /// Defines the server's configuration
    /// </summary>
    public class ServerConfiguration
    {
        #region Properties
        /// <summary>
        /// IP address to listen for connections on (default: all)
        /// </summary>
        public IPAddress listenAddress { get; set; }

        /// <summary>
        /// TCP port to listen for connections on (default: 9000)
        /// </summary>
        public int listenPort { get; set; }

        /// <summary>
        /// Maximum number of simultaneous connections (default: 20)
        /// </summary>
        public int maxConnections { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Instantiates a ServerConfiguration() object with default values
        /// </summary>
        public ServerConfiguration()
        {
            this.listenAddress = IPAddress.Any;
            this.listenPort = 9000;
            this.maxConnections = 20;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Parses command-line parameters into a ServerConfiguration object
        /// </summary>
        /// <param name="args">String array of keys and values to parse</param>
        /// <returns>ServerConfiguration object with any overrides applied to the default values</returns>
        public static ServerConfiguration ParseArguments(string[] args)
        {
            // Declare a ServerConfiguration to hold the configuration
            ServerConfiguration tempConfig = new ServerConfiguration();

            // Declare a Dictionary<> to hold parsed arguments
            Dictionary<string, string> parsedArgs = new Dictionary<string, string>();

            // Convert the string array to the Dictionary<>
            for (int i = 0; i < args.Length; i += 2)
                parsedArgs.Add(args[i].ToLower(), args[i + 1].ToLower());

            #region Assign config params
            // -address (override address to listen on)
            if (parsedArgs.ContainsKey("-address"))
            {
                // Variable to hold the parsed address, if it succeeds
                IPAddress parsedAddr;

                // Attempt to parse the input
                if (IPAddress.TryParse(parsedArgs["-address"], out parsedAddr))
                    tempConfig.listenAddress = parsedAddr;
                else
                    Logging.Log.Warn(String.Format("Skipping invalid value {0} for parameter {1}", parsedArgs["-address"], "-address"));
            }

            // -port (override TCP port to listen on)
            if (parsedArgs.ContainsKey("-port"))
            {
                int parsedPort;

                if (Int32.TryParse(parsedArgs["-port"], out parsedPort))
                    tempConfig.listenPort = parsedPort;
                else
                    Logging.Log.Warn(String.Format("Skipping invalid value {0} for parameter {1}", parsedArgs["-port"], "-port"));
            }

            // -maxConnections (override maximum allowed connections)
            if (parsedArgs.ContainsKey("-maxconnections"))
            {
                int parsedMaxConn;

                if (Int32.TryParse(parsedArgs["-maxconnections"], out parsedMaxConn))
                    tempConfig.maxConnections = parsedMaxConn;
                else
                        Logging.Log.Warn(String.Format("Skipping invalid value {0} for parameter {1}", parsedArgs["-maxconnections"], "-maxConnections"));
            }
            #endregion

            // Return the configuration
            return tempConfig;
        }
        #endregion
    }
}
