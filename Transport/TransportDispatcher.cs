// <copyright file="TransportDispatcher.cs" company="Laborie">
// Copyright (c) Laborie. All rights reserved.
// </copyright>

namespace Laborie.Synergy.HardwareManager.Transport
{
    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using Laborie.Synergy.Common.ExtensionMethods;
    using Laborie.Synergy.HardwareManager.Device;
    using Laborie.Synergy.HardwareManager.Transport.Interfaces;
    using Timer = System.Timers.Timer;

    public class TransportDispatcher : ITransportDispatcher
    {
        private readonly ITransporter transporter;
        private readonly ManualResetEvent manualStreamOpenedEvent = new ManualResetEvent(false);
        private readonly ConcurrentQueue<ISynPacket> packetQueue = new ConcurrentQueue<ISynPacket>();

        private ISynPacket currentTransportPacket;
        private Timer transmitTimer;
        private ushort sequenceNumber;
        private int guaranteedCmdRetry;

        public TransportDispatcher(ITransporter transporter)
        {
            this.transporter = transporter;
            transmitTimer = new Timer(100);
            transmitTimer.Elapsed += this.OnTimeTxQueue;
            transmitTimer.Enabled = true;
            sequenceNumber = 0;
            guaranteedCmdRetry = 0;
        }

        public event EventHandler<ISynPacket> TransportDataReceived;

        public event EventHandler<ISynPacket> TransportDataTimeout;

        public TransporterState TransportDispatcherState => transporter?.TransporterState ?? TransporterState.Disconnected;

        public bool Connect()
        {
            transporter.TransportDataReceived += Dispatcher_DataReceivedEvent;
            transporter.TransportDataTimeout += Dispatcher_TransportDataTimeout;
            var ret = transporter.Connect();
            if (ret)
            {
                manualStreamOpenedEvent?.Set();
            }

            return ret;
        }

        public void Disconnect()
        {
            manualStreamOpenedEvent?.Reset();
            transporter.TransportDataReceived -= Dispatcher_DataReceivedEvent;
            transporter.TransportDataTimeout -= Dispatcher_TransportDataTimeout;
            transporter.Disconnect();
            packetQueue.Clear();
        }

        public void Enqueue(ISynPacket transportPacket)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispatcher_DataReceivedEvent(object sender, Interfaces.IPacket packet)
        {
            if (currentTransportPacket.IsGuaranteedCommand && currentTransportPacket.IsExpectedResponse(packet.Data))
            {
                packetQueue.TryDequeue(out var onePacket);
                guaranteedCmdRetry = 0;
                transporter.ClearWaitResponseTimeoutTimer(packet);
                TransportDataReceived?.Invoke(this, new SynPacket(packet, currentTransportPacket.DataPacketExtractor));
            }
            else
            {
                TransportDataReceived?.Invoke(this, new SynPacket(packet, null));
            }
        }

        protected virtual void Dispatcher_TransportDataTimeout(object sender, Interfaces.IPacket packet)
        {
            if (guaranteedCmdRetry > 0)
            {
                if (TransportDispatcherState == TransporterState.Ready)
                {
                    transporter.Send(currentTransportPacket);
                }
            }
            else
            {
                packetQueue.TryDequeue(out var onePacket);
                transporter.ClearWaitResponseTimeoutTimer(packet);
                TransportDataTimeout?.Invoke(this, currentTransportPacket);
            }
        }

        protected void OnTimeTxQueue(object sender, EventArgs e)
        {
            if (manualStreamOpenedEvent.WaitOne(5000) && 
                TransportDispatcherState == TransporterState.Ready &&
                guaranteedCmdRetry == 0 && packetQueue.TryPeek(out currentTransportPacket))
            {
                try
                {
                    var packet = currentTransportPacket;

                    transporter.Send(packet);

                    if (!currentTransportPacket.IsGuaranteedCommand)
                    {
                        packetQueue.TryDequeue(out var onePacket);
                    }
                    else
                    {
                        guaranteedCmdRetry = currentTransportPacket.GuaranteedCommandRetry;
                    }
                }
                catch (Exception exception)
                {
                    // TODO insert logic if transport can not send packet
                    Console.WriteLine(exception);
                }
            }
        }
    }
}
