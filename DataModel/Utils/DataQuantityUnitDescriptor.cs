// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel.Utils
{
    using System.Collections.Generic;

    /// <summary>
    /// Helper method for getting <see cref="DataQuantityUnit"/> unit labels
    /// </summary>
    public static class DataQuantityUnitDescriptor
    {
        /// <summary>
        /// Gets a collection of all <see cref="DataQuantityUnit"/> unit labels
        /// </summary>
        public static Dictionary<DataQuantityUnit, string> GetDescription => new Dictionary<DataQuantityUnit, string>
        {
            { DataQuantityUnit.None, DataQuantityConst.None },
            { DataQuantityUnit.MillimetersMercury, DataQuantityConst.MillimetersMercury },
            { DataQuantityUnit.Pascal, DataQuantityConst.Pascal },
            { DataQuantityUnit.CentimetersWater, DataQuantityConst.CentimetersWater },
            { DataQuantityUnit.MicroVolt, DataQuantityConst.MicroVolt },
            { DataQuantityUnit.MilliVolt, DataQuantityConst.MilliVolt },
            { DataQuantityUnit.Milliliters, DataQuantityConst.Milliliters },
            { DataQuantityUnit.MillilitersPerSecond, DataQuantityConst.MillilitersPerSecond },
            { DataQuantityUnit.MillilitersPerMinute, DataQuantityConst.MillilitersPerMinute },
            { DataQuantityUnit.MicroAmps, DataQuantityConst.MicroAmpere },
            { DataQuantityUnit.MilliAmps, DataQuantityConst.MilliAmpere },
            { DataQuantityUnit.Second, DataQuantityConst.Second },
            { DataQuantityUnit.MillimetersPerMinute, DataQuantityConst.MillimetersPerMinute },
            { DataQuantityUnit.Millimeters, DataQuantityConst.Millimeters },
            { DataQuantityUnit.Ohm, DataQuantityConst.Ohm },
            { DataQuantityUnit.SqrtMillilitersPerSecond, DataQuantityConst.SqrtMillilitersPerSecond },
            { DataQuantityUnit.MilliSeconds, DataQuantityConst.Milliseconds },
            { DataQuantityUnit.Percent, DataQuantityConst.Percent },
            { DataQuantityUnit.CentimetersWaterMillimeters, DataQuantityConst.CentimetersWaterMillimeters }
        };
    }
}
