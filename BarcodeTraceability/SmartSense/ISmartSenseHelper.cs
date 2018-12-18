// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.BarcodeTraceability.SmartSense
{
    using System.Collections.Generic;
    using Laborie.Synergy.BarcodeTraceability.Model;
    using Laborie.Synergy.HardwareManager.Interfaces;

    public interface ISmartSenseHelper
    {
        List<BarcodeModel> Decode(byte[] encryptedBytes);

        List<BarcodeModel> Decode(IRfidTag rfidTag);

        byte[] Encode(BarcodeModel barcodeModel);
    }
}
