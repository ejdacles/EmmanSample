// <copyright file="ISynPacket.cs" company="Laborie">
// Copyright (c) Laborie. All rights reserved.
// </copyright>

using Laborie.Synergy.HardwareManager.Device;

namespace Laborie.Synergy.HardwareManager.Transport.Interfaces
{
    public interface ISynPacket : IPacket
    {
        byte[] HeaderBytes { get; set; }

        ushort Command { get; }

        ushort Service { get; }

        ushort DataLength { get; }

        ushort SequenceNumber { get; }

        ushort Reserved { get; }

        byte[] PacketData { get; }

        ushort PacketCrc { get; }

        bool IsGuaranteedCommand { get; }

        bool IsGuaranteedResponse { get; }

        bool IsGuaranteedErrorResponse { get; }

        int GuaranteedCommandRetry { get; }

        int Maxlength { get; set; }

        /// <summary>
        /// Gets or sets extractor data from packet.
        /// </summary>
        IDataPacketExtractor DataPacketExtractor { get; set; }
    }
}
