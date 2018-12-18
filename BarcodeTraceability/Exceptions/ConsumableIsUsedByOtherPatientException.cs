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
    /// Consumable is already used by another patient exception class
    /// </summary>
    [Serializable]
    internal class ConsumableIsUsedByOtherPatientException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumableIsUsedByOtherPatientException"/> class.
        /// </summary>
        /// <param name="message">Exception message</param>
        internal ConsumableIsUsedByOtherPatientException(string message)
            : base(message)
        {
        }        
    }
}
