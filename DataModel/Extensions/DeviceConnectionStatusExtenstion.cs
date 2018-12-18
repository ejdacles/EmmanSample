// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel.Extensions
{
    using System;

    /// <summary>
    /// Extenstion method for DeviceConnectionStatus that enables enum string constants to be localized.
    /// </summary>
    public static class DeviceConnectionStatusExtenstion
    {
        public static string LocalizedString(this DeviceConnectionStatus deviceConnectionStatus)
        {
            switch (deviceConnectionStatus)
            {
                case DeviceConnectionStatus.BluetoothError:
                    return Translations.Language.Enum_DeviceConnectionStatus_BluetoothError;

                case DeviceConnectionStatus.Connected:
                    return Translations.Language.Enum_DeviceConnectionStatus_Connected;

                case DeviceConnectionStatus.Disconnected:
                    return Translations.Language.Enum_DeviceConnectionStatus_Disconnected;

                case DeviceConnectionStatus.Disconnecting:
                    return Translations.Language.Enum_DeviceConnectionStatus_Disconnecting;

                case DeviceConnectionStatus.Failed: return Translations.Language.Enum_DeviceConnectionStatus_Failed;

                case DeviceConnectionStatus.Connecting:
                    return Translations.Language.Enum_DeviceConnectionStatus_Connecting;

                case DeviceConnectionStatus.USBError: return Translations.Language.Enum_DeviceConnectionStatus_USBError;

                case DeviceConnectionStatus.CommunicationError:
                    return Translations.Language.Enum_DeviceConnectionStatus_CommunicationError;

                case DeviceConnectionStatus.Unknown: return Translations.Language.Enum_DeviceConnectionStatus_Unknown;

                default: throw new ArgumentOutOfRangeException("deviceConnectionStatus");
            }
        }
    }
}
