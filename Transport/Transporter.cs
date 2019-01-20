// <copyright file="Transporter.cs" company="Laborie">
// Copyright (c) Laborie. All rights reserved.
// </copyright>

namespace Laborie.Synergy.HardwareManager.Transport
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Timers;
    using Laborie.Synergy.HardwareManager.Device;
    using Laborie.Synergy.HardwareManager.Transport.Interfaces;

    public class Transporter : ITransporter
    {
        private readonly ITransport transport;
        private Interfaces.IPacket lastSentPacket;
        private Timer waitResponseTimeoutTimer;

        public Transporter(ITransport transport)
        {
            this.transport = transport;
            this.transport.TransportDataReceived += Transporter_DataReceivedEvent;
            TransporterState = TransporterState.Ready;
        }

        public event EventHandler<Interfaces.IPacket> TransportDataReceived;

        public event EventHandler<Interfaces.IPacket> TransportDataTimeout;
        
        public TransporterState TransporterState { get; set; }

        public bool Connect()
        {
            return transport.Open();
        }

        public bool Disconnect()
        {
            return transport.Close();
        }

        public bool Send(Interfaces.IPacket packet)
        {
            if (packet.Data == null || TransporterState != TransporterState.Ready) return false;

            TransporterState = TransporterState.TransferingData;
            var ret = transport.Write(packet.Data);
            lastSentPacket = packet;

            if (ret && lastSentPacket.Timeout > 0)
            {
                SetWaitResponseTimeoutTimer(lastSentPacket);
            }
            else
            {
                TransporterState = TransporterState.Ready;
            }

            return ret;
        }

        public void ClearWaitResponseTimeoutTimer(Interfaces.IPacket packet)
        {
            if (waitResponseTimeoutTimer == null) return;

            waitResponseTimeoutTimer.Enabled = false;
            waitResponseTimeoutTimer.Stop();
            TransporterState = TransporterState.Ready;
        }

        protected virtual void Transporter_DataReceivedEvent(object sender, byte[] bytesReceived)
        {
            if (lastSentPacket.Timeout > 0 && TransporterState == TransporterState.WaitingResponse)
            {
                if (lastSentPacket.IsExpectedResponse(bytesReceived))
                {
                    TransporterState = TransporterState.Ready;
                    ClearWaitResponseTimeoutTimer(null);
                }
            }

            TransportDataReceived?.Invoke(this, new Packet() { Data = bytesReceived });
        }

        private void SetWaitResponseTimeoutTimer(Interfaces.IPacket packet)
        {
            if (waitResponseTimeoutTimer == null)
            {
                waitResponseTimeoutTimer = new Timer(packet.Timeout);
                waitResponseTimeoutTimer.Elapsed += ResponseTimeoutElapsed;
            }

            TransporterState = TransporterState.WaitingResponse;
            waitResponseTimeoutTimer.Interval = packet.Timeout;
            waitResponseTimeoutTimer.Enabled = true;
            waitResponseTimeoutTimer.Start();
        }

        private void ResponseTimeoutElapsed(object sender, EventArgs e)
        {
            ClearWaitResponseTimeoutTimer(lastSentPacket);
            TransportDataTimeout?.Invoke(this, lastSentPacket);
        }
    }
}
