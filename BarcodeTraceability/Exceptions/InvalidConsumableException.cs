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
    /// Consumable has an unknown Category / GTIN
    /// </summary>
    [Serializable]
    internal class InvalidConsumableException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidConsumableException"/> class.
        /// </summary>
        /// <param name="message">Exception message</param>
        internal InvalidConsumableException(string message)
            : base(message)
        {
        }
    }
}