// <copyright file="ITransporter.cs" company="Laborie">
// Copyright (c) Laborie. All rights reserved.
// </copyright>

namespace Laborie.Synergy.HardwareManager.Transport.Interfaces
{
    using System;
    using Laborie.Synergy.HardwareManager.Device;

    public interface ITransporter
    {
        /// <summary>
        /// Event that indicates data has been received through port.
        /// </summary>
        event EventHandler<Interfaces.IPacket> TransportDataReceived;

        event EventHandler<Interfaces.IPacket> TransportDataTimeout;

        TransporterState TransporterState { get; set; }

        bool Connect();

        bool Disconnect();

        bool Send(IPacket transportPacket);

        void ClearWaitResponseTimeoutTimer(Interfaces.IPacket packet);
    }
}
