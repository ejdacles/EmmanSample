// <copyright file="IPacket.cs" company="Laborie">
// Copyright (c) Laborie. All rights reserved.
// </copyright>

namespace Laborie.Synergy.HardwareManager.Transport.Interfaces
{
    public interface IPacket
    {
        int Timeout { get; set; }

        byte[] Data { get; set; }

        bool IsValid();

        bool IsExpectedResponse(byte[] receivedBytes);
    }
}
