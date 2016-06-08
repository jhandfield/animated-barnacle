using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Generic;

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
            public const int BufferSize = 32;
            // Receive buffer.
            public byte[] buffer = new byte[BufferSize];
            // Received data string.
            public StringBuilder sb = new StringBuilder();
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
			public string LastCommand { get; set; }

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
			#endregion

			#region Constructors
			public ClientConnection() {
				// Record the connected time of the client
				this.ConnectedAt = DateTime.Now;

				// Set the default client state
				this.State = ROMSharp.Enums.ClientState.Idle;

				// Set TCP Keepalive properties
				ConfigureSocketKeepalive(this.workSocket);
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
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and listen for incoming connections.
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

				// Start an asynchronous socket to listen for connections.
				Console.WriteLine("Waiting for a connection on address {0} port {1}...", addr.ToString(), port);


				//Timer socketTimeoutTimer = new Timer(
                while (true)
                {
                    // Set the event to nonsignaled state.
                    allDone.Reset();

                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        listener);

                    // Wait until a connection is made before continuing.
                    allDone.WaitOne();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();

        }

		private void CheckSocketTimeout(Object state)
		{
			// Loop over each socket
		}

        public static void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.
            allDone.Set();

            // Get the socket that handles the client request.
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // Create the state object.
            ClientConnection state = new ClientConnection();
            state.workSocket = handler;

			// Add the state object to ClientConnections
			ClientConnections.Add(state);

            // Log the connection
            Console.WriteLine("[{0}]: Connection established with {1} on local port {2}", state.ID, IPAddress.Parse(((IPEndPoint)handler.RemoteEndPoint).Address.ToString()), ((IPEndPoint)handler.RemoteEndPoint).Port);

			// Call the greeting method
			Commands.DoGreeting(state.ID);
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

	                // There might be more data, so store the data received so far.
	                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

	                // Read the StringBuffer
					content = state.sb.ToString();

					// Check for a null character at the end of the buffer; if we don't have it, continue reading until we've gotten the whole message
					//if (content.IndexOf('\n') > -1 && content.IndexOf('\r') > -1 || content.Equals(String.Empty))
					if (state.buffer[ClientConnection.BufferSize - 1] == '\0')
	                {
						state.buffer = new byte[ClientConnection.BufferSize];
						state.sb.Clear();

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
			catch (System.Net.Sockets.SocketException) {
				Console.WriteLine ("Error communicating with connection ID {0}, closing connection.", state.ID);

				// End the session
				handler.Close();

				// Remove the connection from ClientConnections
				ClientConnections.RemoveAt(ClientConnections.FindIndex(c => c.ID.Equals(state.ID)));
			}
		}

        /// <summary>
        /// Ends the remote session with the user
        /// </summary>
        /// <param name="handler">The user's socket</param>
        /// <param name="state">The user's current StateObject</param>
        public static void EndSession(ClientConnection state)
        {
            // Send the goodbye message to the user
            byte[] byteData = Encoding.ASCII.GetBytes(Consts.Strings.Goodbye);

            // Send the data to the remote user then end the session
			state.workSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(EndSessionCallback), state);
        }

        private static void EndSessionCallback(IAsyncResult ar)
        {
            try
            {
                // Read the state object
                ClientConnection state = (ClientConnection)ar.AsyncState;

                // Pull the socket from the state
                Socket handler = state.workSocket;

                // Log
                Console.WriteLine("[{0}]: Closing connection with {1} on local port {2}. Data sent/recv: {3:n0}/{4:n0}", state.ID, IPAddress.Parse(((IPEndPoint)handler.RemoteEndPoint).Address.ToString()), ((IPEndPoint)handler.RemoteEndPoint).Port, state.bytesSent, state.bytesReceived);

                // End the session
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

				// Remove the connection from ClientConnections
				ClientConnections.RemoveAt(ClientConnections.FindIndex(c => c.ID.Equals(state.ID)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
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

		public static void Send(Socket handler, String data, ClientConnection state)
        {
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.ASCII.GetBytes(data);

			// Begin sending data
			handler.BeginSend (byteData, 0, byteData.Length, 0, new AsyncCallback (SendCallback), state);
		}

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Read the state object
                ClientConnection state = (ClientConnection)ar.AsyncState;

                // Pull the Socket from the state object
                Socket handler = state.workSocket;

                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);

                // Increment the connection's bytesSent count
                state.bytesSent += (UInt64)bytesSent;

                //Console.WriteLine("Sent {0} bytes to client.", bytesSent);

                // Clear the buffer and reset the StringBuilder
                //state.buffer = new byte[ClientConnection.BufferSize];
                //state.sb.Clear();

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
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}