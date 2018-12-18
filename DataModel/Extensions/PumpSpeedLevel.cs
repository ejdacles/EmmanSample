// <copyright file="PumpSpeedLevel.cs" company="Laborie">
// Copyright (c) Laborie. All rights reserved.
// </copyright>

namespace Laborie.Synergy.DataModel
{
    /// <summary>
    /// Extension to the Entity Framework auto generated PumpSpeedLevel class
    /// </summary>
    public partial class PumpSpeedLevel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PumpSpeedLevel"/> class. 
        /// </summary>
        public PumpSpeedLevel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PumpSpeedLevel"/> class, with the specified pump speed level value. 
        /// </summary>
        /// <param name="value">pump speed level value</param>
        public PumpSpeedLevel(short value)
        {
            Value = value;
        }
    }
}