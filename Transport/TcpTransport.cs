// <copyright file="TCPTransport.cs" company="Laborie">
// Copyright (c) Laborie. All rights reserved.
// </copyright>

using System.IO;

namespace Laborie.Synergy.HardwareManager.Transport
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using Laborie.Synergy.Common.ApplicationLogging;
    using Laborie.Synergy.DataModel;
    using Laborie.Synergy.HardwareManager.TcpCommunicationInterfaces;

    public class TcpTransport : Interfaces.ITransport
    {
        private readonly IPAddress addressIp;
        private readonly int portNumber;
        private readonly byte[] dataBytes = new byte[10025];

        private TcpClient clientSocket;
        private INetworkStream serverNetworkStream;
        private Thread tcpIPthread;
        private bool serverThreadRunningFlag;
        private bool tcpipThreadRunningFlag;
        private bool tryConnectingFlag;

        public TcpTransport(string url, ILogger logger = null)
        {
            var urlParts = url.Split(':');
            addressIp = IPAddress.Parse(urlParts[0]);
            portNumber = int.Parse(urlParts[1]);
        }

        /// <summary>
        /// Transport Data Received Event Handler
        /// </summary>
        public event EventHandler<byte[]> TransportDataReceived;

        public bool Open()
        {
            tcpIPthread = new Thread(TcpipThreadListener);
            tcpIPthread.Start();
            Thread.Sleep(100);

            return true;
        }

        public bool Close()
        {
            clientSocket?.Close();
            clientSocket = null;

            serverNetworkStream?.Close();
            serverNetworkStream = null;

            return true;
        }

        public bool Write(byte[] transmitArray)
        {
            bool ret = false;

            if (serverNetworkStream != null)
            {
                serverNetworkStream.Write(transmitArray, 0, transmitArray.Length);
                serverNetworkStream.Flush();
                ret = true;
            }

            return ret;
        }

        public override string ToString()
        {
            return $"Address: {addressIp}:{portNumber}";
        }

        public byte[] Read()
        {
            // Once execution reached this point it means that connection with Server is established
            // Now we can try to read incoming stream
            if (serverNetworkStream != null)
            {
                var bytesRead = serverNetworkStream.Read(dataBytes, 0, dataBytes.Length);

                if (bytesRead == 0)
                {
                    Thread.Sleep(10);
                }
                else
                {
                    // Process the data received from the socket
                    TransportDataReceived?.Invoke(this, serverNetworkStream.ReadBuffer.Take(bytesRead).ToArray());
                }
            }

            return dataBytes;
        }

        /// <summary>
        /// Dispose of Object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose the object.
        /// </summary>
        /// <param name="disposing">Indicates disposing is active.</param>
        protected virtual void Dispose(bool disposing)
        {
            clientSocket.Dispose();
            clientSocket = null;

            serverNetworkStream?.Close();
            serverNetworkStream = null;
        }

        private void TcpipThreadListener()
        {
            serverThreadRunningFlag = true;
            tryConnectingFlag = true;
            byte[] bytesFrom = new byte[10025];

            while (serverThreadRunningFlag)
            {
                while (tryConnectingFlag)
                {
                    try
                    {
                        if (clientSocket == null)
                        {
                            clientSocket = new TcpClient();
                        }

                        clientSocket.Connect(addressIp, portNumber);
                        serverNetworkStream = new TcpNetworkStream(clientSocket?.GetStream());
                        tryConnectingFlag = false;
                        tcpipThreadRunningFlag = true;
                    }
                    catch (ObjectDisposedException)
                    {
                        tryConnectingFlag = true;
                    }
                    catch (SocketException)
                    {
                        tryConnectingFlag = true;
                    }
                }

                // Once execution reached this point it means that connection with Server is established
                // Now we can try to read incoming stream
                int bytesRead = -1;

                try
                {
                    // Notice: The line below executes ONLY after bytesFrom will have something in it
                    // which is achieved by a "Bond" or "Start Sampling all RS" on the Server app.
                    if (serverNetworkStream != null)
                    {
                        bytesRead = serverNetworkStream.Read(bytesFrom, 0, bytesFrom.Length);

                        if (bytesRead == 0)
                        {
                            Thread.Sleep(10);
                        }
                        else
                        {
                            // Process the data received from the socket
                            TransportDataReceived?.Invoke(this, bytesFrom);
                        }
                    }

                    Thread.Sleep(10);
                }
                catch (IOException ex)
                {
                    Cleanup(ex);
                    break;
                }
                catch (ObjectDisposedException ex)
                {
                    Cleanup(ex);
                    break;
                }
            }
        }

        /// <summary>
        /// Closes socket and network stream
        /// </summary>
        private void Cleanup(Exception ex = null)
        {
            // Stop trying to read, set reconnect flag to true
            tcpipThreadRunningFlag = false;
            tryConnectingFlag = true;
            clientSocket?.Close();
            clientSocket = null;
            serverNetworkStream?.Close();
            serverNetworkStream = null;
        }
    }
}
