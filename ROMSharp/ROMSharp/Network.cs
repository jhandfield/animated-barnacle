using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ROMSharp
{
    public class Network
    {
        // State object for reading client data asynchronously
        public class StateObject
        {
            // Client  socket.
            public Socket workSocket = null;
            // Size of receive buffer.
            public const int BufferSize = 1024;
            // Receive buffer.
            public byte[] buffer = new byte[BufferSize];
            // Received data string.
            public StringBuilder sb = new StringBuilder();
            // Data sent count
            public UInt64 bytesSent = 0;
            // Data received count
            public UInt64 bytesReceived = 0;
            // ID of the connection (handle number)
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

        public static void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.
            allDone.Set();

            // Get the socket that handles the client request.
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // Create the state object.
            StateObject state = new StateObject();
            state.workSocket = handler;

            // Log the connection
            Console.WriteLine("[{0}]: Connection established with {1} on local port {2}", state.ID, IPAddress.Parse(((IPEndPoint)handler.RemoteEndPoint).Address.ToString()), ((IPEndPoint)handler.RemoteEndPoint).Port);

            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);
        }

        // TODO: Implement EC / backspace characters
        // TODO: Implement required telnet commands
        public static void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket from the asynchronous state object.
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            // Read data from the client socket. 
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                // Increment the state's received count
                state.bytesReceived += (UInt64)bytesRead;

                // There might be more data, so store the data received so far.
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                // Check for a newline. If it is not there, read more data.
                content = state.sb.ToString();

                if (content.IndexOf((char)13) > -1)
                {
					// Send the input off to be processed
					Program.ParseCommand(content.Trim(), state);
                }
                else
                {
                    // Not all data received. Get more.
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }
            }
        }

        /// <summary>
        /// Ends the remote session with the user
        /// </summary>
        /// <param name="handler">The user's socket</param>
        /// <param name="state">The user's current StateObject</param>
        public static void EndSession(StateObject state)
        {
            // Send the goodbye message to the user
            byte[] byteData = Encoding.ASCII.GetBytes(Strings.Goodbye);

            // Send the data to the remote user then end the session
			state.workSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(EndSessionCallback), state);
        }

        private static void EndSessionCallback(IAsyncResult ar)
        {
            try
            {
                // Read the state object
                StateObject state = (StateObject)ar.AsyncState;

                // Pull the socket from the state
                Socket handler = state.workSocket;

                // Log
                Console.WriteLine("[{0}]: Closing connection with {1} on local port {2}. Data sent/recv: {3:n0}/{4:n0}", state.ID, IPAddress.Parse(((IPEndPoint)handler.RemoteEndPoint).Address.ToString()), ((IPEndPoint)handler.RemoteEndPoint).Port, state.bytesSent, state.bytesReceived);

                // End the session
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
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
		public static void Send(string data, StateObject state)
		{
			Send(state.workSocket, data, state);
		}

        public static void Send(Socket handler, String data, StateObject state)
        {
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.
            handler.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), state);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Read the state object
                StateObject state = (StateObject)ar.AsyncState;

                // Pull the Socket from the state object
                Socket handler = state.workSocket;

                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);

                // Increment the connection's bytesSent count
                state.bytesSent += (UInt64)bytesSent;

                //Console.WriteLine("Sent {0} bytes to client.", bytesSent);

                // Clear the buffer and reset the StringBuilder
                state.buffer = new byte[StateObject.BufferSize];
                state.sb.Clear();

                // Receive more data
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);

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