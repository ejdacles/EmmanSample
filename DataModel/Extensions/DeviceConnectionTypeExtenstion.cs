// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel.Extensions
{
    using System;

    /// <summary>
    /// Extenstion method for DeviceConnectionType that enables enum string constants to be localized.
    /// </summary>
    public static class DeviceConnectionTypeExtenstion
    {
        public static string LocalizedString(this DeviceConnectionType connectionType)
        { 
            switch (connectionType)
            {
                case DeviceConnectionType.USB: return Translations.Language.Enum_DeviceConnectionType_USB;

                case DeviceConnectionType.BLUETOOTH: return Translations.Language.Enum_DeviceConnectionType_Bluetooth;

                case DeviceConnectionType.BLUETOOTHLE: return Translations.Language.Enum_DeviceConnectionType_BluetoothLE;

                case DeviceConnectionType.SIMULATOR: return Translations.Language.Enum_DeviceConnectionType_Simulator;

                case DeviceConnectionType.TCP: return Translations.Language.Enum_DeviceConnectionType_TCP;

                default: throw new ArgumentOutOfRangeException("connectionType");
            }
        }
    }
}
