// <copyright file="Packet.cs" company="Laborie">
// Copyright (c) Laborie. All rights reserved.
// </copyright>

namespace Laborie.Synergy.HardwareManager.Transport
{
    using Laborie.Synergy.HardwareManager.Transport.Interfaces;

    public class Packet : IPacket
    {
        public int Id { get; set; }

        public int Timeout { get; set; }

        public byte[] Data { get; set; }

        public bool IsValid()
        {
            return Data != null;
        }

        public bool IsExpectedResponse(byte[] receivedBytes) => true;
    }
}
