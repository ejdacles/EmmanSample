// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Laborie.Synergy.BarcodeTraceability.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Consumable is already used by same patient before more that 4 hours ago exception class
    /// </summary>
    [Serializable]
    internal class ConsumableIsUsedBySamePatientAfterFourHoursException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumableIsUsedBySamePatientAfterFourHoursException"/> class.
        /// </summary>
        /// <param name="message">Exception message</param>
        internal ConsumableIsUsedBySamePatientAfterFourHoursException(string message)
            : base(message)
        {
        }
    }
}
