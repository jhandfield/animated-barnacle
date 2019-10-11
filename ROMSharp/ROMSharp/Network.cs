using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using static ROMSharp.Consts.GameParameters;
using ROMSharp.Interfaces;

namespace ROMSharp
{
    public class Network
    {
		public static List<ClientConnection> ClientConnections;

        // State object for reading client data asynchronously
        public class ClientConnection
        {
            // Client  socket.
            public Socket workSocket = null;
            // Size of receive buffer.
            public const int BufferSize = 1024;
            // Receive buffer.
            public byte[] buffer = new byte[BufferSize];
            // Received data string.
            public StringBuilder sb = new StringBuilder();
            // Buffer for the user's input string
            public string stringBuffer;
            // Data sent count
            public UInt64 bytesSent = 0;
            // Data received count
            public UInt64 bytesReceived = 0;

			#region Properties
            /// <summary>
            /// Returns the unique identifier for the connection
            /// </summary>
            public Int32 ID
            {
                get
                {
                    if (workSocket != null)
                        return workSocket.Handle.ToInt32();
                    else
                        return -1;
                }
            }

			/// <summary>
			/// Stores the date/time at which the client connected
			/// </summary>
			public DateTime ConnectedAt { get; }

			/// <summary>
			/// Returns the remote IP address of the client
			/// </summary>
			public IPAddress RemoteIP { get { return ((IPEndPoint)this.workSocket.RemoteEndPoint).Address; } }

			/// <summary>
			/// Returns the duration for which the client's session has existed
			/// </summary>
			/// <value>The duration of the connection.</value>
			public TimeSpan ConnectionDuration { get { return (TimeSpan)(DateTime.Now - this.ConnectedAt); } }

			/// <summary>
			/// Returns the text of the last command sent from the client
			/// </summary>
			public ICommand LastCommand { get; set; }

			/// <summary>
			/// Indicates whether we're waiting for data
			/// </summary>
			/// <value><c>true</c> if this instance is waiting for data; otherwise, <c>false</c>.</value>
			public bool IsWaitingForData { get; set; }

			/// <summary>
			/// Indicates what the client is currently doing; used to give context to various inputs from the client.
			/// </summary>
			/// <value>The state.</value>
			public Enums.ClientState State { get; set; }

            /// <summary>
            /// Holds the PlayerCharacter object
            /// </summary>
            public Models.PlayerCharacterData PlayerCharacter { get; set; }

            /// <summary>
            /// Temporary storage for password during character creation - is erased on the first read
            /// </summary>
            public string TempPass
            {
                get
                {
                    string output = _tempPass;
                    _tempPass = null;
                    return output;
                }
                set
                {
                    _tempPass = value;
                }
            }
            #endregion

            #region Fields
            private string _tempPass;
            #endregion

            #region Constructors
            public ClientConnection() {
				// Record the connected time of the client
				this.ConnectedAt = DateTime.Now;

				// Set the default client state
				this.State = ROMSharp.Enums.ClientState.Idle;

				// Set TCP Keepalive properties
				ConfigureSocketKeepalive(this.workSocket);

                PlayerCharacter = new Models.PlayerCharacterData();
                PlayerCharacter.Name = "Seath";
                PlayerCharacter.InRoom = Program.World.Rooms[3001];
                PlayerCharacter.Level = Maximums.Level;
                PlayerCharacter.Trust = Maximums.Level;
                PlayerCharacter.Descriptor = this;
			}
			#endregion

			#region Helper Methods
			private void ConfigureSocketKeepalive(Socket socket)
			{
				int size = sizeof(UInt32);
				UInt32 on = 1;
				UInt32 keepAliveInterval = 10000; //Send a packet once every 10 seconds.
				UInt32 retryInterval = 1000; //If no response, resend every second.
				byte[] inArray = new byte[size * 3];
				Array.Copy(BitConverter.GetBytes(on), 0, inArray, 0, size);
				Array.Copy(BitConverter.GetBytes(keepAliveInterval), 0, inArray, size, size);
				Array.Copy(BitConverter.GetBytes(retryInterval), 0, inArray, size * 2, size);
			}
			#endregion
        }

        public static ManualResetEvent allDone = new ManualResetEvent(false);

        /// <summary>
        /// Opens the server socket listening on the default address and port
        /// </summary>
        public static void StartListening()
        {
            // Instantiate a new ServerConfiguration, pull the default address and port from there
            ServerConfiguration config = new ServerConfiguration();

            StartListening(config.listenAddress, config.listenPort);
        }

        /// <summary>
        /// Opens the server socket listening on the specified address and port
        /// </summary>
        /// <param name="config">Server configuration from which to pull an address and port to listen on</param>
        public static void StartListening(ServerConfiguration config)
        {
            StartListening(config.listenAddress, config.listenPort);
        }

        /// <summary>
        /// Opens the server socket listening on the specified address and port
        /// </summary>
        /// <param name="addr">Address to listen for connections on</param>
        /// <param name="port">Port to listen for connections on</param>
        public static void StartListening(IPAddress addr, int port)
        {
            // Establish the local endpoint for the socket.
            // The DNS name of the computer
            // running the listener is "host.contoso.com".
            IPEndPoint localEndPoint = new IPEndPoint(addr, port);

            // Create a TCP/IP socket.
            Program.listener = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and listen for incoming connections.
            try
            {
                Program.listener.Bind(localEndPoint);
                Program.listener.Listen(100);

                // Start an asynchronous socket to listen for connections.
                Logging.Log.Info(String.Format("Waiting for a connection on address {0} port {1}...", ((IPEndPoint)Program.listener.LocalEndPoint).Address, port));

                Program.listener.BeginAccept(new AsyncCallback(AcceptCallback), Program.listener);
            }
            catch (Exception e)
            {
                Logging.Log.Error(e.ToString());
            }
        }

		private void CheckSocketTimeout(Object state)
		{
			// Loop over each socket
		}

        public static void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                // Signal the main thread to continue.
                //allDone.Set();

                // Get the socket that handles the client request.
                Socket listener = (Socket)ar.AsyncState;
                Socket handler = listener.EndAccept(ar);

                // Create the state object.
                ClientConnection state = new ClientConnection();
                state.workSocket = handler;

                // Add the state object to ClientConnections
                ClientConnections.Add(state);

                // Log the connection
                Logging.Log.Info(String.Format("[{0}]: Incoming connection with {1} on local port {2}", state.ID, IPAddress.Parse(((IPEndPoint)handler.RemoteEndPoint).Address.ToString()), ((IPEndPoint)handler.RemoteEndPoint).Port));

                // Reset the socket for the next user
                Program.listener.BeginAccept(new AsyncCallback(AcceptCallback), Program.listener);

                // Call the greeting method
                Commands.SingleUser(state.ID);
                //Commands.DoGreeting(state.ID);
            }
            catch (ObjectDisposedException)
            {
                Logging.Log.Warn("Handling attempt to access disposed socket");
            }
        }

        // TODO: Implement EC / backspace characters
        // TODO: Implement required telnet commands
        public static void ReadCallback(IAsyncResult ar)
        {
			String content = String.Empty;

            // Retrieve the state object and the handler socket from the asynchronous state object.
            ClientConnection state = (ClientConnection)ar.AsyncState;
            Socket handler = state.workSocket;

            // Read data from the client socket. 
			try {
				// Flag that we're no longer waiting for data
				state.IsWaitingForData = false;

				// Record how many bytes we've received
	            int bytesRead = handler.EndReceive(ar);

				// Check that we've read some data
	            if (bytesRead > 0)
	            {
	                // Increment the state's received count
	                state.bytesReceived += (UInt64)bytesRead;

                    // Clients may be sending commands in their stream, so progress byte-by-byte
                    char[] bufChars = Encoding.ASCII.GetChars(state.buffer, 0, bytesRead);

                    // Work through the character buffer
                    foreach(char bufChar in bufChars)
                    {
                        // Handle backspace
                        if ((int)bufChar == '\b')
                            state.stringBuffer = state.stringBuffer.Remove(state.stringBuffer.Length - 1);
                        // Otherwise, add to the string buffer
                        else
                            state.stringBuffer += bufChar;
                    }
                    
                    // Read the stringBuffer
                    content = state.stringBuffer;

					// Check for a null character at the end of the buffer; if we don't have it, continue reading until we've gotten the whole message
					if (content.IndexOf('\n') > -1 && content.IndexOf('\r') > -1)
	                {
						state.buffer = new byte[ClientConnection.BufferSize];
                        state.stringBuffer = String.Empty;

						// Send the input off to be processed
						Interpreter.InterpretInput(content.TrimEnd('\n', '\r', ' '), state.ID);
					}
	                else
	                {
	                    // Not all data received. Get more. Clear the buffer first.
						state.buffer = new byte[ClientConnection.BufferSize];

						// Make sure we don't call BeginReceive() twice
						if (!state.IsWaitingForData)
						{
							// Indicate we're waiting for data
							state.IsWaitingForData = true;

							// Wait for data
		                    handler.BeginReceive(state.buffer, 0, ClientConnection.BufferSize, 0, new AsyncCallback(ReadCallback), state);
						}
	                }
				}
			}
			catch (Exception ex) {
                if (ex.GetType() == typeof(SocketException) || ex.GetType() == typeof(ObjectDisposedException))
                {
                    Logging.Log.Warn(String.Format("Error communicating with connection ID {0}, closing connection.", state.ID));

                    // End the session
                    handler.Close();

                    // Remove the connection from ClientConnections, if it's still there
                    if (ClientConnections.Contains(state))
                        ClientConnections.RemoveAt(ClientConnections.FindIndex(c => c.ID.Equals(state.ID)));
                }
                else
                    throw ex;
			}
        }

        /// <summary>
        /// Ends the remote session with the user
        /// </summary>
        /// <param name="state">The user's current StateObject</param>
        public static void EndSession(ClientConnection state)
        {
            // Send the goodbye message to the user
            byte[] byteData = Encoding.ASCII.GetBytes(Consts.Strings.Goodbye);

            // Send the data to the remote user then end the session
			state.workSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(EndSessionCallback), state);
        }

        private static void ShutdownConnection(ClientConnection state)
        {
            try
            {

                // Pull the socket from the state
                Socket handler = state.workSocket;

                // Log
                Logging.Log.Info(String.Format("[{0}]: Closing connection with {1} on local port {2}. Data sent/recv: {3:n0}/{4:n0}", state.ID, IPAddress.Parse(((IPEndPoint)handler.RemoteEndPoint).Address.ToString()), ((IPEndPoint)handler.RemoteEndPoint).Port, state.bytesSent, state.bytesReceived));

                // End the session
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

                // Remove the connection from ClientConnections
                ClientConnections.RemoveAt(ClientConnections.FindIndex(c => c.ID.Equals(state.ID)));
            }
            catch (Exception ex)
            {
                // Log the exception then just ignore it
                Logging.Log.Error(String.Format("Exception shutting down connection {0}: {1} {2}", state.ID, ex.Message, ex.StackTrace));
            }
        }

        private static void EndSessionCallback(IAsyncResult ar)
        {
            try
            {
                // Read the state object
                ClientConnection state = (ClientConnection)ar.AsyncState;

                // Shut down the connection
                ShutdownConnection(state);
            }
            catch (Exception e)
            {
                Logging.Log.Error(e.ToString());
            }
        }

		/// <summary>
		/// Sends data <paramref name="data"/> to the client
		/// </summary>
		/// <param name="data">Data to send to the client</param>
		/// <param name="state">State object of the client to interact with</param>
		public static void Send(string data, ClientConnection state)
		{
			Send(state.workSocket, data, state);
		}

        public static void Send(Socket handler, string data, ClientConnection state)
        {
            Send(state.workSocket, data, state, true);
        }

		public static void Send(Socket handler, String data, ClientConnection state, bool waitForResponse)
        {
            AsyncCallback callback = null;

            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Package up the callback
            if (waitForResponse)
                callback = new AsyncCallback(SendCallback);

            // Begin sending data
            try
            {
                handler.BeginSend(byteData, 0, byteData.Length, 0, callback, state);
            }
            catch (SocketException ex)
            {
                if (ex.SocketErrorCode == SocketError.ConnectionAborted)
                    // Aborted connection, just shut down the socket - they're gone
                    ShutdownConnection(state);
                else
                    // Other socket error, rethrow 
                    throw ex;
            }
        }

        public static void SendCommand(Socket handler, byte[] command, ClientConnection state)
        {
            // Send the command as passed
            handler.BeginSend(command, 0, command.Length, 0, new AsyncCallback(SendCallback), state);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            // Read the state object
            ClientConnection state = (ClientConnection)ar.AsyncState;

            try
            {
                // Pull the Socket from the state object
                Socket handler = state.workSocket;

                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);

                // Increment the connection's bytesSent count
                state.bytesSent += (UInt64)bytesSent;

				// Be careful not to call BeginReceive() twice
				if (!state.IsWaitingForData)
				{
					// Indicate we're waiting for more data
					state.IsWaitingForData = true;

	                // Receive more data
	                handler.BeginReceive(state.buffer, 0, ClientConnection.BufferSize, 0, new AsyncCallback(ReadCallback), state);
				}
                //handler.Shutdown(SocketShutdown.Both);
                //handler.Close();

            }
            catch (Exception ex)
            {
                if ((ex.GetType() == typeof(SocketException) && ((SocketException)ex).SocketErrorCode == SocketError.ConnectionAborted) || ex.GetType() == typeof(ObjectDisposedException))
                {
                    // The remote client has disconnected, so log them out
                    // TODO: Actually log the user out (save their data, etc.) rather than just dump their connection
                    Logging.Log.Info(String.Format("[{0}]: Client socket closed, shutting down session.", state.ID));
                    ShutdownConnection(state);
                }
                else
                    Logging.Log.Error(ex.ToString());
            }
        }
    }
}