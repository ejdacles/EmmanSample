// <copyright file="ITrasnportDispatcher.cs" company="Laborie">
// Copyright (c) Laborie. All rights reserved.
// </copyright>

namespace Laborie.Synergy.HardwareManager.Transport.Interfaces
{
    using System;
    using System.Collections.Concurrent;
    using Laborie.Synergy.HardwareManager.Device;

    public interface ITransportDispatcher
    {
        /// <summary>
        /// Event that indicates data has been received through port.
        /// </summary>
        event EventHandler<ISynPacket> TransportDataReceived;

        /// <summary>
        /// Event that indicates a timeout.
        /// </summary>
        event EventHandler<ISynPacket> TransportDataTimeout;

        TransporterState TransportDispatcherState { get; }

        void Enqueue(ISynPacket transportPacket);

        bool Connect();

        void Disconnect();
    }
}
