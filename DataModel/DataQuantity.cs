// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    /// <summary>
    /// The data quantity type.
    /// These values are used in the database, existing values are not allowed to be changed
    /// </summary>
    public enum DataQuantityType
    {
        None = 0,
        Pressure = 1,
        EMG = 2,
        Flow = 3,
        PumpFlow = 4,
        Stimulation = 5,
        FlowVolume = 6,
        PumpVolume = 7,
        BladderVolume = 8,
        PullerSpeed = 9,
        Distance = 10,
        Resistance = 11,
        SpecificGravity = 12
    }

    /// <summary>
    /// The data quantity unit.
    /// These values are used in the database, existing values are not allowed to be changed
    /// </summary>
    public enum DataQuantityUnit
    {
        None = 0,
        MillimetersMercury = 1,
        Pascal = 2,
        CentimetersWater = 3,
        MicroVolt = 4,
        MilliVolt = 5,
        Milliliters = 6,
        MillilitersPerSecond = 7,
        MillilitersPerMinute = 8,
        MicroAmps = 9,
        MilliAmps = 10,
        Second = 11,
        MillimetersPerMinute = 12,
        Millimeters = 13,
        Ohm = 14,
        NoneDimensional = 15,
        SqrtMillilitersPerSecond = 16,
        CentimetersWaterPerSquareOfMillilitersPerSecond = 17,
        MilliSeconds = 18,
        Percent = 19,
        MillilitersPerCentimetersWater = 20,
        CentimetersWaterMillimeters = 21,
        GramsPerLitre = 22
    }

    /// <summary>
    /// The data quantity class. Specifies type and unit.
    /// </summary>
    public class DataQuantity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataQuantity"/> class.
        /// </summary>
        /// <param name="type">
        /// The quantity type.
        /// </param>
        /// <param name="unit">
        /// The unit.
        /// </param>
        public DataQuantity(DataQuantityType type, DataQuantityUnit unit)
        {
            Type = type;
            Unit = unit;
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        public DataQuantityType Type { get; private set; }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        public DataQuantityUnit Unit { get; set; }
   }
}
