// <copyright file="PumpSpeedChange.cs" company="Laborie">
// Copyright (c) Laborie. All rights reserved.
// </copyright>

namespace Laborie.Synergy.DataModel
{
    /// <summary>
    /// Extension to the Entity Framework auto generated PumpSpeedChange class
    /// </summary>
    public partial class PumpSpeedChange
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PumpSpeedChange"/> class. 
        /// </summary>
        public PumpSpeedChange()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PumpSpeedChange"/> class, with the specified pump speed change value. 
        /// </summary>
        /// <param name="value">pump speed change value</param>
        public PumpSpeedChange(short value)
        {
            Value = value;
        }
    }
}