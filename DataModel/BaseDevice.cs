//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class BaseDevice
    {
        public int ID { get; set; }
        public string SerialNumber { get; set; }
        public string Alias { get; set; }
        public DeviceConnectionType ConnectionType { get; set; }
        public DeviceTypes DeviceType { get; set; }
        public Nullable<bool> IsRegistered { get; set; }
        public string FirmwareVersion { get; set; }
        public Nullable<int> BatteryLevel { get; set; }
        public Nullable<DeviceConnectionStatus> ConnectionStatus { get; set; }
        public string DataFilePath { get; set; }
        public string BtMacAddress { get; set; }
        public string UsbSerialNumber { get; set; }
    }
}
