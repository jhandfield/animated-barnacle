using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ROMSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int receivedBytes;
            byte[] buffer = new byte[1024];

            // Set up an endpoint listening on port 23 on all addresses (0.0.0.0:23)
            // TODO: Allow port to be overridden via args
            // TODO: Allow IP to be specified via args
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 23);

            // Set up a listener socket on the endpoint
            // TODO: Support IPv6
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(endpoint);
            serverSocket.Listen(10);

            Console.WriteLine("Socket listening, waiting for connection...");

            // Open a connection
            Socket clientSocket = serverSocket.Accept();
            IPEndPoint clientEndpoint = (IPEndPoint)clientSocket.RemoteEndPoint;

            Console.WriteLine("Client {0} connected on port {1}", clientEndpoint.Address, clientEndpoint.Port);

            // Encode a string to send to the client
            buffer = Encoding.ASCII.GetBytes("Welcome to my MUD!");

            // Send the string
            clientSocket.Send(buffer, buffer.Length, SocketFlags.None);

            // Receive and repeat
            while(true)
            {
                buffer = new byte[1024];
                receivedBytes = clientSocket.Receive(buffer);

                if (receivedBytes == 0)
                    break;

                Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, receivedBytes));
                clientSocket.Send(buffer, receivedBytes, SocketFlags.None);
            }

            Console.WriteLine("Disconnecting from client {0}", clientEndpoint.Address);
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
