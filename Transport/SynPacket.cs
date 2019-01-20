// <copyright file="SynPacket.cs" company="Laborie">
// Copyright (c) Laborie. All rights reserved.
// </copyright>

namespace Laborie.Synergy.HardwareManager.Transport
{
    using System;
    using System.Linq;
    using Laborie.Synergy.HardwareManager.Device;
    using Laborie.Synergy.HardwareManager.Transport.Interfaces;

    public class SynPacket : ISynPacket
    {
        public SynPacket(byte[] data, IDataPacketExtractor dataPacketExtractor = null)
        {
            Data = data;
            if (dataPacketExtractor == null) dataPacketExtractor = new DataPacketExtractor();

            DataPacketExtractor = dataPacketExtractor;
            
            Initialize();
            if (IsGuaranteedCommand)
            {
                Timeout = General.GuaranteedCommandTimeout;
            }
        }

        public SynPacket(Interfaces.IPacket packet, IDataPacketExtractor dataPacketExtractor = null)
        {
            Data = packet.Data;
            Timeout = packet.Timeout;
            if (dataPacketExtractor == null) dataPacketExtractor = new DataPacketExtractor();

            DataPacketExtractor = dataPacketExtractor;

            Initialize();
        }

        public byte[] Data { get; set; }

        public int Timeout { get; set; } = 0;

        public byte[] HeaderBytes { get; set; }

        public ushort HeaderStart => HeaderBytes[(int)General.PacketInfo.IndexHS];

        public ushort Command => HeaderBytes[(int)General.PacketInfo.IndexCMD];

        public ushort Service => BitConverter.ToUInt16(HeaderBytes.Skip((int)General.PacketInfo.IndexServiceID).Take(2).ToArray(), 0);

        public ushort DataLength => BitConverter.ToUInt16(HeaderBytes.Skip((int)General.PacketInfo.IndexDataLen).Take(2).ToArray(), 0);

        public ushort SequenceNumber => BitConverter.ToUInt16(HeaderBytes.Skip((int)General.PacketInfo.IndexSeq).Take(2).ToArray(), 0);

        public ushort Reserved => HeaderBytes[(int)General.PacketInfo.IndexRes];

        public ushort DataStart => HeaderBytes[(int)General.PacketInfo.IndexDS];

        public byte[] PacketData { get; set; }

        public ushort PacketCrc { get; set; }

        public bool IsGuaranteedCommand => (CommunicationCommand) Command == CommunicationCommand.ReadRequest ||
                                           (CommunicationCommand) Command == CommunicationCommand.WriteRequest ||
                                           (CommunicationCommand) Command == CommunicationCommand.PriorityEvent;
        
        public bool IsGuaranteedResponse => (CommunicationCommand) Command == CommunicationCommand.ReadResponse || 
                                            (CommunicationCommand) Command == CommunicationCommand.WriteResponse || 
                                            (CommunicationCommand) Command == CommunicationCommand.PriorityEventResponse;

        public bool IsGuaranteedErrorResponse => (CommunicationCommand)Command == CommunicationCommand.ReadResponseError || 
                                                 (CommunicationCommand)Command == CommunicationCommand.WriteResponseError || 
                                                 (CommunicationCommand)Command == CommunicationCommand.PriorityEventResponseError;

        public int GuaranteedCommandRetry { get; } = 3;

        public int Maxlength { get; set; }

        public IDataPacketExtractor DataPacketExtractor { get; set; }

        public bool IsExpectedResponse(byte[] receivedBytes)
        {
            var commandResponse = (CommunicationCommand)receivedBytes[(int)General.PacketInfo.IndexCMD];
            return commandResponse == CommunicationCommand.ReadResponse ||
                   commandResponse == CommunicationCommand.WriteResponse ||
                   commandResponse == CommunicationCommand.PriorityEventResponse ||
                   commandResponse == CommunicationCommand.ReadResponseError ||
                   commandResponse == CommunicationCommand.WriteResponseError ||
                   commandResponse == CommunicationCommand.PriorityEventResponseError;
        }

        public bool IsValid()
        {
            return true;
        }

        private void Initialize()
        {
            var byteList = Data.ToList();

            if (!General.IsValidSynergyHeader(byteList))
            {
                int hsIndex = byteList.FindIndex(1, hs => hs.Equals(General.HeaderStart));

                if (hsIndex == -1)
                {
                    byteList.Clear();
                }
                else
                {
                    byteList.RemoveRange(0, hsIndex);
                }
            }

            Data = byteList.ToArray();

            HeaderBytes = Data.Take(General.PacketHeaderLen).ToArray();
            PacketData = Data.Skip((int)General.PacketInfo.IndexData).Take(DataLength).ToArray();
            PacketCrc = BitConverter.ToUInt16(Data.Skip(General.PacketHeaderLen + DataLength).Take(General.PacketCrcLen).ToArray(), 0);
        }
    }
}
