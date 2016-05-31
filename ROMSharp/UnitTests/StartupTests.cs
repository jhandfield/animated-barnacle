using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ROMSharp;
using System.Net;

namespace UnitTests
{
    [TestClass]
    public class StartupTests
    {
        [TestMethod]
        public void ParseArguments_Port()
        {
            int testPort = 8000;

            // Instantiate a ServerConfiguration object for use in the next call
            ServerConfiguration conf = new ServerConfiguration();

            // Invoke ParseArguments()
            Assert.IsTrue(ServerConfiguration.ParseArguments(new string[2] { "-port", testPort.ToString() }, out conf));

            // Check that conf.ListenPort is correct
            Assert.AreEqual(testPort, conf.listenPort);
        }

        [TestMethod]
        public void ParseArguments_IPAddr()
        {
            string testAddr = "127.0.0.1";
            IPAddress testAddrAddress = IPAddress.Parse(testAddr);

            // Instantiate a ServerConfiguration object for use in the next call
            ServerConfiguration conf = new ServerConfiguration();

            // Invoke ParseArguments()
            Assert.IsTrue(ServerConfiguration.ParseArguments(new string[2] { "-address", testAddr }, out conf));

            // Check that conf.ListenPort is correct
            Assert.AreEqual(testAddrAddress, conf.listenAddress);
        }
    }
}
